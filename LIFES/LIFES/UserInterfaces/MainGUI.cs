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
        private void DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
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
            System.IO.StreamReader fileToPrint;
            System.Drawing.Font printFont;

            string printPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileToPrint = new System.IO.StreamReader(printPath + @"\test.txt");
            printFont = new System.Drawing.Font("Arial", 10);
            //printDocument1.Print();
            fileToPrint.Close();

            // The following code will render a simple 
            // message on the printed document. 
            //testing
            string text = "<==============3";
            //System.Drawing.Font printFont = new System.Drawing.Font
              //  ("Arial", 35, System.Drawing.FontStyle.Regular);

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
        private void EnrollmentButton_Click(object sender, EventArgs e)
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
          
        }

        /*
         * Method: FinalizeScheduleToolStripMenuItem_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 5/3/2015
         * Modified By: Jeffrey Allen
         * 
         * Description: Event handler for the Admin menu button Finalize. 
         */
        private void FinalizeScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.adminApproved = true;
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
        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginGUI = new LoginForm(this, adminToolStripMenuItem);
            this.Hide();
            loginGUI.StartPosition = FormStartPosition.CenterScreen;
            loginGUI.ShowDialog();
            
        }

        /*
         * Method: MilitaryToDateTime
         * Parameters: int (Military Time)
         * Output: DateTime
         * Created By: Riley Smith
         * Date: 5/3/2015
         * Modified By: Riley Smith
         * 
         * Description: Converts a MilitaryTime int to a standard DateTime.
         * 
         * Source:
         * http://forums.asp.net/t/1503263.aspx?How+to+convert+integer+representing+military+time+into+DateTime+object
         */
         public static DateTime MilitaryToDateTime(int time)
        {
            int Hours = time / 100;
            int Minutes = time - Hours * 100;
            DateTime Result = DateTime.MinValue;
            Result = Result.AddHours(Hours);
            Result = Result.AddMinutes(Minutes);

            
            return Result;
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
         * Method: DisplaySchedule
         * Parameters: FinalExam[] exams
         * Output: N/A
         * Created By: Scott Smoke, Riley Smith
         * Date: 5/4/2015
         * Modified By: Scott Smoke, Jordan Beck
         * 
         * Description: This displays the final exam
         * schedule to the table.
         * 
         */ 
        private void DisplaySchedule(FinalExamDay[] exams)
        {
            examTable.Rows.Clear();
            int rowIndex = 0;
            foreach (FinalExamDay ele in Globals.examWeek)
            {
                foreach (FinalExam exam in ele.GetExams())
                {
                  
                    examTable.Rows.Add();
                    string classTimes = "";
                    CompressedClassTime compressedTime = exam.GetCompressedClass();
                    // Get group of compressed class times.
                    CompressedClassTime lunchCompress = exam.GetCompressedClass();

                    if (lunchCompress.GetDayOfTheWeek() == "Lunch")
                    {
                        classTimes += "Lunch";
                    }
                    foreach (ClassTime time in compressedTime.GetClassTimes())
                    {
                       
                            classTimes += time.GetDayOfTheWeek() + " ";
                            classTimes += MilitaryToDateTime(time.GetClassStartTime()).
                                ToString("hh:mm tt") + "-";
                            classTimes += MilitaryToDateTime(time.GetClassEndTime()).
                                ToString("hh:mm tt") + "\n";
                        
                    }
                    string examTimes = "";
                    examTimes += MilitaryToDateTime(exam.GetStartTime()).ToString("hh:mm tt")
                        + "-" + MilitaryToDateTime(exam.GetEndTime()).ToString("hh:mm tt");
                    examTable.Rows[rowIndex].Cells[0].Value = ele.GetDay();
                    examTable.Rows[rowIndex].Cells[1].Value = classTimes;
                    examTable.Rows[rowIndex].Cells[2].Value = examTimes;
                    rowIndex++;
                }

            }
        }

        /*
         * Method: Reschedule_Click
         * Parameters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * 
         * Description: Event handler for the button Reschedule.
         */
        private void Reschedule_Click(object sender, EventArgs e)
        {
            Scheduler examSchedule = new Scheduler(Globals.compressedTimes, Globals.timeConstraints);
            examSchedule.ReSchedule();
            Globals.examWeek = examSchedule.GetExams();
            Debug.Write(examSchedule.GetExamSlots());
            if (Globals.examWeek != null && Globals.timeConstraints != null && Globals.compressedTimes != null)
            {
                DisplaySchedule(Globals.examWeek);
            }
            if (examSchedule.GetErrorMessage() != null)
            {
                MessageBox.Show(examSchedule.GetErrorMessage());
            }
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
        private void ResetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void Schedule_Click(object sender, EventArgs e)
        {
            Scheduler examSchedule = new Scheduler(Globals.compressedTimes, Globals.timeConstraints);
            examSchedule.Schedule();
            Globals.examWeek = examSchedule.GetExams();
            Debug.Write(examSchedule.GetExamSlots());
            if (Globals.examWeek != null && Globals.timeConstraints !=null && Globals.compressedTimes !=null)
            {
                DisplaySchedule(Globals.examWeek);
            }
            if (examSchedule.GetErrorMessage() != null)
            {
                MessageBox.Show(examSchedule.GetErrorMessage());
            }
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
        private void TimeConstraintsButton_Click(object sender, EventArgs e)
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
         * Modified By: Jordan Beck
         * 
         * Description: Event handler for the menu
         *  button View Total Enrollments.
         */
        private void ViewTotalEnrollments_Click(object sender, EventArgs e)
        {
            ViewTotalEnrollmentsForm totalEnrollmentForm = 
                new ViewTotalEnrollmentsForm();
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
         * Modified By: Jordan Beck
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
        * Description: This will launch the log in form when 
        *  the application launches.
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
        * Modified By: Jordan Beck
        * 
        * Description: This button will swap two exam periods within
        *              the main window
        */ 
        private void SwapButton_Click(object sender, EventArgs e)
        {
            if (examTable.SelectedRows.Count == 2)
            {
                string firstIndex = 
                    examTable.SelectedRows[0].Cells[1].Value.ToString();
                string secondIndex = 
                    examTable.SelectedRows[1].Cells[1].Value.ToString();
                string tmpString = firstIndex;

                if (firstIndex == "Lunch" || secondIndex == "Lunch")
                {

                    MessageBox.Show("Cannot Swap a Lunch Period", "Error");
                }

                else
                {
                    examTable.SelectedRows[0].Cells[1].Value = secondIndex;
                    examTable.SelectedRows[1].Cells[1].Value = tmpString; 
                }
                       
            }

            else
            {
                MessageBox.Show("Must have 2 selected rows");
            }
        }

        /*
        * Method: OpenButton_Click
        * Paramters: object Sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 5/1/2015
        * Modified By: Jeffrey Allen
        * 
        * Description: When this button is clicked 
        *   an open file dialog will open and allow
        *   the user to enter a file name or select a file.
        * Sources: msdn.Microsoft.com
        */
        private void OpenButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)| *.txt|" +
            "Comma Separated Values (*.csv) |*.csv| pdf (*.pdf) |*.pdf";
            openFile.Title = "Open an Exam Schedule";
            openFile.ShowDialog();
            string filename = openFile.FileName;

            // Check if file exists
            if (File.Exists(filename))
            {
                FileIn inputFile = new FileIn(filename);
    
                inputFile.ReadOutput(openFile.FileName);
            }


        }

      /*
       * Method: examTable_SelectionChanged
       * Paramters: object Sender, EventArgs e
       * Output: N/A
       * Created By: Riley Smith
       * Date: 5/1/2015
       * Modified By: Riley Smith
       * 
       * Description: Event handler for when the selected row 
       *    in examTable changes.
       *    Limits the number of selected rows to two.
       */
        private void ExamTable_SelectionChanged(object sender, EventArgs e)
        {
            if (examTable.SelectedRows.Count > 2)
            {
                for (int i = 2; i < examTable.SelectedRows.Count; i++)
                {
                    examTable.SelectedRows[i].Selected = false;

                }
            }
        }

        /*
         * Method: DisplaySingleDay
         * Paramters: int 
         * Output: N/A
         * Created By: Riley Smith
         * Date: 5/4/2015
         * Modified By: Riley Smith
         * 
         * Description: Display only the exams on the day that was 
         *      sent in as a parameter.
         */
        private void DisplaySingleDay(int day)
        {
            examTable.Rows.Clear();
            int rowIndex = 0;
            foreach (FinalExamDay ele in Globals.examWeek)
            {
                if (ele.GetDay() == day)
                {
                    foreach (FinalExam exam in ele.GetExams())
                    {
                        examTable.Rows.Add();
                        string classTimes = "";
                        CompressedClassTime compressedTime = exam.GetCompressedClass();
                        // Get group of compressed class times.
                        CompressedClassTime lunchCompress = exam.GetCompressedClass();

                        if (lunchCompress.GetDayOfTheWeek() == "Lunch")
                        {
                            classTimes += "Lunch";
                        }
                        foreach (ClassTime time in compressedTime.GetClassTimes())
                        {

                            classTimes += time.GetDayOfTheWeek() + " ";
                            classTimes += MilitaryToDateTime(time.GetClassStartTime()).
                                ToString("hh:mm tt") + "-";
                            classTimes += MilitaryToDateTime(time.GetClassEndTime()).
                                ToString("hh:mm tt") + "\n";

                        }
                        string examTimes = "";
                        examTimes += MilitaryToDateTime(exam.GetStartTime()).ToString("hh:mm tt")
                            + "-" + MilitaryToDateTime(exam.GetEndTime()).ToString("hh:mm tt");
                        examTable.Rows[rowIndex].Cells[0].Value = ele.GetDay();
                        examTable.Rows[rowIndex].Cells[1].Value = classTimes;
                        examTable.Rows[rowIndex].Cells[2].Value = examTimes;
                        rowIndex++;
                    }
                }
            }
        }

       /*
        * Method: Day1ToolStripMenuItem_Click
        * Paramters: object sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 5/4/2015
        * Modified By: Riley Smith
        * 
        * Description: Event handler for View -> Single Exam Day -> Day 1
        * 
        */
        private void Day1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.timeConstraints.GetNumberOfDays() >= 1
                && Globals.examWeek != null)
            {
                DisplaySingleDay(1);
            }
        }

        /*
        * Method: Day1ToolStripMenuItem_Click
        * Paramters: object sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 5/4/2015
        * Modified By: Riley Smith
        * 
        * Description: Event handler for View -> Single Exam Day -> Day 1
        * 
        */
        private void Day2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.timeConstraints.GetNumberOfDays() >= 2
                && Globals.examWeek != null)
            {
                DisplaySingleDay(2);
            }
        }

        /*
        * Method: Day1ToolStripMenuItem_Click
        * Paramters: object sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 5/4/2015
        * Modified By: Riley Smith
        * 
        * Description: Event handler for View -> Single Exam Day -> Day 1
        * 
        */
        private void Day3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.timeConstraints.GetNumberOfDays() >= 3
                && Globals.examWeek != null)
            {
                DisplaySingleDay(3);
            }
        }

        /*
        * Method: Day1ToolStripMenuItem_Click
        * Paramters: object sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 5/4/2015
        * Modified By: Riley Smith
        * 
        * Description: Event handler for View -> Single Exam Day -> Day 1
        * 
        */
        private void Day4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.timeConstraints.GetNumberOfDays() >= 4
                && Globals.examWeek != null)
            {
                DisplaySingleDay(4);
            }
        }

        /*
        * Method: Day1ToolStripMenuItem_Click
        * Paramters: object sender, EventArgs e
        * Output: N/A
        * Created By: Riley Smith
        * Date: 5/4/2015
        * Modified By: Riley Smith
        * 
        * Description: Event handler for View -> Single Exam Day -> Day 1
        * 
        */
        private void Day5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.timeConstraints.GetNumberOfDays() >= 5
                && Globals.examWeek != null)
            {
                DisplaySingleDay(5);
            }
        }

        /*
         * Method: FullExamWeekToolStripMenuItem_Click
         * Paramters: object sender, EventArgs e
         * Output: N/A
         * Created By: Riley Smith
         * Date: 5/4/2015
         * Modified By: Riley Smith
         * 
         * Description: Event handler for View -> Full Exam Week.
         *      Displays the exam schedule for the entire week.
         * 
         */
        private void FullExamWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplaySchedule(Globals.examWeek);
        }
    }
}

