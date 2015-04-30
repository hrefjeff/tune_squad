﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LIFES.FileIO;
using System.Collections;

namespace LIFES.UserInterfaces
{
    /*
     * Class Name: TimeConstraintsForm.cs
     * Author: Riley Smith
     * Date: 3/24/2015
     * Modified by: Riley Smith
     * 
     * Description: This is the driver class for the TimeConstraints GUI Window.
     * 
     * Initially generated by Visual Studio GUI builder.
     */
    public partial class TimeConstraintsForm : Form
    {
        //Constants Used for transition animations
        const int AW_SLIDE = 0X40000;
        const int AW_CENTER = 0x00000010;
        const int AW_BLEND = 0x00080000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_HIDE = 0x00010000;
        //const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        private TimeConstraints tc;
        private string filename;
        /*
         * 
         * 
         * 
         * 
         * 
         */ 
        public TimeConstraintsForm()
        {
            //tc = new TimeConstraints(0, 0, 0, 0, 0);
            InitializeComponent();
            numDaysTextBox.Text = Globals.timeConstraints.GetNumberOfDays().ToString();
            firstExamTimeTextBox.Text = Globals.timeConstraints.GetStartTime().ToString();
            lengthOfExamsTextBox.Text = Globals.timeConstraints.GetLengthOfExams().ToString();
            lengthBetweenExamsTextBox.Text = Globals.timeConstraints.GetTimeBetweenExams().ToString();
            lunchPeriodTextBox.Text = Globals.timeConstraints.GetLunchPeriod().ToString();
        }

        /*
         * Method: GetTimeConstraints
         * Parameters: N/A
         * Output: A TimeConstraints object
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified By: Scott Smoke
         * 
         * Description: This will return the time constraints that have been entered.
         * If no data was entered then it will construct an object with all zzeroes.
         */
        public TimeConstraints GetTimeConstraints()
        {
            return tc;
        }

        /*
         * Method: GetFileName
         * Paramters: N/A
         * Output: string
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified By: Scott Smoke
         * 
         * Description: Returns the string that user entered for the filename.
         */
        public string GetFileName()
        {
            return filename;
        }

        /*
         * Method: UpdateConstraintsButton_Click (update TimeConstraints)
         * Paramters: object Sender, EventArgs e
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified By: Riley Smith
         * Last Modified: 4/2/2015
         * 
         * Description: When this button is clicked the data that is in the form
         * get saved into the TimeConstraints variable.
         * If no data is entered then the TimeConstraints variable
         * data is all set to zero.
         * 
         */
        private void UpdateConstraintsButton_Click(object sender, EventArgs e)
        {
            if ((numDaysTextBox.Text != "") && (firstExamTimeTextBox.Text != "") &&
                (lengthOfExamsTextBox.Text != "") && (lengthBetweenExamsTextBox.Text != "") &&
                (lunchPeriodTextBox.Text != ""))
            {

                if (ValidateBoxes())
                {

                    TimeConstraints t = new TimeConstraints(Convert.ToInt32(numDaysTextBox.Text),
                    Convert.ToInt32(firstExamTimeTextBox.Text), Convert.ToInt32(lengthOfExamsTextBox.Text),
                    Convert.ToInt32(lengthBetweenExamsTextBox.Text), Convert.ToInt32(lunchPeriodTextBox.Text));
                    tc = t;

                    errorProvider1.Clear();
                    MessageBox.Show("Time Constraints Updated");
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Error with Time Constraints");
                }
            }

            else
            {
                // If a text box is empty, show a errorProvider.
                if (numDaysTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(numDaysTextBox, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(numDaysTextBox, "");
                }

                if (firstExamTimeTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(firstExamTimeTextBox, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(firstExamTimeTextBox, "");
                }

                if (lengthOfExamsTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(lengthOfExamsTextBox, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(lengthOfExamsTextBox, "");
                }

                if (lengthBetweenExamsTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(lengthBetweenExamsTextBox, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(lengthBetweenExamsTextBox, "");
                }

                if (lunchPeriodTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(lunchPeriodTextBox, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(lunchPeriodTextBox, "");
                }
                // End of errorProviders.

                TimeConstraints t = new TimeConstraints(0, 0, 0, 0, 0);
                tc = t;

            }
        }

        /*
         * Method: ChooseFileButton_Click (Open file)
         * Paramters: object Sender, EventArgs e
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified By: Scott Smoke
         * 
         * Description: When this button is clicked an open file dialog will open and allow
         *   the user to enter a file name or select a file.
         * Sources: msdn.Microsoft.com
         */
        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files |*.txt";
            openFile.Title = "Open Time Constraints Text File";
            openFile.ShowDialog();
            filename = openFile.FileName;
            if (filename != "")
            {
                FileIn fi = new FileIn(filename);
                if (fi.GetErrors().Count == 0)
                {
                    tc = fi.GetTimeConstraints();
                    //putting constraints on the display
                    numDaysTextBox.Text = tc.GetNumberOfDays().ToString();
                    firstExamTimeTextBox.Text = tc.GetStartTime().ToString();
                    lengthOfExamsTextBox.Text = tc.GetLengthOfExams().ToString();
                    lengthBetweenExamsTextBox.Text = tc.GetTimeBetweenExams().ToString();
                    lunchPeriodTextBox.Text = tc.GetLunchPeriod().ToString();
                }
                else
                {
                    string errors = Errors(fi.GetErrors());
                    MessageBox.Show(errors);
                }
            } 
            
        }

        /*
         * Method: OnLoad
         * Parameters: EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/30/2015
         * Modified By: Riley Smith
         * 
         * Override the function that loads the Form.
         * Animates the window as it opens.
         */
        protected override void OnLoad(EventArgs e)
        {
            AnimateWindow(this.Handle, 200, AW_CENTER | AW_HOR_POSITIVE);
        }
        /*
         * Method:  Errors
         * Parameters: ArrayList
         * Output: string
         * Created By: Scott Smoke
         * Date: 4/16/2015
         * Modified By: Scott Smoke
         * 
         * Description: This will return a string that will be created useing
         * the incomming list.
         * 
         * 
         * 
         */
        private string Errors(ArrayList list)
        {
            string errors = "";
            foreach (string str in list)
            {
                errors = errors + str + "\r\n";
            }
            return errors;
        }

        /*
         * Method: ValidateBoxes
         * Parameters: N/A
         * Output: bool
         * Created By: Riley Smith
         * Date: 4/29/2015
         * Modified By: Riley Smith
         * 
         * Checks to see if the data in the textBoxes are valid.
         * Returns true or false.
         */
        private bool ValidateBoxes()
        {
            bool flag = true;

            if (numDaysTextBox.Text != "3" && numDaysTextBox.Text != "4" && numDaysTextBox.Text != "5")
            {
                flag = false;
            }
    
            if (firstExamTimeTextBox.Text != "0700" && firstExamTimeTextBox.Text != "700")
            {
                flag = false;
            }

            int number;  
            if (Int32.TryParse(lengthOfExamsTextBox.Text, out number))
            {
                if (number < 75 || number > 300)
                {
                    flag = false;
                }
            }

            else
            {
                return false;
            }

            if (Int32.TryParse(lengthBetweenExamsTextBox.Text, out number))
            {
                if (number < 10 || number > 30)
                {
                    flag = false;
                }
            }

            else
            {
                return false;
            }

            if (Convert.ToInt32(lunchPeriodTextBox.Text) < 0)
            {
                flag = false;
            }

            return flag;
            
        }

    }
}
