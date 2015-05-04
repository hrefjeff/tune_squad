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
                setLines(System.IO.File.ReadAllLines(fileName));
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
                    if (!isFileAllDigit(i))
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
         * Name:        isFileAllDigit
         * Author(s):   Joshua Ford
         * Created:     4/1/15
         * Modified by: Scott Smoke
         * Parameters:  lineNum - The line number being checked.
         * Output: digit - Returns true if the passed parameter is a digit and
         *                 returns false otherwise.
         * Purpose:     Check a single line to make sure the string is in 
         *              digit form.
         */

        private bool isFileAllDigit(int lineNum)
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
         * Name:        setLines
         * Author:      Joshua Ford
         * Created:     3/25/15
         * Modified by: Joshua Ford
         * Parameters:  lines - An array of all lines in the file which was
         *                      opened.
         * Output: No explicit output.
         * Purpose: Acts as the setter for this class 
         * (Purpose should be pretty transparant).
         */
        public void setLines(string[] lines)
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
        public void ReadFromCsv(string filename) { }

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

                List<string> lines = null;

                System.IO.StreamReader file = 
                    new System.IO.StreamReader(filename);
                //code to write goes here
                file.ReadLine(Globals.semester + " " +Globals.year);
                file.ReadLine(Globals.totalEnrollemntsFileName);
                file.Line(Globals.timeConstraints.ToString());
                if (Globals.adminApproved)
                {
                    file.WriteLine("0");
                }
                else
                {
                    file.WriteLine("1");
                }
                file.WriteLine("\n");

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
                }

                file.Close();
        }
    }



    // This was stubbed in for the purpose of testing. :)
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string filename;
    //        Console.WriteLine("Enter the file name: ");
    //        filename = Console.ReadLine();
    //        filename = "C:\\Users\\Josh Ford\\Documents\\
    //        GitHub\\tune_squad\\tune_squad\\Test\\CsharpSandbox\\
    //        JoshSandbox\\testConstraints.txt";
    //        FileIn myFile = new FileIn(filename);
    //        foreach (string val in myFile.getLines())
    //        {
    //            Console.WriteLine(val);
    //        }
    //        Console.ReadLine();
    //    }
    //}
}
