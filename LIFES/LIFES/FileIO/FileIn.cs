using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;
namespace LIFES.FileIO
{
    /*
     * Name:        FileIn
     * Author:      Joshua Ford
     * Created:     3/24/15
     * Modified by: Joshua Ford
     * Purpose:     Handles file input and validation of the constraints file.
     */
    class FileIn
    {
        // Class variable.
        private string[] lines = null;
        private ArrayList errors = new ArrayList();

        /*
         * Name:        FileIn
         * Author:      Joshua Ford
         * Created:     3/24/15
         * Modified by: Joshua Ford
         * Parameters:  fileName - The name of the file to be opened.
         * Output - No explicit retun.
         * Purpose:     Takes a filename as input and reads that file, then 
         *              returns an array of the lines in that file.
         */
        public FileIn(string fileName)
        {
            if (File.Exists(fileName))
            {
                SetLines(System.IO.File.ReadAllLines(fileName));
                IsValidConstraintsFile();
            }

            else
            {
                errors.Add("Error, the file specified could not be" 
                    + " found.");
            }
        }

        /*
         * Name:        validateConstraintsFile
         * Author(s):   Joshua Ford
         * Created:     3/31/15
         * Modified by: Joshua Ford
         * Parameters:  NONE
         * Output: good - A boolean value which is true if the constraints are
         *                valid and false otherwise.
         * Purpose:     This method runs a check on the constraints file 
         *              ensuring that the file data is in proper format and
         *              that the data itself is valid.
         */

        private bool IsValidConstraintsFile()
        {
            bool good = true;
            if (lines != null)
            {

                for (int i = 0; i < lines.Length; i++)
                {
                    if (!IsFileAllDigit(i))
                    {
                        good = false;
                    }

                    else if (i == 0)
                    {
                        if (lines[i] != "3" && lines[i] != "4" && lines[i] 
                            != "5")
                        {

                            errors.Add("Error on line 1: Incorrect number"
                            + " of day choice.");
                            good = false;
                        }
                    }

                    else if (i == 1)
                    {
                        if (lines[i] != "0700")
                        {

                            errors.Add("Error on line 2: Incorrect start"
                            + " time for final exams.");
                            good = false;
                        }
                    }

                    else if (i == 2)
                    {
                        if (Convert.ToInt16(lines[i]) < 75 ||
                            Convert.ToInt16(lines[i]) > 300)
                        {

                            errors.Add("Error on line 3: Incorrect exam"
                            + " time.");
                            good = false;
                        }
                    }

                    else if (i == 3)
                    {
                        if (Convert.ToInt16(lines[i]) < 10 ||
                            Convert.ToInt16(lines[i]) > 30)
                        {

                            errors.Add("Error on line 4: Incorrect time"
                            + " between final exams.");
                            good = false;
                        }
                    }
                }
            }
            else
            {
                good = false;
            }
            return good;
        }

        /*
         * Name:        IsFileAllDigit
         * Author(s):   Joshua Ford
         * Created:     4/1/15
         * Modified by: Scott Smoke
         * Parameters:  lineNum - The line number being checked.
         * Output: digit - Returns true if the passed parameter is a digit and
         *                 returns false otherwise.
         * Purpose:     Check a single line to make sure the string is in 
         *              digit form.
         */

        private bool IsFileAllDigit(int lineNum)
        {
            int numVal = -1;
            bool digit = true;

            try
            {
                numVal = Convert.ToInt16(lines[lineNum]);
            }
            catch (FormatException e)
            {
                errors.Add("Line " + (lineNum + 1) + " " + e.Message);
                digit = false;
            }
            return digit;
        }

        /*
         * Name:        SetLines
         * Author:      Joshua Ford
         * Created:     3/25/15
         * Modified by: Joshua Ford
         * Parameters:  lines - An array of all lines in the file which was
         *                      opened.
         * Output: No explicit output.
         * Purpose: Acts as the setter for this class 
         * (Purpose should be pretty transparant).
         */
        public void SetLines(string[] lines)
        {
            if (lines.Length == 5)
            {
                this.lines = lines;
            }
            else
            {
                errors.Add("Incorrect File length");
            }
        }

        /*
         * Name:        getLines
         * Author:      Joshua Ford
         * Created:     3/25/15
         * Modified by: Joshua Ford
         * Parameters:  NONE
         * Output: tc - Returns time constraints.
         * Purpose: Acts as the getter for this class 
         *          (This should also be pretty obvious)
         */
        public TimeConstraints GetTimeConstraints()
        {
            TimeConstraints tc= null;
            if (lines != null)
            {
                tc = new TimeConstraints(Convert.ToInt32(lines[0]),
                Convert.ToInt32(lines[1]), Convert.ToInt32(lines[2]),
                Convert.ToInt32(lines[3]), Convert.ToInt32(lines[4]));        
            }
          
            return tc;
        }
        /*
         * Method: GetErrors
         * Created By: Scott Smoke
         * Date: 4/16/2015
         * Modified By: Scott Smoke
         * Parameters: N/A
         * Output: ArrayList containing the errors.
         * Description: This returns an ArrayList containg the found errors.
         */
        public ArrayList GetErrors()
        {
            return errors;
        }


