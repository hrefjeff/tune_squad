using System;
using System.Collections.Generic;

namespace FinalExamScheduler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String fileName = "";
            while (fileName == "")
            {				
                Console.Write("Enter your filename. ");
                fileName = Console.ReadLine();
            }

            fileName = "C:\\Users\\Josh Ford\\Documents\\GitHub\\tune_squad\\tune_squad\\Test\\Fall 2014 Total Enrollments by Meeting times.csv";

            var compressedClassTimes = new CompressedClassTimes(fileName);

            int lineCount = 0;
            foreach (var c in compressedClassTimes.getCompressedClassTimes())
            {
                lineCount++;
                Console.WriteLine("Day\tStart Time\tTotal " + 
                    "Students\tAssociated Classes");
                Console.WriteLine(lineCount + " " + c.getDayOfTheWeek() + "\t"
                    + c.getClassTimeStartHour() + ":00\t\t" + 
                    c.getTotalStudentsEnrolled() + "\t\t" 
                    + c.getClassTimes().Count);
                Console.WriteLine();
                Console.WriteLine("\tDay\tStart\tEnd\tStudents");
                foreach (var c1 in c.getClassTimes())
                {
                    Console.WriteLine("\t" + c1.getDayOfTheWeek() 
                        + "\t" + c1.getClassStartTime() + "\t" 
                        + c1.getClassEndTime() + "\t" 
                        + c1.getStudentsEnrolled());
                }
                Console.WriteLine();

            }
            Console.WriteLine("Total Number of Compressed Class Times " 
                + compressedClassTimes.getCompressedClassTimes().Count);
            Console.ReadLine();
        }
    }
}
