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
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

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
            tc = new TimeConstraints(0, 0, 0, 0, 0);
            InitializeComponent();

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
         * Modified By: Scott Smoke
         * 
         * Description: When this button is clicked the data that is in the form
         *  get saved into the TimeConstraints variable.
         *  If no data is entered then the TimeConstraints variable
         *  data is all set to zero.
         * 
         */
        private void UpdateConstraintsButton_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") &&
                (textBox3.Text != "") && (textBox4.Text != "") &&
                (textBox5.Text != ""))
            {
                TimeConstraints t = new TimeConstraints(Convert.ToInt32(textBox1.Text),
                Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text),
                Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                tc = t;

                errorProvider1.Clear();
            }

            else
            {
                // If a text box is empty, show a errorProvider.
                if (textBox1.Text == string.Empty)
                {
                    errorProvider1.SetError(textBox1, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(textBox1, "");
                }

                if (textBox2.Text == string.Empty)
                {
                    errorProvider1.SetError(textBox2, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(textBox2, "");
                }

                if (textBox3.Text == string.Empty)
                {
                    errorProvider1.SetError(textBox3, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(textBox3, "");
                }

                if (textBox4.Text == string.Empty)
                {
                    errorProvider1.SetError(textBox4, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(textBox4, "");
                }

                if (textBox5.Text == string.Empty)
                {
                    errorProvider1.SetError(textBox5, "Cannot Be Empty");
                }

                else
                {
                    errorProvider1.SetError(textBox5, "");
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
            FileIn fi = new FileIn(filename);
            tc = fi.GetTimeConstraints();

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
            //this.Size = this.Owner.Size;
            this.Location = this.Owner.Location;

            AnimateWindow(this.Handle, 200, AW_CENTER | AW_HOR_POSITIVE);
        }

    }
}
