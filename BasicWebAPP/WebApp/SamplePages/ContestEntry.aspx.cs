﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //due to the fact that this example is not using a database
        // to retai data, the following list<T> will serve as the 
        // page collection dataset
        //the list<T> is declared as static
        // the List<T> will remain active as long as the web application is running
        //the List<T> is created on the first presentation of this web page
        //warning! all users will have access to this list<t>

        static List<Entry> entries = new List<Entry>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            //check your Page.IsPostBack to see if this is the 
            //first presentation of the page (IsPostBack = false)
            if (!Page.IsPostBack)
            {
                EntryList.DataSource = entries;
                EntryList.DataBind();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //to execute the validation controls (not html5) on the server side 
            if (Page.IsValid)
            {
                if (Terms.Checked)
                {
                    //I could check the math anseer in my code behind
                    //but we will do that using validation controls

                    //record my entry
                    //collect all the entries and display them
                    //create an instance of the data class
                    Entry theEntry = new Entry();

                    //load the instance with data from the form
                    theEntry.FirstName = FirstName.Text;
                    theEntry.LastName = LastName.Text;
                    theEntry.StreetAddress1 = StreetAddress1.Text;
                    theEntry.StreetAddress2 = string.IsNullOrEmpty(StreetAddress2.Text) ? null : StreetAddress2.Text; //is nullable
                    theEntry.City = City.Text;
                    theEntry.Province = Province.SelectedValue; //ddl
                    theEntry.PostalCode = PostalCode.Text;
                    theEntry.EmailAddress = EmailAddress.Text;
                    //add the new instance to a collection of entries
                    entries.Add(theEntry);

                    //display the collection
                    //use a collection display control that displays 
                    //multiple separate columns: GridView
                    //requirements
                    //a) assign data source (DataSource)
                    //b) bind the data to the control
                    EntryList.DataSource = entries;
                    EntryList.DataBind();

                }
                else
                {
                    Message.Text = "You did not agree to the contest terms. Entry rejected";
                }
            }
           
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            CheckAnswer.Text = "";
            //ddl
            //physically position at the top
            Province.SelectedIndex = 0;
            //checkbox
            Terms.Checked = false;
        }
    }
}