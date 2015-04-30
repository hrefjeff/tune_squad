using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFES
{
    /*
     * Class Name: TimeConstraints.cs
     * Author: Scott Smoke
     * Date: 3/25/2015
     * Modified by: Scott Smoke
     * This class holds the time constraints that are specified in the 
     * Specification document.
     */
    public class TimeConstraints
    {
        private int numberOfDaysToSchedule;
        private int beginingTimeForExams;
        private int lengthOfTimeOfExam;
        private int timeBetweenExams;
        private int lunchPeriod;

        /*
         * Method: TimeConstraints
         * Parameters: Number of Days to schedule for
         *             The begining time of each exam
         *             Length of each exam
         *             The time between exams
         *             The length of a possible lunch break
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified by: Scott Smoke
         * 
         * Description: Class constructor.
         */
        public TimeConstraints(int numberOfDays, int startTime,
            int lengthOfExam, int timeBetween, int lunchLength)
        {
            numberOfDaysToSchedule = numberOfDays;
            beginingTimeForExams = startTime;
            lengthOfTimeOfExam = lengthOfExam;
            timeBetweenExams = timeBetween;
            lunchPeriod = lunchLength; 
        }

        /*
         * Method: GetNumberOfDays
         * Parameters: N/A
         * Output: Integer
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified by: Scott Smoke
         * Description: Gettter for the property numberOfDaysToSchedule
         */
        public int GetNumberOfDays()
        {
            return numberOfDaysToSchedule;
        }

        /*
         * Method: GetStartTime
         * Parameters: N/A
         * Output: Integer
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified by: Scott Smoke
         * Description: Gettter for the property beginingTimeForExams
         */
        public int GetStartTime()
        {
            return beginingTimeForExams;
        }

        /*
         * Method: GetLengthOfExams
         * Parameters: N/A
         * Output: Integer
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified by: Scott Smoke
         * Description: Gettter for the property lengthOfTimeOfExam
         */
        public int GetLengthOfExams()
        {
            return lengthOfTimeOfExam;
        }

        /*
         * Method: GetTimeBetweenExams
         * Parameters: N/A
         * Output: Integer
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified by: Scott Smoke
         * Description: Gettter for the property timeBetweenExams
         */
        public int GetTimeBetweenExams()
        {
            return timeBetweenExams;
        }

        /* 
         * Method: GetLunchPeriod
         * Parameters: N/A
         * Output: Integer
         * Created By: Scott Smoke
         * Date: 3/25/2015
         * Modified by: Scott Smoke
         * Description: Gettter for the property lunchPeriod
         */
        public int GetLunchPeriod()
        {
            return lunchPeriod;
        }
        /*
         * Method: ToString
         * Parameters: N/A
         * Output: A string
         * Created By: Scott Smoke
         * Date: 3/26/2015
         * Modified By: Scott Smoke
         * Description: Returns a string with all the fields concatenated together
         */
        public override string ToString()
        {
            return (
                numberOfDaysToSchedule + "\r\n" + "0"+
                beginingTimeForExams + "\r\n" +
                lengthOfTimeOfExam + "\r\n" +
                timeBetweenExams + "\r\n" +
                lunchPeriod);
        }
    }
}
