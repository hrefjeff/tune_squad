using System;
using System.Collections.Generic;

namespace LIFES.FileIO
{
    /*
     * Class Name: CompressedClassTime.cs
     * Author: Joshua Ford.
     * Date: 3/28/15
     * Modified by: Joshua Ford.
     * Description: Associates the class times with one another and checks for
     *              conflicts.
     */
    public class CompressedClassTime : IComparable<CompressedClassTime>
    {
        private String dayOfTheWeek;
        private int classTimeStartHour;
        private List<ClassTime> classTimes;
        private Boolean isProccessed;

        /* CompressedClassTime.
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description: Compresses classes together.
         */
        public CompressedClassTime(String dayOfTheWeek, int classTimeStartHour)
        {
            this.dayOfTheWeek = dayOfTheWeek;
            this.classTimeStartHour = classTimeStartHour;
            this.classTimes = new List<ClassTime>();
            isProccessed = false;
        }

        /* AddClassTime
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description: Adds in a class time.
         */
        public void addClassTime(ClassTime c)
        {
            this.classTimes.Add(c);
        }

        /* MarkProccessed
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description: Marks the classe time as proccessed.
         */
        public void markProccessed()
        {
            this.isProccessed = true;
            foreach (var c in classTimes)
            {
                if (c.GetOwnedBy() == "NA")
                {
                    c.SetOwnedBy(dayOfTheWeek + classTimeStartHour);
                }
            }
            classTimes.RemoveAll(c => !c.GetOwnedBy().Equals(dayOfTheWeek 
                + classTimeStartHour));
        }

        /*
         * Method Name: CompareTo
         * Parameters: c - The compressed class time to be evaluated.
         * Output: returnValue - Returns 1 if one totalStudentsEnrolled is less
         *                       than the next totalStudentsEnrolled. Returns 
         *                       -1 if one totalStudentsEnrolled is greater 
         *                       than the next totalStudentsEnrolled or if one
         *                       of the totalStudentsEnrolled has been 
         *                       processed and the next one has not.
         * Author: Joshua Ford.
         * Date: 4/12/15
         * Modified by: Joshua Ford.
         * Description: Checks to see if the given class time equal to the next
         *              has been proccessed while the next one hasn't been. If 
         *              so, the resort is held off until the next class has 
         *              been proccessed.              
         */ 
        public int CompareTo(CompressedClassTime c)
        {
            int returnValue;

            if (this.getTotalStudentsEnrolled() < c.getTotalStudentsEnrolled())
            {
                returnValue = 1;
            }
            else if (this.getTotalStudentsEnrolled() > 
                c.getTotalStudentsEnrolled())
            {
                returnValue = -1;
            }
            else if (this.getIsProccessed() && !c.getIsProccessed())
            {
                returnValue = -1;
            }
            else {
                returnValue = 0;
            }
            
            return returnValue;
        }

        /* GetDayOfTheWeek
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description: Getter for DayOfTheWeek.
         */
        public String GetDayOfTheWeek()
        {
            return this.dayOfTheWeek;
        }

        /* GetDayOfTheWeek
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description:  Getter for ClassTimeStartHour.
         */
        public int getClassTimeStartHour()
        {
            return this.classTimeStartHour;
        }

        /* getTotalStudentEnrolled
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description: Getter for TotalStudentsEnrolled.
         */
        public int getTotalStudentsEnrolled()
        {
            int totalStudentsEnrolled = 0;
            foreach (var c in classTimes)
            {
                if (c.GetOwnedBy().Equals(dayOfTheWeek 
                    + classTimeStartHour) || c.GetOwnedBy().Equals("NA"))
                {
                    totalStudentsEnrolled += c.GetStudentsEnrolled();
                }

            }
            return totalStudentsEnrolled;
        }

        /* getClassTimes
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description: Getter for ClassTimes.
         */
        public List<ClassTime> GetClassTimes()
        {
            return this.classTimes;
        }

        /* getIsProccessed
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Jordan Beck
         * Description: Getter for IsProccessed.
         */
        public Boolean getIsProccessed()
        {
            return isProccessed;
        }

    }
}

