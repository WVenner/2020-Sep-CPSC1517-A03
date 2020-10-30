using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class CommonControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this method executes BEFORE any event method on 
            // each processing of this web page

            //this is a great place to do common code that is required
            //on each process of the page
            //example: empty out old messages
            MessageLabel.Text = "";

            //this is an excellent place o do page initialization
            //of controls on the first pass
            //checking the first time for this page uses the post back flag
            //Pae.IsPostBack; this is a boolean value(true or false)
            if (!Page.IsPostBack) //if(!false) => true
            {
                //if the page is not PostBack, i means that this is the first
                //time the page has been displayed

                //simulate the loading of the dropdownlist via a 
                //datase from a database call

                //create a collectio of instances (class objects)
                // that will be used to load the dropdownlist
                //each instance will represent a record on the 
                //database dataset
                //to accomplish this simulation, we will create a class
                // and use it with a List<T>
                //the <T> in this example is the class DDLData
                List<DDLData> DDLCollection = new List<DDLData>();
                DDLData aninstance = new DDLData();
                aninstance.ValueId = 1;
                aninstance.DisplayText = "COMP 1008";
                DDLCollection.Add(aninstance);
                aninstance = new DDLData(3, "DMIT1508");
                DDLCollection.Add(aninstance);
                DDLCollection.Add(new DDLData(4, "DMIT2018"));
                DDLCollection.Add(new DDLData(2, "CPSC1517"));

                //sorting of a List<T>
                // (x,y) are placeholders representing any 2 records  at any given 
                //time during the sort
                // => (lambda symbol) is part of the delegate syntax, I suggest
                // that you read this symbol as "do the following"
                //comparing x to y is ascending
                //comparing y to x is descending
                DDLCollection.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));

                //place the data collection set into the dropdownlist control
                //3 steps to this process

                //a) assign the data collection set to the control
                CollectionList.DataSource = DDLCollection;

                //b) in this step you will assign the value that will
                // be displayed to the user and the value that will be associaed
                // and return from the control
                // when the user picks a particular selection
                //in the <select> control, this data was setup using the <option> tag
                //this information is assigned to the DDL control by use of the property name in your collection

                //2 styles
                // a) physical string of the field name
                CollectionList.DataValueField = "ValueId";
                // b) OOP style coding
                CollectionList.DataTextField = nameof(DDLData.DisplayText);

                //c) bind our data source to your control
                CollectionList.DataBind();

                //d) optionally
                //add a prompt line to your dropdownlist
                CollectionList.Items.Insert(0, new ListItem("select ...", "0"));
            }
        }

        protected void SubmitNumberChoice_Click(object sender, EventArgs e)
        {
            int numberchoice = 0;
            //validation checking that I have good data for my choice
            if (string.IsNullOrEmpty(NumberChoice.Text))
            {
                MessageLabel.Text = "Enter a number from 1 to 4";
            }
            else if(!int.TryParse(NumberChoice.Text, out numberchoice))
            {
                MessageLabel.Text = "Invalid number. Enter a number from 1 to 4";
            }
            else if(numberchoice < 1 || numberchoice > 4)
            {
                MessageLabel.Text = "Number is out of range. Enter a number from 1 to 4";
            }
            else
            {
                //good input data

                //RadioButtonList
                //assogm a value to the radiobuttonlis to indicate the item choice
                //is based on the input data value
                //this can be done using either .SelectedValue or .SelectedIndex
                //.SelectedValue will match the control item value to the argument value (BEST TO USE)
                //.SelectedIndex selects the control item to show based on the numerical index value (FOR PHYSICAL POSITIONING ONLY

                //RadioButtonListChoice.SelectedValue = numberchoice.ToString();
                RadioButtonListChoice.SelectedValue = NumberChoice.Text;

                //set the checkbox
                //checkbox is a boolean set
                if(numberchoice == 2 || numberchoice == 4)
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                //position in CollcectionList on the selected item row
                //this can be done using either .SelectedValue or .SelectedIndex
                //.SelectedValue will match the control item value to the argument value (BEST TO USE)
                //.SelectedIndex selects the control item to show based on the numerical index value (FOR PHYSICAL POSITIONING ONLY
                CollectionList.SelectedValue = numberchoice.ToString();

                //creae a message to display in the read only label control
                //access the data from the dropdownlist/radiobuttonlist

                //this can be done using either .SelectedValue or .SelectedIndex
                //third option: .SelectedItem:
                //

                //.SelectedValue will return the value associated with the selected item from the dropdownlist (value of he row)
                //.SelectedIndex will return the indedx of the rows selected in the dropdownlist (is the physical index potiotions of the row)
                //.SelectedItem will return the display text associated with the selected item from the drpdownlist (is the display text)
                DisplayReadonly.Text = CollectionList.SelectedItem.Text +
                    " at index " + CollectionList.SelectedIndex +
                    " having a vlue of " + CollectionList.SelectedValue +
                    ". This Matches the radio button choice item value " +
                    RadioButtonListChoice.SelectedValue +
                    " located at radiobuttonlist index " + 
                    RadioButtonListChoice.SelectedIndex;
            }
        }
    }
}