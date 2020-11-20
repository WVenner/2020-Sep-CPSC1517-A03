
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Entities;
#endregion

namespace WebApp.SamplePages
{
    public partial class SimpleQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected void RegionSearch_Click(object sender, EventArgs e)
        {
            //verify input exists
            if (string.IsNullOrEmpty(RegionArg.Text))
            {
                MessageLabel.Text = "Enter a region id";
            }
            else
            {
                //you could do other validations suchas: numeruic check, range check, ...
                //standard lokkup
                try
                {
                    //connect to controller class by creating an instance
                    RegionController sysmgr = new RegionController();

                    //issue your call to the class instance
                    NorthwindSystem.Entities.Region info = sysmgr.Region_FindByID(int.Parse(RegionArg.Text));

                    //test results and either display record or an appropriate message
                    if (info == null)
                    {
                        //not found
                        MessageLabel.Text = "No region for supplied value";
                        RegionId.Text = "";
                        RegionDescription.Text = "";
                    }
                    else
                    {
                        //Region id is a pointer tot he label itself
                        //.Text is a property of the label instance which 
                        //allows one to change its contents.
                        RegionId.Text = info.RegionID.ToString();
                        RegionDescription.Text = info.RegionDescription;
                    }
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = $"Error: {ex.Message}";
                }
            }
        }
    }
}