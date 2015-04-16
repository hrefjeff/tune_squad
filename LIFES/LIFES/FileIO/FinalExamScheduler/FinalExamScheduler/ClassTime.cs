using System;
using System.Text.RegularExpressions;

namespace FinalExamScheduler
{
    /*
     * Class Name: ClassTime.cs
     * Author: Joshua Ford.
     * Date: 3/28/15
     * Modified by: Joshua Ford.
     * Description: Validate the data from the class times file is correct.
     *              Raise errors on any that does not conform to day order,
     *              minimum class start time, reasonable class end times, and
     *              has an incorrect number of students (i.e. students < 1).
     */ 
    public class ClassTime
    {
        private readonly String dayOfTheWeek;
        private readonly int classStartTime;
        private readonly int classEndTime;
        private readonly int studentsEnrolled;
        private String ownedBy;

        /*
         * Method Name: ClassTime
         * Parameters: dayOfTheWeek    - The number of days that the given 
         *                               class takes place.
         *             
         *             classStartTime  - The time in which the class starts.
         *            
         *             classEndTime    - The time in which the class ends.
         *             
         *             studentsEnrolled- The number of students enrolled in 
         *                               this class.
         *             
         * Output: No explicit output.
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified By: Joshua Ford.
         * Description: This is the constructor: Checks line for correct 
         *              class data.
         */ 
        public ClassTime(String dayOfTheWeek, int classStartTime, 
            int classEndTime, int studentsEnrolled)
        {
            Regex r = new Regex("^M?T?W?R?F?$");
            Match m = r.Match(dayOfTheWeek);

            if (!m.Success)
            {
                throw new Exception("Error - Days of the Week Invalid");
            }
            else if (classStartTime < 700)
            {
                throw new Exception("Error - Class Start Time Before 0700");
            }
            else if (classStartTime >= 1800)
            {
                throw new Exception("Error - Class End Time After 1800");
            }
            else if (classEndTime < classStartTime)
            {
                throw new Exception("Error - Class Ends Before It Starts");
            }
            else if (studentsEnrolled < 1)
            {
                throw new Exception("Error - Students Enrolled Less Than 1");
            }

            this.dayOfTheWeek = dayOfTheWeek;
            this.classStartTime = classStartTime;
            this.classEndTime = classEndTime;
            this.studentsEnrolled = studentsEnrolled;
            this.ownedBy = "NA";
        }

        // Setter for OwnedBy.
        public void setOwnedBy(String _ownedBy)
        {
            this.ownedBy = _ownedBy;
        }

        // Getter for DayOfTheWeek.
        public String getDayOfTheWeek()
        {
            return dayOfTheWeek;
        }

        // Getter for ClassStartTime.
        public int getClassStartTime()
        {
            return classStartTime;
        }

        // Getter for ClassEndTime.
        public int getClassEndTime()
        {
            return classEndTime;
        }

        // Getter for StudentsEnrolled.
        public int getStudentsEnrolled()
        {
            return studentsEnrolled;
        }

        // Getter for OwnedBy.
        public String getOwnedBy()
        {
            return ownedBy;
        }
    }
}

