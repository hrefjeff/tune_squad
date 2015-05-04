using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIFES.FileIO;
using LIFES.Schedule;
namespace LIFES
{
    /*
     * Class Name: Globals
     * Created By: Scott Smoke
     * Date: 3/26/2015
     * Modified BY: Jordan Beck
     * Description: This class will contain all the global 
     * variables that are used throughout the project.
     */ 
    public static class  Globals
    {
        public static string timeConstraintsFileName = "";
        public static string totalEnrollemntsFileName = "";
        //constraints for the scheduler
        public static TimeConstraints timeConstraints = 
            new TimeConstraints(0,0,0,0,0);
        public static string semester = "";
        public static string year = "0";
        //data from the total enrollements file
        public static List<CompressedClassTime> compressedTimes;
        //final exam schedule
        public static FinalExamDay[] examWeek;
        //end of the exam day in military time
        public const int END_OF_EXAM_DAY = 1715;
        //Save file if applicable
    }
}
