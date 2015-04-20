using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compression.Scheduler;

using System.Text.RegularExpressions;

// for matrix
using MetaExpr;


namespace Compression
{
    class Program
    {
        //====================BEGIN GRAPH COLORING==============
        public static int MAX = 100;
        static int[] degreeOfVertice = new int[MAX];
        static Matrix conflictMatrix = new Matrix(0,0);
        static List<ClassSchedule> classSchedules;
        static int numOfRows;
        static int numOfCols;
        static int numOfColors;

        static int[] color_list = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
                                  31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
                                  61,62,63,64,65,66,67,68,69,70};

        static void Main(string[] args)
        {

            string filename;
            filename = "C:\\Users\\elJeffeh\\spring_sched.csv";
            //filename = "C:\\Users\\elJeffeh\\SmallTestDoc-Good.csv";

            ClassScheduleFileLoader classScheduleFile = new ClassScheduleFileLoader(filename);

            classSchedules = classScheduleFile.getClassSchedules();

            // test
            //Course fCourse = new Course("MWF","0800","0850",30);
            //Course sCourse = new Course("MWF","0800","0915",30);

            //List<ClassSchedule> listOfCourses = new List<ClassSchedule>();

            // Read in classes
            //listOfCourses.Add(fCourse);
            //listOfCourses.Add(sCourse);

            numOfRows = classSchedules.Count;
            numOfCols = classSchedules.Count;

            conflictMatrix = new Matrix(numOfRows, numOfCols);

            //Console.WriteLine(fCourse.meetingDay);
            //Console.WriteLine(fCourse.startTime);
            //Console.WriteLine(fCourse.endTime);
            for (int i = 0; i < numOfCols; i++)
            {
                for (int j = i; j < numOfCols; j++)
                {
                    if (i == j)
                    {
                        conflictMatrix[i, j] = 0;
                    }
                    else
                    {
                        
                        int conflictNum = checkConflict(classSchedules[i], classSchedules[j]);

                        if (conflictNum > 0)
                        {
                            conflictMatrix[i, j] = conflictNum;
                            conflictMatrix[j, i] = conflictNum;
                        }
                    }
                }
            }

            Console.WriteLine();

            conflictMatrix.printMatrix();

            // Begin graph coloring 

            // initialize schedule colors
            for (int i = 0; i < numOfRows; i++)
            {
                classSchedules[i].color = -1;
                classSchedules[i].classNum = i;
            }

            greedy();

            // display sched colors
            for (int i = 0; i < numOfRows; i++)
                Console.WriteLine("Class " + i + ": " + classSchedules[i].color);

            // initilize list by adding first class to it
            List<CompressedClasses> listOfCompressedClasses = new List<CompressedClasses>();
            CompressedClasses initClassList = new CompressedClasses();
            initClassList.classColor = classSchedules[0].color;
            initClassList.insertClass(classSchedules[0]);
            listOfCompressedClasses.Add(initClassList);

            bool addedToList = false;

            // compress, starting from 2nd class
            for (int j = 1; j < numOfRows; j++)
            {
                for (int k = 0; k < listOfCompressedClasses.Count; k++)
                {
                    if (classSchedules[j].color == listOfCompressedClasses[k].classColor)
                    {
                        listOfCompressedClasses[k].insertClass(classSchedules[j]);
                        addedToList = true;
                    }
                }

                if (!addedToList)
                {
                    CompressedClasses newClassList = new CompressedClasses();
                    newClassList.classColor = classSchedules[j].color;
                    newClassList.insertClass(classSchedules[j]);
                    listOfCompressedClasses.Add(newClassList);
                }
                addedToList = false;
            }

            for (int i = 0; i < listOfCompressedClasses.Count; i++)
            {
                Console.WriteLine("List " + i + " contains:");
                for (int j = 0; j < listOfCompressedClasses[i].listOfClasses.Count; j++)
                    Console.WriteLine("\t" + listOfCompressedClasses[i].listOfClasses[j].classNum + "---" + listOfCompressedClasses[i].listOfClasses[j].meetingDay + "---" + listOfCompressedClasses[i].listOfClasses[j].startTime + "---" + listOfCompressedClasses[i].listOfClasses[j].endTime);

            }

            Console.WriteLine(filename);
            for (int i = 0; i < listOfCompressedClasses.Count; i++)
                listOfCompressedClasses[i].summary(i);

            Console.ReadLine();

        }

