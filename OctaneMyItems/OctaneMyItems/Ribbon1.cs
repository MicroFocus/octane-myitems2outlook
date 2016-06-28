using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
namespace OctaneMyItems
{
  public partial class Ribbon1
  {
    private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
    {
      
    }

    private void SyncAll_Click(object sender, RibbonControlEventArgs e)
    {
      System.Windows.Forms.MessageBox.Show("Sync All");
    }
  }
}
