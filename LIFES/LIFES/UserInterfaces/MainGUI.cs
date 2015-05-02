﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIFES.FileIO;
using LIFES.Authentication;
using LIFES.Schedule;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace LIFES.UserInterfaces
{
    /*
     * Class Name: MainGUI.cs
     * 
     * Author: Riley Smith
     * Date: 3/24/2015
     * Modified by: Jordan Beck
     * 
     * Description: This is the driver class for the MainGUI Window.
     * 
     *   Initially generated by Visual Studio GUI builder.
     */
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();        
        }
        /*
        * Method: CloseToolStripMenuItem_Click
        * Parameters: object sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 3/26/2015
        * Modified By: Riley Smith
        * 
        * Description: Event handler for the menu button Close. 
        */
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
         * Method: CreateUserToolStripMenuItem_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 4/1/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the Admin menu button Create User. 
         */
        private void CreateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
                //DO stuff
                CreateUserForm createUser = new CreateUserForm();
                createUser.Owner = this;
                createUser.StartPosition = FormStartPosition.CenterScreen;
                createUser.ShowDialog();
       
        }

        /*
        * Method: DeleteUserToolStripMenuItem_Click
        * Parameters: object sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 4/1/2015
        * Modified By: Riley Smith
        * 
        * Description: Event handler for the Admin menu button Delete User. 
        */
        void DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                DeleteUserForm deleteUserForm = new DeleteUserForm();
                deleteUserForm.Owner = this;
                deleteUserForm.StartPosition = FormStartPosition.CenterScreen;
                deleteUserForm.ShowDialog();
          
        }

        /*
         * Method:  DocumentPrintPage
         * Parameters: object sender, 
         *             System.Drawing.Printing.PrintPageEventArgs e
         * Output: A printed document
         * Created By: Scott Smoke
         * Date: 3/26/2015
         * Modified By: Scott Smoke
         * 
         * Description: This will print a document.
         * Sources: msdn.microsoft.com
         */
        private void DocumentPrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            //print schedule
            // Insert code to render the page here. 
            // This code will be called when the control is drawn. 

            // The following code will render a simple 
            // message on the printed document. 
            //testing
            string text = "In DocumentPrintPage method.";
            System.Drawing.Font printFont = new System.Drawing.Font
                ("Arial", 35, System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(text, printFont,
                System.Drawing.Brushes.Black, 10, 10);
        }


        /*
         * Method: EnrollmentButton_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/24/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the button Total Enrollment. 
         */
        void EnrollmentButton_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentGUI = new EnrollmentForm();
            enrollmentGUI.Owner = this;

            //this.Hide();
            enrollmentGUI.StartPosition = FormStartPosition.CenterScreen;
            enrollmentGUI.ShowDialog();
            if (enrollmentGUI.GetYear() != null)
            {
                Globals.year = enrollmentGUI.GetYear();
            }
            //this.Show();
        }

        /*
         * Method: FinalizeScheduleToolStripMenuItem_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 4/1/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the Admin menu button Finalize. 
         */
        void FinalizeScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
       
           
               
            
            // Needs to be added
        }

       

        /*
         * Method: LoginToolStripMenuItem_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/26/2015
         * Modified By: Scott Smoke
         * 
         * Description: Event handler for the menu button Login. 
         */
        void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginGUI = new LoginForm(this, adminToolStripMenuItem);
            this.Hide();
            loginGUI.StartPosition = FormStartPosition.CenterScreen;
            loginGUI.ShowDialog();
            
        }

        /*
        * Method: PrintToolStripMenuItemClick 
        * Parameters: object sender, EventArgs e
        * Output: N/A
        * Created By: Scott Smoke
        * Date: 3/26/2015
        * Modified By: Scott Smoke
        * 
        * Description: This will display a print dialog and allow the user to
        *  select a printer.
        * Sources: msdn.miscrosoft.com
        *          http://stackoverflow.com/questions/15985909/show-print-dialog-before-printing
        */
        private void PrintToolStripMenuItemClick(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument docToPrint =
                new System.Drawing.Printing.PrintDocument();

            //event handler for the object
            docToPrint.PrintPage +=
                new System.Drawing.Printing.
                    PrintPageEventHandler(DocumentPrintPage);

            PrintDialog print = new PrintDialog();
            print.AllowSomePages = false;
            print.ShowHelp = true;
            print.Document = docToPrint;
            DialogResult result = print.ShowDialog();
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }

        /*
         * Method: Reschedule_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/24/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the button Reschedule.
         */
        void Reschedule_Click(object sender, EventArgs e)
        {
            examTable.Rows[0].Cells[0].Value = "Rescheduled First Class Time";
            examTable.Rows[0].Cells[1].Value = "Rescheduled First Exam Time";
        }

        /*
         * Method: ResetPasswordToolStripMenuItem_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 4/1/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the Admin menu button Reset Password. 
         */
        void ResetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                ResetPasswordForm resetForm = new ResetPasswordForm();
                resetForm.Owner = this;
                resetForm.StartPosition = FormStartPosition.CenterScreen;
                resetForm.ShowDialog();
           
        }

        /*
         * Method: SaveAsToolStripMenuItem_Click
         * Parameters: object sender, EventArgs e
         * Output: A filed saved in the requested format.
         * Created By: Scott Smoke
         * Date: 3/26/2015
         * Modified By: Scott Smoke
         * 
         * Description: This will allow the user to enter a file name and a save file type.
         * Source: msdn.microsoft.com
         *         http://stackoverflow.com/questions/11964955/how-to-check-what-filter-is-applied
         */
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)| *.txt|" +
            "Comma Sperateve Values (*.csv) |*.csv| pdf (*.pdf) |*.pdf";
            saveFile.ShowDialog();
            FileOut outFile = new FileOut(saveFile.FileName);
            //getting the filter the user selected from the menu
            switch (saveFile.FilterIndex)
            {
                case 1:
                    outFile.WriteToText();
                    break;
                case 2:
                    outFile.WriteToCSV();
                    break;
                case 3:
                    outFile.WriteToPDF();
                    break;
                default:
                    //error
                    break;
            }
        }

        /*
         * Method: Schedule_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/24/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the button Schedule.
         */
        void Schedule_Click(object sender, EventArgs e)
        {
            examTable.Rows.Add();
            examTable.Rows[0].Cells[0].Value = "MWF";
            examTable.Rows[0].Cells[1].Value = "8:00";
            examTable.Rows[1].Cells[0].Value = "TR";
            examTable.Rows[1].Cells[1].Value = "9:00";

            //Scheduler examSchedule = new Scheduler(Globals.compressedTimes, Globals.timeConstraints);
            //examSchedule.Schedule();
            //Debug.Write(examSchedule.GetExamSlots());


        }
        
        /*
         * Method: TimeConstraintsButton_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/24/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the button Time Contraints.
         */
        void TimeConstraintsButton_Click(object sender, EventArgs e)
        {
            TimeConstraintsForm timeConstraintsGUI = new TimeConstraintsForm();
            timeConstraintsGUI.Owner = this;
            
            //this.Hide();
            timeConstraintsGUI.StartPosition = FormStartPosition.CenterScreen;
            timeConstraintsGUI.ShowDialog();
            //this.Show();

            TimeConstraints tc = timeConstraintsGUI.GetTimeConstraints();
            if (tc != null)
            {
                Globals.timeConstraints = tc;
                Globals.timeConstraintsFileName = timeConstraintsGUI.GetFileName();
            }
           
        }

        /*
         * Method: ViewTotalEnrollments_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 4/8/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for the menu button View Total Enrollments.
         */
        private void ViewTotalEnrollments_Click(object sender, EventArgs e)
        {
            ViewTotalEnrollmentsForm totalEnrollmentForm = new ViewTotalEnrollmentsForm();
            totalEnrollmentForm.Owner = this;

            totalEnrollmentForm.StartPosition = FormStartPosition.CenterScreen;
            totalEnrollmentForm.ShowDialog();
        }

        /*
         * Method: OpenUserGuide_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Jeffrey Allen
         * Date: 4/13/2015
         * Modified By: Jeffrey Allen
         * 
         * Description: Event handler for the menu button Open User Guide.
         */
        private void OpenUserGuide_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\\Users\\eljeffeh\\UserManualLIFESV2test.pdf");
        }
       /*
        * Method: MainGUI_Load
        * Parameters: object sender, EventArgs e
        * Output: N/A
        * Created By: Scott Smoke
        * Date: 4/21/2015
        * Modified By: Scott Smoke
        * 
        * Description: This will launch the log in form when the application launches.
        */ 
        private void MainGUI_Load(object sender, EventArgs e)
        {
            LoginForm loginGUI = new LoginForm(this,adminToolStripMenuItem);
            //hides the main interface
            this.Hide();
            loginGUI.StartPosition = FormStartPosition.CenterScreen;
            loginGUI.ShowDialog();
        }

        /*
        * Method: SwapButton_Click
        * Parameters: object sender, EventArgs e
        * Output: N/A
        * Created By: Jeffrey Allen
        * Date: 4/30/2015
        * Modified By: 
        * 
        * Description: This button will swap two exam periods within
        *              the main window
        */ 
        private void SwapButton_Click(object sender, EventArgs e)
        {

        }

        /*
        * Method: OpenButton_Click
        * Paramters: object Sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 5/1/2015
        * Modified By: Riley Smith
        * 
        * Description: When this button is clicked an open file dialog will open and allow
        *   the user to enter a file name or select a file.
        * Sources: msdn.Microsoft.com
        */
        private void OpenButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)| *.txt|" +
            "Comma Sperateve Values (*.csv) |*.csv| pdf (*.pdf) |*.pdf";
            openFile.Title = "Open an Exam Schedule";
            openFile.ShowDialog();
            string filename = openFile.FileName;

        }

    }
}

