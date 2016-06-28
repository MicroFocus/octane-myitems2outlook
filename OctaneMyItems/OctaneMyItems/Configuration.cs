using System.Windows.Forms;

namespace OctaneMyItems
{
  public class Configuration
  {
    private string m_serverUrl;
    private string m_userName;
    private string m_password;
    private int m_sharedSpaceId;
    private string m_workSpace;

    public Configuration()
    {

    }
    public void Getconfiguration()
    {
      ConfigurationForm form = new ConfigurationForm();
      form.Show();
      if (form.DialogResult == DialogResult.OK)
      {
        m_serverUrl = form.ServerUrl;
        m_userName = form.User;
        m_password = form.Password;
        m_sharedSpaceId = form.SharedSpaceId;
        m_workSpace = form.WorkSpace;
      }

    }
    public bool Login()
    {
      return false;
    }
    public void Logout()
    { }
    public int SharedSpaceId
    {
      get
      {
        return m_sharedSpaceId;
      }
    }
    public string WorkSpace
    {
      get { return m_workSpace; }
    }
  }
}
