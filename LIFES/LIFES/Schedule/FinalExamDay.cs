using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LIFES.Schedule
{
    /*
     * Class Name: FinalExamDay.cs
     * Created By: Scott Smoke
     * Date: 4/30/2015
     * Modified By: Scott Smoke
     * 
     * Description: This class represents a single exam day.
     * 
     */
    public class FinalExamDay
    {
        int day;
        private List<FinalExam> finals;
        private int numberOfExams;
        /*
         * Method: FinalExamDay
         * Parameters: N/A
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: Class constructor.
         */
        public FinalExamDay()
        {
            finals = new List<FinalExam>();
            day = 0;
        }
        /*
         * Method: getExams
         * Parameters: N/A
         * Output: List<FinalExam>
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This returns a sorted list of final exams of the day.
         * 
         */
        public List<FinalExam> GetExams()
        {
            finals.Sort();
            return finals;
        }
        /*
         * Method: insertExam
         * Parameters: FinalExam exam
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This inserts a final exam into the list and sorts
         * it afterwards.
         * 
         */
        public void InsertExam(FinalExam exam)
        {
            if (numberOfExams > finals.Count)
            {
                finals.Add(exam);
                finals.Sort();
            }
            
        }
        /*
         * Method: SetDay
         * Parameters: int day
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 5/1/2015
         * Modified By: Scott Smoke
         * 
         * Description: This set the day that the object will
         * represent in our schedule.
         * 
         */
        public void SetDay(int day)
        {
            this.day = day;
        }
        /*
         * Method: GetDay
         * Parameters: N/A
         * Output: int
         * Created By: Scott Smoke
         * Date: 5/1/2015
         * Modified By: Scott Smoke
         * 
         * Description: This returns the day. Since we are
         * using generic day 1, day 2...etc. It returns an integer
         * instead of a char.
         */ 
        public int GetDay()
        {
            return day;
        }
        /*
         * Method: GetNumberOfExams
         * Parameters: N/A
         * Output: int
         * Created By: Scott Smoke
         * Date: 5/1/2015
         * Modified By: Scott Smoke
         * 
         * Description: This returns the number of exams
         * that are currently scheduled for this day.
         * 
         */ 
        public int GetNumberOfExams()
        {
            return finals.Count;
        }
        /*
         * Method: SetNumberOfExams
         * Parameters: int num
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 5/1/2015
         * Modified By: Scott Smoke
         * 
         * Description: This sets the number
         * of exams that are to be scheduled on this day.
         * 
         */ 
        public void SetNumberOfExams(int num)
        {
            numberOfExams = num;
        }

        /*
         * Method: HasAvailableTime
         * Parameters: int time
         * Output: Bool
         * Created By: Scott Smoke
         * Date: 5/1/2015
         * Modified By: Scott Smoke
         * 
         * Description: This returns whether or not the time slot is 
         * available on the exam day. This algorithm searches all
         * exams that are scheduled for this day.
         * 
         */
        public bool HasAvailableTime(int beginTime, int endTime)
        {
            //makes sure there cannot be exams scheduled on this day 
            // then is what is allowed
            if (finals.Count < numberOfExams)
            {

                foreach (FinalExam fe in finals)
                {
                    //I could have combined these but thought it made it more
                    //readable in this form.
                    if ((beginTime > fe.GetStartTime()) && (beginTime < fe.GetEndTime()))
                    {
                        return false;
                    }
                    if ((endTime > fe.GetStartTime()) && (endTime < fe.GetEndTime()))
                    {
                        return false;
                    }
                    if (beginTime == fe.GetStartTime())
                    {
                        return false;
                    }
                    if (endTime == fe.GetEndTime())
                    {
                        return false;
                    }
                   
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }//end class
}
