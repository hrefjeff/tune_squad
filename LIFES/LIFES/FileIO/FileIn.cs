using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace LIFES.FileIO
{
    /*
     * Name:        FileIn
     * Author:      Joshua Ford
     * Created:     3/24/15
     * Modified by: [NOT YET MODIFIED]
     * Purpose:     Handles file input and validation of the first file.
     * */

    class FileIn
    {
        // Class variable.
        private string[] lines;

        /*
         * Name:        FileIn
         * Author:      Joshua Ford
         * Created:     3/24/15
         * Modified by: [NOT YET MODIFIED]
         * Parameters:  fileName - The name of the file to be opened.
         * Purpose:     Takes a filename as input and reads that file, then returns an array of the lines in that file.
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
                Console.WriteLine("Error, the file specified could not be found.");
            }
        }

        /*
         * Name:        validateConstraintsFile
         * Author(s):   Joshua Ford
         * Created:     3/31/15
         * Modified by: [NOT YET MODIFIED]
         * Parameters:  NONE
         * Purpose:     This method runs a check on the constraints file ensuring that the file data is in proper format and that the data itself is valid.
         */

        private bool IsValidConstraintsFile()
        {
            bool good = true;

            for (int i = 0; i < lines.Length; i++)
            {
                if (!isFileAllDigit(i))
                {
                    good = false;
                }

                else if (i == 0)
                {
                    if (lines[i] != "3" && lines[i] != "4" && lines[i] != "5")
                    {
                        Console.WriteLine("Error on line 1: Incorrect number of day choice.");
                        good = false;
                        //throw new Exception ("Error on line 1: Incorrect day choice.");
                    }
                }

                else if (i == 1)
                {
                    if (lines[i] != "0700")
                    {
                        Console.WriteLine("Error on line 2: Incorrect start time for final exams.");
                        good = false;
                        //throw new Exception ("Error line 2: Incorrect final exam start time.");
                    }
                }

                else if (i == 2)
                {
                    if (Convert.ToInt16(lines[i]) < 75 || Convert.ToInt16(lines[i]) > 300)
                    {
                        Console.WriteLine("Error on line 3: Incorrect exam time.");
                        good = false;
                        //throw new Exception ("Error line 3: Incorrect final exam length.");
                    }
                }

                else if (i == 3)
                {
                    if (Convert.ToInt16(lines[i]) < 10 || Convert.ToInt16(lines[i]) > 30)
                    {
                        Console.WriteLine("Error on line 4: Incorrect time between final exams.");
                        good = false;
                        //throw new Exception ("Error line 4: Incorrect length of time between exams.");
                    }
                }
            }
            return good;
        }

        /*
         * Name:        isFileAllDigit
         * Author(s):   Joshua Ford
         * Created:     4/1/15
         * Modified by: [NOT YET MODIFIED]
         * Parameters:  lineNum - The line number being checked.
         * Purpose:     Check a single line to make sure the string is in digit form.
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
                Console.WriteLine("Line " + (lineNum + 1) + " " + e.Message);
                digit = false;
            }
            return digit;
        }

        /*
         * Name:        setLines
         * Author:      Joshua Ford
         * Created:     3/25/15
         * Modified by: [NOT YET MODIFIED]
         * Parameters:  lines - An array of all lines in the file which was opened.
         * Purpose: Acts as the setter for this class (Purpose should be pretty transparant).
         */

        public void setLines(string[] lines)
        {
            if (lines.Length == 5)
            {
                this.lines = lines;
            }
            else
            {
                Console.WriteLine("Error, the file contains an incorrect number of lines.");
            }
        }

        /*
         * Name:        getLines
         * Author:      Joshua Ford
         * Created:     3/25/15
         * Modified by: Scott Smoke
         * Parameters:  NONE
         * Purpose: Acts as the getter for this class (This should also be pretty obvious)
         */
        public TimeConstraints GetTimeConstraints()
        {
            TimeConstraints tc =  new TimeConstraints(Convert.ToInt32(lines[0]), 
                Convert.ToInt32(lines[1]), Convert.ToInt32(lines[2]), 
                Convert.ToInt32(lines[3]), Convert.ToInt32(lines[4]));
            return tc;
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
    //        filename = "C:\\Users\\Josh Ford\\Documents\\GitHub\\tune_squad\\tune_squad\\Test\\CsharpSandbox\\JoshSandbox\\testConstraints.txt";
    //        FileIn myFile = new FileIn(filename);
    //        foreach (string val in myFile.getLines())
    //        {
    //            Console.WriteLine(val);
    //        }
    //        Console.ReadLine();
    //    }
    //}
}
