namespace OctaneMyItems
{
  public partial class ThisAddIn
    {
        private static Configuration m_configuration;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
 
        m_configuration = new Configuration();
 
    }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }
        public static Configuration Configuration
        {
          get {                
                return m_configuration; 
            }
        }

        public static void GetConfiguration()
        {
      m_configuration.Getconfiguration();
       }
    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
      return new Ribbon2();
    }
    #region VSTO generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
  
}
