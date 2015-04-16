using System;
using System.Text.RegularExpressions;

namespace FinalExamScheduler
{
    /*
     * Class Name: ClassTime.cs
     * Author: Joshua Ford, Shawn Weeks.
     * Date: 3/28/15
     * Modified by: Joshua Ford, Shawn Weeks.
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
         * Parameters: _dayOfTheWeek    - The number of days that the given 
         *                                class takes place.
         *             
         *             _classStartTime  - The time in which the class starts.
         *            
         *             _classEndTime    - The time in which the class ends.
         *             
         *             _studentsEnrolled- The number of students enrolled in 
         *                                this class.
         *             
         * Output: No explicit output.
         * Author: Joshua Ford, Shawn Weeks.
         * Date: 3/28/15
         * Modified By: Joshua Ford, Shawn Weeks.
         * Description: This is the constructor: Checks line for correct 
         *              class data.
         */ 
        public ClassTime(String _dayOfTheWeek, int _classStartTime, 
            int _classEndTime, int _studentsEnrolled)
        {
            Regex r = new Regex("^M?T?W?R?F?$");
            Match m = r.Match(_dayOfTheWeek);

            if (!m.Success)
            {
                throw new Exception("Error - Days of the Week Invalid");
            }
            else if (_classStartTime < 700)
            {
                throw new Exception("Error - Class Start Time Before 0700");
            }
            else if (_classStartTime >= 1800)
            {
                throw new Exception("Error - Class End Time After 1800");
            }
            else if (_classEndTime < _classStartTime)
            {
                throw new Exception("Error - Class Ends Before It Starts");
            }
            else if (_studentsEnrolled < 1)
            {
                throw new Exception("Error - Students Enrolled Less Than 1");
            }

            this.dayOfTheWeek = _dayOfTheWeek;
            this.classStartTime = _classStartTime;
            this.classEndTime = _classEndTime;
            this.studentsEnrolled = _studentsEnrolled;
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

