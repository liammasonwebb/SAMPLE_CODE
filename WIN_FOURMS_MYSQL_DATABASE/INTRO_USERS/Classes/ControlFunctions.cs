using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace INTRO_USERS
{
    class ControlFunctions
    {

        //It checks that the Instructor has not assigned more than 8 hours per Day
        public static bool checkMaximumHoursPerDay(ListView myListView, DateTime myDate, string instructor)
        {
            bool hoursLower8 = true;



            return hoursLower8;
        }

        //It clears columns and items from the listview
        public static void clearListViewReport(ListView myListView)
        {
            myListView.Columns.Clear();
            myListView.Items.Clear();
        }

        //It creates the Subitems of a ListView
        public static void createListViewSubitems(ListView myListView, string[][] myArray)
        {
            //It copies the arrays to the listview items
            for (int i = 0; i < myListView.Items.Count; i++)
            {
                myListView.Items[i].SubItems.AddRange(myArray[i]);
            }
        }

        //It creates the Items of a ListView
        public static void createListViewItems(ListView myListView, List<string> myItems)
        {
            for (int i = 0; i < myItems.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(myItems[i]);
                myListView.Items.Add(lvi);
            }
        }

        //It recalculates the totals of the Listview. It receives a LV with totals in rows and columns
        public static void recalculateTotal(ListView myListView, int row, int col, int value)
        {
            if (value == 0)
            {
                //It substracts 1 to the Column Total of the selected position
                int newColumnTotal = int.Parse(myListView.Items[myListView.Items.Count - 1].SubItems[col].Text) - 1;
                myListView.Items[myListView.Items.Count - 1].SubItems[col].Text = newColumnTotal.ToString();
                //It substracts 1 to the Row Total
                int newRowTotal = int.Parse(myListView.Items[row].SubItems[myListView.Columns.Count - 1].Text) - 1;
                myListView.Items[row].SubItems[myListView.Columns.Count - 1].Text = newRowTotal.ToString();
                //It calculates the Total of the LV
                int newLVTotal = int.Parse(myListView.Items[myListView.Items.Count - 1].SubItems[myListView.Columns.Count - 1].Text) - 1;
                myListView.Items[myListView.Items.Count - 1].SubItems[myListView.Columns.Count - 1].Text = newLVTotal.ToString();
            }
            else
            {
                //It substracts 1 to the Column Total of the selected position
                int newColumnTotal = int.Parse(myListView.Items[myListView.Items.Count - 1].SubItems[col].Text) + 1;
                myListView.Items[myListView.Items.Count - 1].SubItems[col].Text = newColumnTotal.ToString();
                //It adds 1 to the Row Total
                int newRowTotal = int.Parse(myListView.Items[row].SubItems[myListView.Columns.Count - 1].Text) + 1;
                myListView.Items[row].SubItems[myListView.Columns.Count - 1].Text = newRowTotal.ToString();
                //It calculates the Total of the LV
                int newLVTotal = int.Parse(myListView.Items[myListView.Items.Count - 1].SubItems[myListView.Columns.Count - 1].Text) + 1;
                myListView.Items[myListView.Items.Count - 1].SubItems[myListView.Columns.Count - 1].Text = newLVTotal.ToString();
            }
        }

        //It creates the Columns of a ListView
        public static void createListViewColumns(ListView myListView, string firstColumnTitle, List<string> myColumns, string lastColumnTitle, int fCWidth, int cWidth, int lCWidth)
        {
            myListView.Columns.Add(firstColumnTitle);
            myListView.Columns[0].Width = fCWidth;
            for (int i = 0; i < myColumns.Count; i++)
            {
                myListView.Columns.Add(myColumns[i]);
                myListView.Columns[i + 1].Width = cWidth;
                myListView.Columns[i + 1].TextAlign = HorizontalAlignment.Center;
            }
            if (lastColumnTitle != "")
            {
                myListView.Columns.Add(lastColumnTitle);
                myListView.Columns[myListView.Columns.Count - 1].Width = lCWidth;
                myListView.Columns[myListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            }
            //It resizes the columns width
            //myListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //myListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //for (int i = 0; i < myListView.Columns.Count; i++)
            //{
            //    myListView.Columns[i].Width = 70;
            //}
        }

        //It changes the value of a Subitem in the a Listview
        public static void changeListViewSubItemValue(ListView myListView, int row, int col, string value)
        {
            //It writes the new value in the corresponding Subitem
            myListView.Items[row].SubItems[col].Text = value.ToString();
        }

        //It gets the data contained in a ListView and delivers an array of arrays
        public static string[][] obtainDataFromListView(ListView myListView)
        {
            //It creates the array of arrays to contain the data from the ListView
            string[][] LVMatrix = new string[myListView.Columns.Count][];
            for (int i = 0; i < myListView.Columns.Count; i++)
            {
                LVMatrix[i] = new string[myListView.Items.Count];
            }
            //It fills in the arrays
            for (int i = 0; i < myListView.Columns.Count; i++)
            {
                for (int j = 0; j < myListView.Items.Count; j++)
                {
                    //It gets the data from the ListView
                    LVMatrix[i][j] = myListView.Items[j].SubItems[i].Text;
                }
            }
            return LVMatrix;
        }

        //It checks if they text controls have data in them
        public static bool checkTextControls( Form myForm)
        {
            bool holdsData = true;
            //It goes through all of the controls
            foreach (Control c in myForm.Controls)
            {
                //if its a textbox or a combobox
                if (c is TextBox || c is ComboBox)
                {
                    //It checks if the control is enabled due to the User Type selection
                    if (c.Enabled == true)
                    {
                        //If it is not the case that it is empty
                        //if ("".Equals((c as TextBox).Text.Trim()))
                        if ("".Equals(c.Text.Trim()))
                        {
                            //It sets boolean to false because on control is empty
                            holdsData = false;
                            c.BackColor = Color.LightCoral;
                        }
                        else
                        {
                            c.BackColor = Color.White;
                        }
                    }
                }
            }
            //It returns true or false based on if data is in all text boxes or not
            return holdsData;
        }

        //It populates a combo with the elements of the list
        public static void populateCombo(ComboBox myCombo, List<string> myList)
        {
            int i = 0;
            foreach (string element in myList)
            {
                myCombo.Items.Add(myList[i]);
                i++;
            }
        }

        //It formats a date to SQL format: yyyy-mm-dd
        public static string formatToSQLDate(DateTime myDate)
        {
            return myDate.Year.ToString() + "-" + myDate.Month.ToString() + "-" + myDate.Day.ToString();
        }

    }
}
