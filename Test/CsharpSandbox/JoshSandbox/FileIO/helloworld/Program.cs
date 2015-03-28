using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace FileIO
{
    class ClassTimes
    {
        private Dictionary<string, Day> classTimes;

        public ClassTimes()
        {
            classTimes = new Dictionary<string, Day>();
        }
    }

    class Day
    {
        private Dictionary<int, int> timeBrackets;

        public Day()
        {
            timeBrackets = new Dictionary<int, int>();
        }
    }

    class ClassScheduleFileLoader
    {
        private List<ClassSchedule> classSchedules = new List<ClassSchedule>();
        public ClassScheduleFileLoader(string fileName)
        {
            FileIn myFile = new FileIn(fileName);
            string[] lines = myFile.getLines();
            for (int line = 0; line < lines.Length; line++)
            {
                string daysOfWeek;
                int classStartTime;
                int classEndTime;
                int studentsEnrolled;

                Regex findValidRow = new Regex("^[A-Z]+\\s[0-9]{4}\\s-\\s[0-9]{4},[0-9]+$");
                Match validRow = findValidRow.Match(lines[line]);


                if (validRow.Success)
                {
                    Regex findDaysOfWeek = new Regex("^[A-Z]+");
                    Match matchedDaysOfWeek = findDaysOfWeek.Match(validRow.Value);
                    Regex findNumber = new Regex("[0-9]+");
                    Match matchedClassStartTime = findNumber.Match(validRow.Value);
                    Match matchedClassEndTime = matchedClassStartTime.NextMatch();
                    Match matchedStudentsEnrolled = matchedClassEndTime.NextMatch();

                    daysOfWeek = matchedDaysOfWeek.Value;
                    classStartTime = Convert.ToInt16(matchedClassStartTime.Value);
                    classEndTime = Convert.ToInt16(matchedClassEndTime.Value);
                    studentsEnrolled = Convert.ToInt16(matchedStudentsEnrolled.Value);

                    try
                    {
                        classSchedules.Add(new ClassSchedule(daysOfWeek, classStartTime, classEndTime, studentsEnrolled));
                    } catch(Exception e) {
                        Console.WriteLine("Error on Line " + line + " " + e.Message + " \"" + lines[line] + "\"");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Row Format on Line " + line);
                }

            }
        }

        public List<ClassSchedule> getClassSchedules()
        {
            return classSchedules;
        }
    }

    class ClassSchedule
    {
        private string daysOfWeek;
        private int classStartTime;
        private int classEndTime;
        private int studentsEnrolled;

        // Constructor.
        public ClassSchedule(string daysOfWeek, int classStartTime, int classEndTime, int studentsEnrolled)
        {
            setDaysOfWeek(daysOfWeek);
            setClassStartTime(classStartTime);
            setClassEndTime(classEndTime);
            setStudentsEnrolled(studentsEnrolled);
        }

        // Day of the week setter.
        void setDaysOfWeek(string daysOfWeek)
        {
            Regex validDays = new Regex("^M?T?W?R?F?$");
            Match isValidDays = validDays.Match(daysOfWeek);

            if (daysOfWeek.Length == 0)
            {
                throw new Exception("Days of Week Can't Be Empty");
            }
            else if (!isValidDays.Success)
            {
                throw new Exception("Invalid Days of the Week");
            }
            else
            {
                this.daysOfWeek = daysOfWeek;
            }
        }

        public string getDaysOfWeek()
        {
            return daysOfWeek;
        }

        void setClassStartTime(int classStartTime)
        {
            if (classStartTime < 700)
            {
                throw new Exception("Invalid Class Start Time");
            }
            else
            {
                this.classStartTime = classStartTime;
            }
        }

        public int getClassStartTime()
        {
            return classStartTime;
        }

        void setClassEndTime(int classEndTime)
        {
            if (classEndTime > 2359)
            {
                throw new Exception("Invalid Class End Time");
            }
            else
            {
                this.classEndTime = classEndTime;
            }
        }


        public int getClassEndTime()
        {
            return classEndTime;
        }


        void setStudentsEnrolled(int studentsEnrolled)
        {
            if (studentsEnrolled < 1)
            {
                throw new Exception("Invalid Number of students enrolled");
            }
            else
            {
                this.studentsEnrolled = studentsEnrolled;
            }
        }

        public int getStudentsEnrolled()
        {
            return studentsEnrolled;
        }


    }

    class FileIn
    {
        private string[] lines;

        public FileIn(string fileName)
        {
            if (File.Exists(fileName))
            {
                setLines(System.IO.File.ReadAllLines(fileName));
            }
            else
            {
                Console.WriteLine("Error, the file specified could not be found.");
                throw new Exception("File Not Found Error");

            }
        }

        void setLines(string[] lines)
        {
            if (lines.Length > 0)
            {
                this.lines = lines;
            }
            else
            {
                Console.WriteLine("Error, the file is empty");
            }
        }

        public string[] getLines()
        {
            return lines;
        }
    }

    //static class Program
    //{
    //    /// <summary>
    //    /// The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new Form1());
    //    }
    //}
    class FileInput
    {
        // This is now working. I will need to set up exceptions so that the system doesn't crash if the filepath is wrong.
        public static string[] readFile(string filename)
        {
            string[] lines = { };
            filename = "C:\\Users \\Shawn Weeks\\Documents\\Visual Studio 2013\\TextFile\\constraints.txt";
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
            filename = "C:\\Users\\Josh Ford\\Documents\\GitHub\\tune_squad\\tune_squad\\Test\\SmallTestDoc-Good.txt";
            
            ClassScheduleFileLoader classScheduleFile = new ClassScheduleFileLoader(filename);
            
            List<ClassSchedule> classSchedules = classScheduleFile.getClassSchedules();

            foreach (ClassSchedule c in classSchedules)
            {
                Console.WriteLine( c.getDaysOfWeek() + c.getClassStartTime() + c.getClassEndTime() + c.getStudentsEnrolled() );
            }
            //string[] fileData = ClassScheduleFileLoader.readFile(filename);
            //int i = 0;
            //foreach(string val in fileData)
            //{
            //    Console.WriteLine(fileData[i]);
            //    i++;
            //}
            Console.ReadLine();
        }
    }
}
