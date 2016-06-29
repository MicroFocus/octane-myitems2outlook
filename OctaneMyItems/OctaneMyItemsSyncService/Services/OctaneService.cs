using OctaneMyItemsSyncService.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OctaneMyItemsSyncService.Services
{
    public class OctaneService
    {
        private readonly string _octaneServer;
        private HttpClient _httpClient;

        private string _currentUserName;
        private User _currentUser;
        private int _defaultSharespaceId;
        private Workspace _defaultWorkspace;

        public OctaneService(string octaneServer)
        {
            _octaneServer = octaneServer;
        }

        public async Task Login(string user, string password)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri(_octaneServer);
            var content = new StringContent(
                string.Format("{{\"user\":\"{0}\", \"password\":\"{1}\"}}", user, password),
                Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("/authentication/sign_in", content);
            result.EnsureSuccessStatusCode();

            foreach (Cookie cookie in cookieContainer.GetCookies(result.RequestMessage.RequestUri))
            {
                if (cookie.Name == "HPSSO_COOKIE_CSRF")
                {
                    _httpClient.DefaultRequestHeaders.Add("HPSSO_HEADER_CSRF", cookie.Value);
                    _httpClient.DefaultRequestHeaders.Add("HPSSO-HEADER-CSRF", cookie.Value);
                }
                else if (cookie.Name == "LWSSO_COOKIE_KEY")
                {
                    _httpClient.DefaultRequestHeaders.Add("LWSSO_COOKIE_KEY", cookie.Value);
                }
            }

            _httpClient.DefaultRequestHeaders.Add("HPECLIENTTYPE", "HPE_MQM_UI");
            _currentUserName = user;
        }
        public async Task Logout()
        {
            var response = await _httpClient.PostAsync("/authentication/sign_out", null);
            response.EnsureSuccessStatusCode();
        }

        public void SetDefaultSharespace(int sharespaceId)
        {
            _defaultSharespaceId = sharespaceId;
        }
        public async Task SetDefaultWorkspace(Workspace workspace)
        {
            _defaultWorkspace = workspace;
            var response = await _httpClient.GetAsync($"api/shared_spaces/{_defaultSharespaceId}/workspaces/{_defaultWorkspace.id}/workspace_users?query=\"name='{_currentUserName}'\"");
            var result = await response.Content.ReadAsAsync<Users>();
            _currentUser = result.data[0];
        }

        public async Task<Workspaces> GetWorkspace()
        {
            var response = await _httpClient.GetAsync($"/api/shared_spaces/{_defaultSharespaceId}/workspaces");
            return await response.Content.ReadAsAsync<Workspaces>();
        }

        public async Task<Backlogs> GetBacklogs(string parameters = null)
        {
            var url = $"/api/shared_spaces/{_defaultSharespaceId}/workspaces/{_defaultWorkspace.id}/work_items";
            if (!string.IsNullOrEmpty(parameters)) url += "?" + parameters;
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsAsync<Backlogs>();
        }
        public async Task<Backlogs> GetMyBacklogs()
        {
            var query = "owner={id=" + _currentUser.id + "};phase={metaphase={(name EQ 'New'|| name EQ 'In Progress' || name EQ 'In Testing')}};(subtype EQ 'defect'||subtype EQ 'story'||subtype EQ 'quality_story')";            var expand = "$all{fields = name}";
            return await GetBacklogs(string.Format("query=\"{0}\"&expand={1}", query, expand));
        }

        public async Task<Tests> GetTests(string parameters = null, bool withscript = false)
        {
            var url = $"/api/shared_spaces/{_defaultSharespaceId}/workspaces/{_defaultWorkspace.id}/tests";
            if (!string.IsNullOrEmpty(parameters)) url += "?" + parameters;
            var response = await _httpClient.GetAsync(url);
            Tests tests = await response.Content.ReadAsAsync<Tests>();
            if (withscript)
            {
                //get test script for each test
                foreach (Test test in tests.data)
                {
                    if (!string.IsNullOrEmpty(test.script_path))
                        test.script = (await GetTestScript(test.id)).script;
                }
            }
            return tests;
        }
        public async Task<Tests> GetMyTests()
        {
            var query = "owner={id=" + _currentUser.id + "};phase={metaphase={(name EQ 'New' || name EQ 'In Design')}};(subtype EQ 'test_manual'||subtype EQ 'gherkin_test')";            var expand = "$all{fields = name}";
            return await GetTests(string.Format("query=\"{0}\"&expand={1}", query, expand), true);
        }

        public async Task<TestScript> GetTestScript(int test_id)
        {
            var url = $"/api/shared_spaces/{_defaultSharespaceId}/workspaces/{_defaultWorkspace.id}/tests/" + test_id + "/script";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsAsync<TestScript>();
        }


        public async Task<Runs> GetRuns(string parameters = null, bool withsteps = false)
        {
            var url = $"/api/shared_spaces/{_defaultSharespaceId}/workspaces/{_defaultWorkspace.id}/runs";
            if (!string.IsNullOrEmpty(parameters)) url += "?" + parameters;
            var response = await _httpClient.GetAsync(url);
            Runs runs = await response.Content.ReadAsAsync<Runs>();

            if (withsteps)
            {
                //get run steps for each run
                foreach (Run run in runs.data)
                {
                    if (run.steps_num>0)
                        run.steps = await GetRunSteps(run.id);
                }
            }
            return runs;
        }
        public async Task<Runs> GetMyRuns()
        {
            var query = "run_by={id=" + _currentUser.id + "};(native_status={logical_name EQ 'list_node.run_native_status.planned' }||native_status={logical_name EQ 'list_node.run_native_status.blocked'}||native_status={logical_name EQ 'list_node.run_native_status.not_completed'});((parent_suite={null};subtype EQ 'run_manual')||(subtype EQ 'run_suite'))";            var expand = "$all{fields = name}";
            return await GetRuns(string.Format("query=\"{0}\"&skip_subtype_filter={1}&expand={2}", query, true, expand), true);
        }

        public async Task<Run_Steps> GetRunSteps(int run_id)
        {
            var url = $"/api/shared_spaces/{_defaultSharespaceId}/workspaces/{_defaultWorkspace.id}/run_steps" + "?query=\"run={id=" + run_id + "}\"";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsAsync<Run_Steps>();
        }

    }
}