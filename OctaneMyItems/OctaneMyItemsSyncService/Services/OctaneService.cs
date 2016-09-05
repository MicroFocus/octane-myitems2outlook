using OctaneMyItemsSyncService.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OctaneMyItemsSyncService.Services
{
  public class OctaneService : IOctaneService
  {
    #region Private Fields

    private readonly string _octaneServer;
    private HttpClient _httpClient;

    private string _currentUserName;
    private User _currentUser;
    private SharedSpace _defaultSharespace;
    private Workspace _defaultWorkspace;

    private const string EXPAND_ALL = "expand=$all{{fields = name}}";

    #endregion

    #region Constructor

    public OctaneService(string octaneServer)
    {
      _octaneServer = octaneServer;
    }

    #endregion


    #region IOctaneGeneralService

    public User CurrentUser
    {
      get { return _currentUser; }
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

      _httpClient.DefaultRequestHeaders.Add("HPECLIENTTYPE", "HPE_REST_API_TECH_PREVIEW");
      _currentUserName = user;

      ResetQuery();
    }
    public async Task Logout()
    {
      _currentUser = null;
      _currentUserName = null;
      _defaultSharespace = null;
      _defaultWorkspace = null;

      var response = await _httpClient.PostAsync("/authentication/sign_out", null);
      response.EnsureSuccessStatusCode();
      _httpClient = null;
    }

    public async Task<SharedSpaces> GetSharedSpaces()
    {
      var response = await _httpClient.GetAsync("api/shared_spaces");
      return await response.Content.ReadAsAsync<SharedSpaces>();
    }
    public async Task<Workspaces> GetWorkspaces(int sharespaceId)
    {
      var response = await _httpClient.GetAsync($"/api/shared_spaces/{sharespaceId}/workspaces");
      return await response.Content.ReadAsAsync<Workspaces>();
    }

    public async Task SetDefaultSpace(SharedSpace sharespace, Workspace workspace)
    {
      var response = await _httpClient.GetAsync($"api/shared_spaces/{sharespace.id}/workspaces/{workspace.id}/workspace_users?query=\"name='{_currentUserName}'\"");
      var result = await response.Content.ReadAsAsync<Users>();
      _currentUser = result.data[0];

      _defaultSharespace = sharespace;
      _defaultWorkspace = workspace;

      ResetQuery();
    }

    #endregion

    #region IOctaneBacklogService

    public async Task<Backlog> GetBacklog(int id, bool byCurrentOwner)
    {
      var result = await GetBacklogs($"query=\"{GenerateIDQuery(id, byCurrentOwner)}\"&{EXPAND_ALL}", true);
      if (result?.data?.Count() > 0) return result.data[0];
      return null;
    }
    public async Task<Backlogs> GetBacklogs(string parameters = null, bool indetail = false)
    {
      var url = $"{QueryUrl}/work_items";
      if (!string.IsNullOrEmpty(parameters)) url += "?" + parameters;
      var response = await _httpClient.GetAsync(url);
      var backlogs = await response.Content.ReadAsAsync<Backlogs>();

      if (indetail)
      {
        //get test script for each test
        foreach (Backlog backlog in backlogs.data)
        {
          if (backlog.has_comments)
            backlog.comments = await GetBacklogComments(backlog.id);
        }
      }
      return backlogs;
    }
    public async Task<Backlogs> GetMyBacklogs()
    {
      return await GetBacklogs($"query=\"{QueryMyBacklogs}\"&{EXPAND_ALL}", true);
    }
    public async Task<Backlog> GetMyBacklog(int id)
    {
      var result = await GetBacklogs($"query=\"{QueryMyBacklogs};id={id}\"&{EXPAND_ALL}", true);
      if (result?.data?.Count() > 0) return result.data[0];
      return null;
    }
    public async Task<Comments> GetBacklogComments(int id)
    {
      return await GetComments("work_item", id);
    }

    #endregion

    #region IOctaneRunService

    public async Task<Run> GetRun(int id, bool byCurrentOwner)
    {
      var result = await GetRuns($"query=\"{GenerateIDQuery(id, byCurrentOwner)}\"&{EXPAND_ALL}", true);
      if (result?.data?.Count() > 0) return result.data[0];
      return null;
    }
    public async Task<Runs> GetRuns(string parameters = null, bool indetail = false)
    {
      var url = $"{QueryUrl}/runs";
      if (!string.IsNullOrEmpty(parameters)) url += "?" + parameters;
      var response = await _httpClient.GetAsync(url);
      Runs runs = await response.Content.ReadAsAsync<Runs>();

      if (indetail)
      {
        //get run steps for each run
        foreach (Run run in runs.data)
        {
          if (run.steps_num > 0)
            run.steps = await GetRunSteps(run.id);

          if (run.has_comments)
            run.comments = await GetRunComments(run.id);
        }
      }
      return runs;
    }
    public async Task<Runs> GetMyRuns()
    {
      return await GetRuns($"query=\"{QueryMyRuns}\"&skip_subtype_filter={true}&{EXPAND_ALL}", true);
    }
    public async Task<Run> GetMyRun(int id)
    {
      var result = await GetRuns($"query=\"{QueryMyRuns}\"&skip_subtype_filter={true}&{EXPAND_ALL}", true);
      if (result?.data?.Count() > 0) return result.data[0];
      return null;
    }
    public async Task<Comments> GetRunComments(int id)
    {
      return await GetComments("run", id);
    }
    public async Task<Run_Steps> GetRunSteps(int run_id)
    {
      var url = $"{QueryUrl}/run_steps?query=\"run={{id={run_id}}}\"";
      var response = await _httpClient.GetAsync(url);
      return await response.Content.ReadAsAsync<Run_Steps>();
    }

    #endregion

    #region IOctaneTestService

    public async Task<Test> GetTest(int id, bool byCurrentOwner)
    {
      var result = await GetTests($"query=\"{GenerateIDQuery(id, byCurrentOwner)}\"&expand=$all{{fields = name}}", true);
      if (result?.data?.Count() > 0) return result.data[0];
      return null;
    }
    public async Task<Tests> GetTests(string parameters = null, bool indetail = false)
    {
      var url = $"/api/shared_spaces/{_defaultSharespace.id}/workspaces/{_defaultWorkspace.id}/tests";
      if (!string.IsNullOrEmpty(parameters)) url += "?" + parameters;
      var response = await _httpClient.GetAsync(url);
      Tests tests = await response.Content.ReadAsAsync<Tests>();
      if (indetail)
      {
        //get test script for each test
        foreach (Test test in tests.data)
        {
          if (!string.IsNullOrEmpty(test.script_path))
            test.script = (await GetTestScript(test.id)).script;
          if (test.has_comments)
            test.comments = await GetTestComments(test.id);
        }
      }
      return tests;
    }
    public async Task<Tests> GetMyTests()
    {
      return await GetTests($"query=\"{QueryMyTests}\"&{EXPAND_ALL}", true);
    }
    public async Task<Test> GetMyTest(int id)
    {
      var result = await GetTests($"query=\"{QueryMyTests};id={id}\"&{EXPAND_ALL}", true);
      if (result?.data?.Count() > 0) return result.data[0];
      return null;
    }
    public async Task<Comments> GetTestComments(int id)
    {
      return await GetComments("test", id);
    }
    public async Task<TestScript> GetTestScript(int test_id)
    {
      var url = $"/api/shared_spaces/{_defaultSharespace.id}/workspaces/{_defaultWorkspace.id}/tests/" + test_id + "/script";
      var response = await _httpClient.GetAsync(url);
      return await response.Content.ReadAsAsync<TestScript>();
    }

    #endregion

    #region Properties

    private string queryUrl;
    public string QueryUrl
    {
      get { return queryUrl ??
          (queryUrl = $"/api/shared_spaces/{_defaultSharespace.id}/workspaces/{_defaultWorkspace.id}"); }
    }

    private string queryMyBacklogs;
    public string QueryMyBacklogs
    {
      get
      {
        return queryMyBacklogs ??
      (queryMyBacklogs = "owner={id=" + _currentUser.id + "};phase={metaphase={(name EQ 'New'|| name EQ 'In Progress' || name EQ 'In Testing')}};(subtype EQ 'defect'||subtype EQ 'story'||subtype EQ 'quality_story')");
      }
    }

    private string queryMyTests;
    public string QueryMyTests
    {
      get
      {
        return queryMyTests ??
      (queryMyTests = "owner={id=" + _currentUser.id + "};phase={metaphase={(name EQ 'New' || name EQ 'In Design')}};(subtype EQ 'test_manual'||subtype EQ 'gherkin_test')");
      }
    }

    private string queryMyRuns;
    public string QueryMyRuns
    {
      get
      {
        return queryMyRuns ??
      (queryMyRuns = "run_by={id=" + _currentUser.id + "};(native_status={logical_name EQ 'list_node.run_native_status.planned' }||native_status={logical_name EQ 'list_node.run_native_status.blocked'}||native_status={logical_name EQ 'list_node.run_native_status.not_completed'});((parent_suite={null};subtype EQ 'run_manual')||(subtype EQ 'run_suite'))");
      }
    }

    #endregion

    #region Private methods

    private void ResetQuery()
    {
      queryUrl = null;
      queryMyBacklogs = null;
      queryMyTests = null;
      queryMyRuns = null;
    }

    private async Task<Comments> GetComments(string owner_type, int owner_id)
    {
      var url = $"{QueryUrl}/comments";
      url += "?fields=id,author,text,last_modified,creation_time";
      url += "&expand=author{fields=name,full_name}";
      url += "&query=\"owner_" + owner_type + "={id=" + owner_id + "}\"";

      var response = await _httpClient.GetAsync(url);
      return await response.Content.ReadAsAsync<Comments>();
    }

    private string GenerateIDQuery(int id, bool byCurrentOwner)
    {
      var query = $"id={id}";
      if (byCurrentOwner) query += $";owner={{id={_currentUser.id}}}";
      return query;
    }

    #endregion
  }
}