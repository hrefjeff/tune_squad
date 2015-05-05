using System;
using System.Text.RegularExpressions;

namespace LIFES.FileIO
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
         * Parameters:  dayOfTheWeek    - The number of days that the given 
         *                                class takes place.            
         *              classStartTime  - The time in which the class starts.          
         *              classEndTime    - The time in which the class ends.          
         *              studentsEnrolled- The number of students enrolled in 
         *                                this class.            
         * Return:      No explicit output.
         * Author:      Joshua Ford.
         * Date:        3/28/15
         * Modified By: Joshua Ford.
         * Description: This is the constructor: Checks line for correct 
         *              class data.
         */ 
        public ClassTime(String dayOfTheWeek, int classStartTime, 
            int classEndTime, int studentsEnrolled)
        {
            Regex r = new Regex("^M?T?W?R?F?$");
            Match m = r.Match(dayOfTheWeek);
            Regex singleDay = new Regex("M[^x]|T[^x]|W[^x]|R[^x]");
            Match sd = singleDay.Match(dayOfTheWeek);

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
               throw new Exception("");
            }
            else if (classEndTime > 1800)
            {
                throw new Exception("");
            }
            else if (classEndTime < classStartTime)
            {
                throw new Exception("Error - Class Ends Before It Starts");
            }
            else if (studentsEnrolled < 1)
            {
                throw new Exception("Warning - Students Enrolled Less Than 1");
            }
            else if (!sd.Success)
            {
                throw new Exception("Warning - This class time will not be"
                    + " included in the compression");
            }

            this.dayOfTheWeek = dayOfTheWeek;
            this.classStartTime = classStartTime;
            this.classEndTime = classEndTime;
            this.studentsEnrolled = studentsEnrolled;
            this.ownedBy = "NA";
        }

        /*
         * Method Name: SetOwnedBy
		 * Parameters:  ownedBy	- Class variable, ownedBy.
		 * Return:      None
		 * Author:      Joshua Ford
		 * Date:        3/28/15
		 * Modified by: Joshua Ford
		 * Description: Mutator for the class variable, ownedBy.
		 */
        public void SetOwnedBy(String ownedBy)
        {
            this.ownedBy = ownedBy;
        }

		/*
		 * Method Name: GetDayOfTheWeek
		 * Parameters:  None
		 * Return:      dayOfTheWeek	- Gets class variable, dayOfTheWeek. 
		 * Author:      Joshua Ford
		 * Date:        3/28/15
		 * Modified by: Joshua Ford
		 * Description: Accessor for class variable, dayOfTheWeek.
		 */
        public String GetDayOfTheWeek()
        {
            return dayOfTheWeek;
        }

		/*
		 * Method Name: GetClassStartTime
		 * Parameters:  None
		 * Return:      classStartTime	- Gets class variable, classStartTime. 
		 * Author:      Joshua Ford
		 * Date:        3/28/15
		 * Modified by: Joshua Ford
		 * Description: Accessor for class variable, classStartTime.
		 */
        public int GetClassStartTime()
        {
            return classStartTime;
        }

		/*
		 * Method Name: GetClassEndTime
		 * Parameters:  None
		 * Return:      classEndTime	- Gets class variable, classEndTime. 
		 * Author:      Joshua Ford
		 * Date:        3/28/15
		 * Modified by: Joshua Ford
		 * Description: Accessor for class variable, classEndTime.
		 */
        public int GetClassEndTime()
        {
            return classEndTime;
        }

		/*
		 * Method Name: GetStudentsEnrolled
		 * Parameters:  None
		 * Return:      studentsEnrolled	- Gets class variable, studentsEnrolled. 
		 * Author:      Joshua Ford
		 * Date:        3/28/15
		 * Modified by: Joshua Ford
		 * Description: Accessor for class variable, studentsEnrolled.
		 */
        public int GetStudentsEnrolled()
        {
            return studentsEnrolled;
        }

		/*
		 * Method Name: getOwnedby
		 * Parameters:  None
		 * Return:      ownedBy	- Gets class variable, ownedBy. 
		 * Author:      Joshua Ford
		 * Date:        3/28/15
		 * Modified by: Joshua Ford
		 * Description: Accessor for class variable, ownedBy.
		 */
        public String GetOwnedBy()
        {
            return ownedBy;
        }
    }
}

