using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //not worying abut validation in this example

            string msg = "";
            msg += "Name: " + FullName.Text;
            msg += " Email: " + EmailAddress.Text;
            msg += " Phone: " + Phone.Text;
            //ternary operator: 
            // condition ? true value : false value
            //always consider using the .SelectedValue over .SelectedIndex
            msg += " Time: " + (FullOrPartTime.SelectedValue == "1" ? " Full Time" : 
                               FullOrPartTime.SelectedValue == "2" ? " Part Time" : " Either");

            //handle the xheckboxlist
            //traverse the checkboxlist, review one item
            // at a time and add those items selected to the message
            //if no items were chosen, then add an appropriate message stating that no items were chosen.

            msg += " Jobs: ";
            //basic search of a list
            //set my found flag to "nothing found" (false)
            bool found = false;

            //loop processing
            //if something is found then set the found flag to true
            foreach(ListItem jobrow in JobList.Items)
            {
                //for each item in he collection
                if (jobrow.Selected)
                {
                    msg += jobrow.Text + " ";
                    found = true;
                }
            }

            //check your flag

            // not false => true
            if (!found)
            {
                msg += " You did not select a job. Application rejected.";
            }

            MessageLabel.Text = msg;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            Phone.Text = "";
            MessageLabel.Text = "";
            //for lists there are a couple of ways to reset
            //a) manually reset the control SelectionIndex
            // for the RadioButtonList, set the index -1
            FullOrPartTime.SelectedIndex = -1;
            //b) most list controls have a built in method to clear
            // this clearing can be the selection and/or the item contents
            JobList.ClearSelection();
        }
    }
}