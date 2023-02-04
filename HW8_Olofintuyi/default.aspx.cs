using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW8_Olofintuyi
{
    
    public partial class _default : System.Web.UI.Page
    {
        
        static int totalHours = 0;
        static int totalCost = 0;
        static bool dormChecked = false;
        static bool mealPlanChecked = false;
        static bool footballTixChecked = false;
        string labelHours = string.Format(" {0}", totalHours);
        string labelCost = string.Format(" {0}", totalCost);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)        //For initial page creation
            {
                ListItem[] availableCourses = buildAvailableCourseList();
                lbxAvailableClasses.DataSource = availableCourses;
                lbxAvailableClasses.DataTextField = "Text";
                lbxAvailableClasses.DataValueField = "Value";
                lbxAvailableClasses.DataBind();

            }
           
        }

        
        

        private ListItem[] buildAvailableCourseList()
        {
            ListItem[] tempList = { new ListItem("CS 1301-4", "CS 1301-4"),
                                new ListItem("CS 1302-4", "CS 1302-4"),
                                new ListItem("CS 1303-4", "CS 1303-4"),
                                new ListItem("CS 2202-2", "CS 2202-2"),
                                new ListItem("CS 2224-2", "CS 2224-2"),
                                new ListItem("CS 3300-3", "CS 3300-3"),
                                new ListItem("CS 3301-1", "CS 3301-1"),
                                new ListItem("CS 3302-1", "CS 3302-1"),
                                new ListItem("CS 3340-3", "CS 3340-3"),
                                new ListItem("CS 4321-3", "CS 4321-3"),
                                new ListItem("CS 4322-3", "CS 4322-3")
                              };
            return tempList;
        }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            lblHours.Text = labelHours;
            lblCost.Text = labelCost;
            int count = 0;
            
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                ListItem li = CheckBoxList1.Items[i];
                if (li.Selected)
                {
                    if (li.Value == "Dorm") {
                        if (dormChecked == false)
                        {
                            dormChecked = true;
                            totalCost += 1000;
                        }
                    }

                    if (li.Value == "Meal Plan")
                    {
                        if (mealPlanChecked == false)
                        {
                            mealPlanChecked = true;
                            totalCost += 500;
                        }
                    }

                    if (li.Value == "Football Tix")
                    {
                        if (footballTixChecked == false)
                        {
                            footballTixChecked = true;
                            totalCost += 50;
                        }
                    }
                }
            }


            for (int i = lbxAvailableClasses.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = lbxAvailableClasses.Items[i];
                if (li.Selected)
                {
                    string creditHours = li.Value;
                    string b = string.Empty;
                    int ch = 0;
                    

                    for (int j = creditHours.Length - 1; j >= 0; j--)
                    {
                        if (Char.IsDigit(creditHours[j]))
                            b += creditHours[j];
                        break;
                    }

                    if (b.Length > 0)
                    {
                        ch = int.Parse(b);
                    }
                    count += ch;

                   
                    if (count <= 19)
                    {
                        lbxRegisteredClasses.Items.Add(li);

                        totalCost += (ch * 100);
                        totalHours += ch;
                        lblHours.Text = labelHours;
                        lblCost.Text = labelCost;

                        lbxAvailableClasses.Items.Remove(li);
                        
                    }
                    else
                    {

                        Label.Text = "You cannot register for more than 19 hours";
                    }

                }
            }
            
           
        }


        protected void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                ListItem li = CheckBoxList1.Items[i];
                if (li.Selected)
                {
                    if (li.Value == "Dorm")
                    {
                        if (dormChecked == true)
                        {
                            dormChecked = false;
                            totalCost -= 1000;
                        }
                    }

                    if (li.Value == "Meal Plan")
                    {
                        if (mealPlanChecked == true)
                        {
                            mealPlanChecked = false;
                            totalCost -= 500;
                        }
                    }

                    if (li.Value == "Football Tix")
                    {
                        if (footballTixChecked == true)
                        {
                            footballTixChecked = false;
                            totalCost -= 50;
                        }
                    }
                }
            }
            for (int i = lbxRegisteredClasses.Items.Count - 1; i >= 0; i--)
            {
                lblHours.Text = labelHours;
                lblCost.Text = labelCost;
                ListItem li = lbxRegisteredClasses.Items[i];
                if (li.Selected)
                {

                    lbxAvailableClasses.Items.Add(li);
                    
                    string creditHours = li.Value;
                    string b = string.Empty;
                    int ch = 0;
                    
                        for (int j = creditHours.Length - 1; j >= 0; j--)
                        {
                            if (Char.IsDigit(creditHours[j]))
                                b += creditHours[j];
                        break;
                        }

                    if (b.Length > 0) {
                        ch = int.Parse(b);
                            }
                    totalCost  -= (ch * 100);
                    totalHours -=  ch;
                    
                    lbxRegisteredClasses.Items.Remove(li);
                    

                }
                
            }
            lblHours.Text = labelHours;
            lblCost.Text = labelCost;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnMakeAvailable_Click(object sender, EventArgs e)
        {

            for (int i = lbxAvailableClasses.Items.Count - 1; i >= 0; i--)
            {
                string classNumber = classNumberInput.Text;
                string creditHours = creditHourInput.Text;
                int creditHoursNum = int.Parse(creditHours);
                string newCourse = string.Format("CS {0}-{1}", classNumber, creditHours);

                ListItem li =  new ListItem(newCourse, newCourse);
                if (alreadyExistsAvailable("CS " + classNumber)==false && alreadyExistsRegistered("CS " + classNumber) == false)
                {
                    if (creditHoursNum>0 && creditHoursNum < 11) {
                        lbxAvailableClasses.Items.Add(li);
                        Label2.Text = "";
                        break;
                    }
                    

                }
               
                    if (i == 0)
                    {
                    Label2.Text = "Not Added, Course Already Exists";
                    }
                
                
            }
        }

        
        protected void btnRemoveAvailable_Click(object sender, EventArgs e)
        {
            for (int i = lbxAvailableClasses.Items.Count - 1; i >= 0; i--)
            {
                string classNumber = classNumberInput.Text;
                string creditHours = creditHourInput.Text;
                string newCourse = string.Format("CS {0}-{1}", classNumber, creditHours);

                ListItem li = new ListItem(newCourse, newCourse);
                if (alreadyExistsAvailable("CS " + classNumber)==true )
                {
                    lbxAvailableClasses.Items.Remove(li);
                    break;
                }
                if(alreadyExistsRegistered("CS " + classNumber) == true)
                {
                    Label2.Text = "Not Added, Course Is Registered For";
                    break;
                }
                if (i == 0)
                {
                    Label2.Text = "Not Added, Course Does Not Exists";
                }
            }
        }

        protected Boolean alreadyExistsAvailable(string s1)
        {
            bool exist = false;
            for (int i = lbxAvailableClasses.Items.Count - 1; i >= 0; i--)
            {

                ListItem li = lbxAvailableClasses.Items[i];
                string[] seperateValues = li.Value.Split('-');
                if (s1.Equals(seperateValues[0]))
                {
                    exist = true;
                    break;
                }
                else
                {
                    exist =  false;
                }
               
            }
            return exist;
        }

        protected Boolean alreadyExistsRegistered(string s1)
        {
            bool exist = false;
            for (int i = lbxRegisteredClasses.Items.Count - 1; i >= 0; i--)
            {

                ListItem li = lbxRegisteredClasses.Items[i];
                string[] seperateValues = li.Value.Split('-');
                if (s1.Equals(seperateValues[0]))
                {
                    exist = true;
                    break;
                }
                else
                {
                    exist = false;
                }

            }
            return exist;
        }
    }
    }
