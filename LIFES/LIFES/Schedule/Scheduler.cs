using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIFES;
using System.Collections;
using LIFES.FileIO;
using System.Diagnostics;
namespace LIFES.Schedule
{
    class Scheduler
    {
        private TimeConstraints tc;
        private List<CompressedClassTime> compressedClassTime;
        private FinalExamDay[] examWeek;
        private int examSlots;

        private void Schedule(CompressedClassTime ct)
        {
            int i = 0;
            foreach (FinalExamDay fed in examWeek)
            {
                if(fed.HasAvailableTime(ct.getClassTimeStartHour()))
                {
                    FinalExam fe = new FinalExam(ct);
                    int endTime = ct.getClassTimeStartHour()+ tc.GetLengthOfExams();
                    fe.SetEndTime(endTime+tc.GetTimeBetweenExams());
                    fed.InsertExam(fe);
                    //debugging infor
                    Debug.WriteLine("Day: " + fed.GetDay().ToString() + " " + fed.GetNumberOfExams());
                }
            }
        }
        /*
         * Method: Initiailize
         * Parameters: N/A
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 5/1/2015
         * Modified By: Scott Smoke
         * 
         * Description: Initialized the exam week.
         * 
         */ 
        private void Initialize()
        {
            for (int i = 0; i < tc.GetNumberOfDays(); i++ )
            {
                if (examWeek[i].GetDay() == 0)
                {
                    examWeek[i].SetDay(i);
                }
            }
        }
        private void runScheduler()
        {
            AvailableExamSlots();
            if (compressedClassTime != null)
            {
                //checking pigeon hole principle
                if ((examSlots * tc.GetNumberOfDays()) >= compressedClassTime.Count())
                {
                    //debugging info
                    Debug.WriteLine("Yay we get to schedule");
                    
                    foreach (CompressedClassTime ct in compressedClassTime)
                    {
                        Schedule(ct);
                    }
                }
                else
                {
                    Debug.WriteLine("Bummer we can't schedule");
                    //report error to user
                }
            }

        }
        /*
         * Method: AvailableExamSlots
         * Parameters: N/A
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This will calculate the total number
         * of exam slots that are available per day
         * 
         */ 
        private void AvailableExamSlots()
        {
            if (tc != null)
            {
                if ((tc.GetLengthOfExams() != 0) && (tc.GetTimeBetweenExams() != 0))
                {
                    //time when exams cannot pass
                    int endTime = 1715;
                    //converting values to floats
                    float lP = tc.GetLunchPeriod();
                    float sT = tc.GetStartTime();
                    float eL = tc.GetLengthOfExams();
                    float b = tc.GetTimeBetweenExams();
                    //getting to total amount of exams + break time then converting it to hours
                    float toHours = (eL + b) / 60;
                    //getting the minute portion for the total time allocated for exam on a particular day
                    float decPortion = ((endTime - lP - sT) % 100) / 60;
                    //getting the hour portion
                    int lengthOfExamDay = (int)(endTime - lP - sT) / 100;
                    //adding the minute and hours portions
                    float totalLength = lengthOfExamDay+decPortion;
                    //total slots available for exams on a single day
                    examSlots = (int)(totalLength / toHours);
                    //debugging stuff
                    Debug.WriteLine("Number of exam slots: " + examSlots.ToString());
                }
            }
 
        }
        /*
         * Method: Scheduler
         * Parameters: List<CompressedClassTime> ct, TimeConstraints t
         * OutPut: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This is the constructor for the class.
         */
        public Scheduler(List<CompressedClassTime> ct, TimeConstraints t)
        {
            tc = t;
            compressedClassTime = ct;
            examWeek = new FinalExamDay[tc.GetNumberOfDays()];
            Initialize();
            //to do 
        }
        /*
         * Method: reSchedule
         * Parameters: N/A
         * OutPut: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: Calls the reScheduler
         */
        public void ReSchedule()
        {
            //to do
        }

        /*
         * Method: scheduler
         * Parameters: N/A
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: Calls the Scheduler.
         * 
         */ 
        public void Schedule()
        {
            runScheduler();
        }
        public int GetExamSlots()
        {
            return examSlots;
        }



    }
}
