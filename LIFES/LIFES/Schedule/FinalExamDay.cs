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
    class FinalExamDay
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
         * Description: This inserts a final exam into the list.
         * 
         */
        public void InsertExam(FinalExam exam)
        {
            if (numberOfExams > finals.Count)
            {
                finals.Add(exam);
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

        public int GetDay()
        {
            return day;
        }

        public int GetNumberOfExams()
        {
            return finals.Count;
        }
        public void setNumberOfExams(int num)
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
         * available on the exam day.
         * 
         */
        public bool HasAvailableTime(int time)
        {
            if (finals.Count <= numberOfExams)
            {

                foreach (FinalExam fe in finals)
                {
                    if ((fe.GetStartTime() < time) && (fe.GetEndTime() >time))
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
