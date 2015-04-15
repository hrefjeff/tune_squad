using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIO
{
    class FileInput
    {
        // This is now working. I will need to set up exceptions so that the system doesn't crash if the filepath is wrong.
        public static string[] readFile(string filename)
        {
            string[] lines = { };
            //filename = "C:\\Users \\Shawn Weeks\\Documents\\Visual Studio 2013\\TextFile\\constraints.txt";
            //Console.WriteLine(filename);
            if (File.Exists(@filename))
            {
                lines = System.IO.File.ReadAllLines(@filename);
            }
            else
            {
                Console.WriteLine("Error, the file specified could not be found.");
            }

            return lines;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filename;
            Console.WriteLine("Enter the file name: ");
            filename = Console.ReadLine();
            string[] fileData = FileInput.readFile(filename);
            int i = 0;
            foreach(string val in fileData)
            {
                Console.WriteLine(fileData[i]);
                i++;
            }
            Console.ReadLine();
        }
    }
}
