using System;
using System.Collections.Generic;

namespace FinalExamScheduler
{
    /*
     * Class Name: CompressedClassTime.cs
     * Author: Joshua Ford, Shawn Weeks.
     * Date: 3/28/15
     * Modified by: Joshua Ford, Shawn Weeks.
     * Description: Associates the class times with one another and checks for
     *              conflicts.
     */
    public class CompressedClassTime : IComparable<CompressedClassTime>
    {
        private String dayOfTheWeek;
        private int classTimeStartHour;
        private List<ClassTime> classTimes;
        private Boolean isProccessed;

        // Constructor.
        public CompressedClassTime(String dayOfTheWeek, int classTimeStartHour)
        {
            this.dayOfTheWeek = dayOfTheWeek;
            this.classTimeStartHour = classTimeStartHour;
            this.classTimes = new List<ClassTime>();
            isProccessed = false;
        }

        public void addClassTime(ClassTime c)
        {
            this.classTimes.Add(c);
        }

        public void markProccessed()
        {
            this.isProccessed = true;
            foreach (var c in classTimes)
            {
                if (c.getOwnedBy() == "NA")
                {
                    c.setOwnedBy(dayOfTheWeek + classTimeStartHour);
                }
            }
            classTimes.RemoveAll(c => !c.getOwnedBy().Equals(dayOfTheWeek 
                + classTimeStartHour));
        }

        /*
         * Method Name: CompareTo
         * Parameters: c - The compressed class time to be evaluated.
         * Author: Joshua Ford, Shawn Weeks.
         * Date: 4/12/15
         * Modified by: Joshua Ford, Shawn Weeks.
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

        // Getter for DayOfTheWeek.
        public String getDayOfTheWeek()
        {
            return this.dayOfTheWeek;
        }

        // Getter for ClassTimeStartHour.
        public int getClassTimeStartHour()
        {
            return this.classTimeStartHour;
        }

        // Getter for TotalStudentsEnrolled.
        public int getTotalStudentsEnrolled()
        {
            int totalStudentsEnrolled = 0;
            foreach (var c in classTimes)
            {
                if (c.getOwnedBy().Equals(dayOfTheWeek 
                    + classTimeStartHour) || c.getOwnedBy().Equals("NA"))
                {
                    totalStudentsEnrolled += c.getStudentsEnrolled();
                }

            }
            return totalStudentsEnrolled;
        }

        // Getter for ClassTimes.
        public List<ClassTime> getClassTimes()
        {
            return this.classTimes;
        }

        // Getter for IsProccessed.
        public Boolean getIsProccessed()
        {
            return isProccessed;
        }

    }
}

