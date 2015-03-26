using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LIFES.FileIO
{
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
            if(File.Exists(fileName))
            {
                setLines(System.IO.File.ReadAllLines(fileName));
            }
            else
            {
                Console.WriteLine("Error, the file specified could not be found.");
            }
        }

        /*
         * Name:        setLines
         * Author:      Joshua Ford
         * Created:     3/25/15
         * Modified by: 
         * Purpose: Acts as the setter for this class (Purpose should be pretty transparant).
         */
        void setLines(string[] lines)
        {
            if(lines.Length > 0)
            {
                this.lines = lines;
            }
            else
            {
                Console.WriteLine("Error, the file is empty.");
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
    /*
    class Program
    {
        static void Main(string[] args)
        {
            string filename;
            Console.WriteLine("Enter the file name: ");
            filename = Console.ReadLine();
            FileIn myFile = new FileIn(filename);
            foreach(string val in myFile.getLines())
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();
        }
    }
     */
}