        //greedy graph coloring algorithm: filling in one color in as many nodes
        //as possible
        static void greedy()
        {
            short i, j, counter;
            while (!done()) //while any node remains uncolored
            {
                for (i = 0; i < numOfRows; i++)
                {
                    if (classSchedules[i].color < 0)	//not colored yet
                    {
                        //subscript for colors in adj_colors
                        counter = 0;
                        for (j = 0; j < numOfRows; j++)
                            classSchedules[i].adj_colors[j] = 0;
                        //load adjacent colors using the input matrix
                        //and thereby the colors of connected nodes
                        for (j = 0; j < numOfRows; j++)
                        {
                            if (conflictMatrix[i, j] > 0)
                                if (classSchedules[j].color > 0)
                                    classSchedules[i].adj_colors[counter++] = classSchedules[j].color;
                        }

                        //fill color if it is not in adj_colors
                        if (!find(color_list[numOfColors], classSchedules[i].adj_colors))
                            classSchedules[i].color = color_list[numOfColors];
                    }
                }
                numOfColors++;	//to next color
            }
        }

        static bool done()	//returns true if all nodes have been colored
        {
            for(short i = 0; i < numOfRows; i++)
                if(classSchedules[i].color < 0)
                    return false;
            return true;
        }

        //returns true if color ch is found in the array of adjacent colors
        static bool find(int color, int[] array)
        {
            for (short i = 0; i < numOfRows; i++)
                if (array[i] == color)
                    return true;
            return false;
        }

        //////////////===============================FAILED COLORING FUNCTIONS=====================
        ////////////// this function finds the unprocessed vertex of which degree is maximum
        ////////////static public int MaxDegreeVertex()
        ////////////{
        ////////////    int max = -1;
        ////////////    int max_i = 0;
        ////////////    for (int i = 0; i < numOfVertices; i++)
        ////////////        if (color[i] == 0)
        ////////////            if (degreeOfVertice[i] > max)
        ////////////            {
        ////////////                max = degreeOfVertice[i];
        ////////////                max_i = i;
        ////////////            }
        ////////////    return max_i;
        ////////////}


        ////////////// this function is for UpdateNN function
        ////////////    // it reset the value of scanned array
        ////////////    static public void scannedInit(int[] scanned)
        ////////////    {
        ////////////        for (int i=0; i<numOfVertices; i++)
        ////////////            scanned[i] = 0;
        ////////////    }

        ////////////    // this function updates NN array
        ////////////    static public void UpdateNN(int ColorNumber)
        ////////////    {
        ////////////        NNCount = 0;
        ////////////        for (int i=0; i<numOfVertices; i++)
        ////////////            if (color[i] == 0)
        ////////////            {
        ////////////                NN[NNCount] = i;
        ////////////                NNCount ++;
        ////////////            }
        ////////////        for (int i=0; i<numOfVertices; i++)
        ////////////            if (color[i] == ColorNumber)
        ////////////                for (int j=0; j<NNCount; j++)
        ////////////                    while (conflictMatrix[i,NN[j]] > 1)
        ////////////                    {
        ////////////                        NN[j] = NN[NNCount - 1];
        ////////////                        NNCount --;
        ////////////                    }
        ////////////    }

        ////////////    // this function will find suitable y from NN
        ////////////    static public int FindSuitableY(int ColorNumber, int VerticesInCommon)
        ////////////    {
        ////////////        int temp = 0;
        ////////////        int tmp_y = 0;
        ////////////        int y = 0;
        ////////////        int[] scanned = new int[MAX];
        ////////////        VerticesInCommon = 0;