        /*
        * Method: ReadFromCSV
        * Parameters: N/A
        * Output: Saved file in the CSV format
        * Created By: Jeffrey Allen
        * Date: 5/4/2015
        * Modified By: 
        * 
        * Description: Reads the data from an output CSV file
        *  
        */
        public void ReadOutput(string filename)
        {

            if (filename != "")
            {
                System.IO.StreamReader file =
                    new System.IO.StreamReader(filename);

                Globals.totalEnrollemntsFileName = filename;

                string[] splitFileName = filename.Split('.');
                string extention = splitFileName[1];
                string[] semesterAndYear;

                string semesterAndYearLine = file.ReadLine();

                if (extention == "csv")
                {
                    semesterAndYear = semesterAndYearLine.Split(',');
                }
                else
                {
                    semesterAndYear = semesterAndYearLine.Split(' ');
                }

                Globals.semester = semesterAndYear[0];
                Globals.year = semesterAndYear[1];

                // read enrollments file name
                Globals.totalEnrollemntsFileName = file.ReadLine();
                CompressedClassTimes ct = new CompressedClassTimes(Globals.totalEnrollemntsFileName);
                Globals.compressedTimes = ct.GetCompressedClassTimes();

                // read time constraints
                string days = file.ReadLine();
                string starttime = file.ReadLine();
                string lengthofexam = file.ReadLine();
                string btwclass = file.ReadLine();
                string lunchtime = file.ReadLine();

                TimeConstraints readConstraints = new TimeConstraints(Convert.ToInt32(days),
                                                    Convert.ToInt32(starttime), Convert.ToInt32(lengthofexam),
                                                    Convert.ToInt32(btwclass), Convert.ToInt32(lunchtime));

                Globals.timeConstraints = readConstraints;

                // read adminApproved
                string adminApp = file.ReadLine();
                
                Globals.adminApproved = Convert.ToBoolean(Convert.ToInt32(adminApp));
            }
        }

        /*
        * Method: ReadFromTxt
        * Parameters: N/A
        * Output: Saved file in the CSV format
        * Created By: Jeffrey Allen
        * Date: 5/4/2015
        * Modified By: 
        * 
        * Description: Reads the data from an output text file
        *
        */
        public void ReadFromTxt(string filename)
        { 
        
        if (filename != "")
            {

                System.IO.StreamReader file = 
                    new System.IO.StreamReader(filename);

                // read semester + year
                string firstLine = file.ReadLine();
                string[] s = firstLine.Split(' ');
                Globals.semester = s[0];
                Globals.year = s[1];

                // read enrollments file name
                Globals.totalEnrollemntsFileName = file.ReadLine();

                // read time constraints
                string days = file.ReadLine();
                string starttime = file.ReadLine();
                string lengthofexam = file.ReadLine();
                string btwclass = file.ReadLine();
                string lunchtime = file.ReadLine();

                TimeConstraints readConstraints = new TimeConstraints(Convert.ToInt32(days),
                                                    Convert.ToInt32(starttime), Convert.ToInt32(lengthofexam), 
                                                    Convert.ToInt32(btwclass), Convert.ToInt32(lunchtime));

                Globals.timeConstraints = readConstraints;

                // read adminApproved
                string adminApp = file.ReadLine();
                Globals.adminApproved = Convert.ToBoolean(adminApp);
                

                /*
                
                //place exam schedule
                foreach (FinalExamDay ele in Globals.examWeek)
                {
                    file.WriteLine("Day\t Class Times\t\t\t\t Exam Time");
                    file.Write(ele.GetDay());
              
                    foreach (FinalExam exam in ele.GetExams())
                    {
                        string classTime = "";
                        CompressedClassTime compressedTime = exam.GetCompressedClass();

                        classTime +=  compressedTime.GetClassTimes().
                            First().getDayOfTheWeek()
                            + " ";
                        classTime += MilitaryToDateTime(compressedTime.
                            GetClassTimes().First().getClassStartTime()).
                            ToString("hh:mm tt")
                            + "-";
                            classTime += MilitaryToDateTime(compressedTime.
                                GetClassTimes().First().getClassEndTime()).
                                ToString("hh:mm tt");

                        file.Write("\t\t" + classTime + "\t\t\t");

                        string examTimes = "";
                        examTimes += MilitaryToDateTime(exam.GetStartTime()).
                            ToString("hh:mm tt")
                            + "-" + MilitaryToDateTime(exam.GetEndTime()).
                            ToString("hh:mm tt");

                        file.Write("\t" + examTimes + "\n");

                        foreach (ClassTime time in compressedTime.
                            GetClassTimes())
                        {
                            if (time != compressedTime.GetClassTimes().First())
                            {
                                string classTimes = "";
                                classTimes += time.getDayOfTheWeek() + " ";
                                classTimes += MilitaryToDateTime(time.
                                    getClassStartTime()).
                                    ToString("hh:mm tt") + "-";
                                classTimes += MilitaryToDateTime(time.
                                    getClassEndTime()).
                                    ToString("hh:mm tt");

                                file.Write("\t\t" + classTimes + "\n");
                            }
                        }

                        file.Write("\n");
                    }
                 */
                }

                //file.Close();
        }
    }
}
