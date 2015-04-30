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
        private List<FinalExam> finals;

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
            finals = null;
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
            finals.Add(exam);
        }
    }
}