        ////////////        for (int i=0; i < NNCount; i++)
        ////////////        {
        ////////////            tmp_y = NN[i];
        ////////////            temp = 0;
        ////////////            scannedInit(scanned);
        ////////////            for (int x=0; x<numOfVertices; x++)
        ////////////                if (color[x] == ColorNumber)
        ////////////                    for (int k=0; k<numOfVertices; k++)
        ////////////                        if (color[k] == 0 && scanned[k] == 0)
        ////////////                            if (conflictMatrix[x,k] > 1 && conflictMatrix[tmp_y,k] > 1)
        ////////////                            {
        ////////////                                temp ++;
        ////////////                                scanned[k] = 1;
        ////////////                            }
        ////////////            if (temp > VerticesInCommon)
        ////////////            {
        ////////////                VerticesInCommon = temp;
        ////////////                y = tmp_y;
        ////////////            }
        ////////////        }
        ////////////        return y;
        ////////////    }

        ////////////    // find the vertex in NN of which degree is maximum
        ////////////    static public int MaxDegreeInNN()
        ////////////    {
        ////////////        int tmp_y = 0;
        ////////////        int temp = 0;
        ////////////        int max = 0;
        ////////////        for (int i=0; i<NNCount; i++)
        ////////////        {
        ////////////            temp = 0;
        ////////////            for (int j=0; j<numOfVertices; j++)
        ////////////                if (color[NN[j]] == 0 && conflictMatrix[i,NN[j]] > 1)
        ////////////                    temp ++;
        ////////////            if (temp>max)
        ////////////            {
        ////////////                max = temp;
        ////////////                tmp_y = NN[i];
        ////////////            }
        ////////////        }
        ////////////        return tmp_y;
        ////////////    }
        ////////////    // processing function
        ////////////    static public void Coloring()
        ////////////    {
        ////////////        int x = 0;
        ////////////        int y = 0;
        ////////////        int ColorNumber = 0;
        ////////////        int VerticesInCommon = 0;
        ////////////        while (unprocessed>0)
        ////////////        {
        ////////////            x = MaxDegreeVertex();
        ////////////            ColorNumber ++;
        ////////////            color[x] = ColorNumber;
        ////////////            unprocessed --;
        ////////////            UpdateNN(ColorNumber);
        ////////////            while (NNCount>0)
        ////////////            {
        ////////////                y = FindSuitableY(ColorNumber, VerticesInCommon);
        ////////////                if (VerticesInCommon == 0)
        ////////////                    y = MaxDegreeInNN();
        ////////////                color[y] = ColorNumber;
        ////////////                unprocessed --;
        ////////////                UpdateNN(ColorNumber);
        ////////////            }
        ////////////        }
        ////////////    }

        ////////////    // print out the output
        ////////////    static public void PrintOutput()
        ////////////    {
        ////////////        for (int i = 0; i < numOfVertices; i++)
        ////////////            Console.WriteLine("Vertex " + (i + 1) + " is colored " + color[i]);
        ////////////    }

        ////////////    //===============================MATRIX FUNCTIONS=====================
        ////////////    //===============================MATRIX FUNCTIONS=====================
        ////////////    //===============================MATRIX FUNCTIONS=====================
        ////////////    //===============================MATRIX FUNCTIONS=====================
        ////////////    //===============================MATRIX FUNCTIONS=====================
        ////////////    //===============================MATRIX FUNCTIONS=====================




        static public int checkConflict(ClassSchedule firstCourse, ClassSchedule secondCourse)
        {
            // if there is conlfict in day
            if (daysConflict(firstCourse.meetingDay, secondCourse.meetingDay))
            {
                // return true if there is conflict in time
                if (timeConflict(firstCourse.startTime, firstCourse.endTime, secondCourse.startTime, secondCourse.endTime))
                {
                    return firstCourse.enrollment + secondCourse.enrollment;
                }
            }

            return 0;
        }

        // returns true if there is conflict, false if there is no conflict
        static public bool daysConflict(string firstCourseDays, string secondCourseDays)
        {
            bool daysConflict = false;

            for (int i = 0; i < firstCourseDays.Length; i++)
            {
                if (i >= secondCourseDays.Length) 
                {
                    return daysConflict;
                }
                
                if (firstCourseDays[i] == secondCourseDays[i])
                {
                    daysConflict = true;
                }
            }

            return daysConflict;
        }

