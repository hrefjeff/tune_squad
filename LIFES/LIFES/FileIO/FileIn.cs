using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LIFES.FileIO
{

    //class FileInput 
    //{ 

    //    private string fileName;

    //    protected virtual void read();

    //}

    //class FileInputTimeConstraint :  FileInput
    //{

    //    protected void read();

    //}

    //class FileInputEnrollmentsFile : FileInput
    //{ 

    //    protected void read();

    //}

    /* 
     * Name:        FileIn
     * Author:      Joshua Ford
     * Created:     3/24/15
     * Modified by: 
     * Purpose: Reads in data from a file.
     */
    class FileIn
    {
        // Class variable.
        private string[] lines;

        /*
         * Name:        FileIn
         * Author:      Joshua Ford
         * Created:     3/24/15
         * Modified by: 
         * Purpose: Takes a filename as input and reads that file, then returns an array of the lines in that file.
         */
        public FileIn(string fileName)
        {
            if (File.Exists(fileName))
            {

                setLines(System.IO.File.ReadAllLines(fileName));
                isValidConstraintsFile();
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
         * purpose:     This method runs a check on the constraints file ensuring that the file data is in proper format and that the data itself is valid.
         */
        private bool isValidConstraintsFile()
        {
            bool good = true;
            int numVal = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    numVal = Convert.ToInt16(lines[i]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Line " + (i + 1) + " " + e.Message);
                    good = false;
                }
            }
            return good;
        }

        /*
         * Name:        setLines
         * Author:      Joshua Ford
         * Created:     3/25/15
         * Modified by: [NOT YET MODIFIED]
         * Purpose: Acts as the setter for this class (Purpose should be pretty transparant).
         */
        void setLines(string[] lines)
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
         * Modified by: 
         * Purpose: Acts as the getter for this class (This should also be pretty obvious)
         */
        public string[] getLines()
        {
            return lines;
        }
    }

    // This was stubbed in for the purpose of testing. :)
    class Program
    {
        static void Main(string[] args)
        {
            string filename;
            Console.WriteLine("Enter the file name: ");
            filename = Console.ReadLine();
            filename = "C:\\Users\\Josh Ford\\Documents\\GitHub\\tune_squad\\tune_squad\\Test\\CsharpSandbox\\JoshSandbox\\testConstraints.txt";
            FileIn myFile = new FileIn(filename);
            foreach (string val in myFile.getLines())
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();
        }
    }
}