        // return true if conflict, return false if no conflict
        static public bool timeConflict(int courseTimeStart, int courseTimeEnd, int otherCourseTimeStart, int otherCourseTimeEnd)
        {
            // conflicts on front half
            if (courseTimeStart <= otherCourseTimeStart)
            {
                if (courseTimeEnd >= otherCourseTimeStart)
                { 
                    return true;
                }
            }

            // conflicts in middle
            if (courseTimeStart >= otherCourseTimeStart)
            {
                if (courseTimeEnd <= otherCourseTimeEnd)
                {
                    return true;
                }
            }

            // conflict on back half
            if (courseTimeStart <= otherCourseTimeEnd)
            {
                if (courseTimeEnd >= otherCourseTimeEnd)
                {
                    return true;
                }
            }

            return false;
        }
    }

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
                    int startTime;
                    int classEndTime;
                    int studentsEnrolled;

                    Regex findValidRow = new Regex("^[A-Z]+\\s[0-9]{4}\\s-\\s[0-9]{4},[0-9]+$");
                    Match validRow = findValidRow.Match(lines[line]);


                    if (validRow.Success)
                    {
                        Regex findDaysOfWeek = new Regex("^[A-Z]+");
                        Match matchedDaysOfWeek = findDaysOfWeek.Match(validRow.Value);
                        Regex findNumber = new Regex("[0-9]+");
                        Match matchedstartTime = findNumber.Match(validRow.Value);
                        Match matchedClassEndTime = matchedstartTime.NextMatch();
                        Match matchedStudentsEnrolled = matchedClassEndTime.NextMatch();

                        daysOfWeek = matchedDaysOfWeek.Value;
                        startTime = Convert.ToInt16(matchedstartTime.Value);
                        classEndTime = Convert.ToInt16(matchedClassEndTime.Value);
                        studentsEnrolled = Convert.ToInt16(matchedStudentsEnrolled.Value);

                        try
                        {
                            classSchedules.Add(new ClassSchedule(daysOfWeek, startTime, classEndTime, studentsEnrolled));
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
            public string meetingDay;
            public int startTime;
            public int endTime;
            public int enrollment;
            public int color;
            public int[] adj_colors = new int[1000];
            public int classNum = 0;

            // Constructor.
            public ClassSchedule(string daysOfWeek, int startTime, int classEndTime, int studentsEnrolled)
            {
                setDaysOfWeek(daysOfWeek);
                setstartTime(startTime);
                setClassEndTime(classEndTime);
                setStudentsEnrolled(studentsEnrolled);
                this.color = -1;
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
                    this.meetingDay = daysOfWeek;
                }
            }

            public string getDaysOfWeek()
            {
                return meetingDay;
            }

            void setstartTime(int startTime)
            {
                if (startTime < 700)
                {
                    throw new Exception("Invalid Class Start Time");
                }
                else
                {
                    this.startTime = startTime;
                }
            }

            public int getstartTime()
            {
                return startTime;
            }

            void setClassEndTime(int classEndTime)
            {
                if (classEndTime > 2359)
                {
                    throw new Exception("Invalid Class End Time");
                }
                else
                {
                    this.endTime = classEndTime;
                }
            }


            public int getClassEndTime()
            {
                return endTime;
            }


            void setStudentsEnrolled(int studentsEnrolled)
            {
                if (studentsEnrolled < 1)
                {
                    throw new Exception("Invalid Number of students enrolled");
                }
                else
                {
                    this.enrollment = studentsEnrolled;
                }
            }

            public int getStudentsEnrolled()
            {
                return enrollment;
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

        class CompressedClasses
        {
            public int classColor = 0;
            public List<ClassSchedule> listOfClasses;
            private int _totalEnrollments;
            private int _totalNumberOfCourses;

            public CompressedClasses() 
            {
                   listOfClasses = new List<ClassSchedule>();
            }

            public void insertClass(ClassSchedule someCourse)
            {
                listOfClasses.Add(someCourse);
            }
            
            public void removeClass() { }
            public void summary(int index)
            {
                Console.WriteLine("List -" + index + "- contains this many classes: " + listOfClasses.Count);
            }
        }
}
