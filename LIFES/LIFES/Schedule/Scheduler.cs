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

        private int MilitaryTime(int time)
        {
            int hour = time / 60;
            int min = time % 60;
            int militaryTime = (hour * 100) + min;
            return militaryTime;
        }
        private void Schedule(CompressedClassTime ct)
        {
            int i = 0;
            foreach (FinalExamDay fed in examWeek)
            {
                if(fed.HasAvailableTime(ct.getClassTimeStartHour()*100))
                {
                    FinalExam fe = new FinalExam(ct);
                    Debug.WriteLine("Class start hour " + ct.getClassTimeStartHour()*100);
                    int militaryTime = MilitaryTime(tc.GetLengthOfExams()+tc.GetTimeBetweenExams());
                    int endTime = (ct.getClassTimeStartHour()*100 + militaryTime);
                    fe.SetStartTime(ct.getClassTimeStartHour()*100);
                    fe.SetEndTime(endTime);
                    fed.InsertExam(fe);
                    //debugging info
                    Debug.WriteLine("Day: " + fed.GetDay().ToString() + " " + fed.GetNumberOfExams());
                    return;
                }
                else
                {
                    //Debug.WriteLine("Inside the else");
                    //int newStartTime = ct.getClassTimeStartHour()*100 + MilitaryTime(tc.GetLengthOfExams() + tc.GetTimeBetweenExams());
                    //while (newStartTime < 1515)
                    //{
                    //    if (fed.HasAvailableTime(newStartTime))
                    //    {
                    //        FinalExam fe = new FinalExam(ct);
                    //        fe.SetStartTime(ct.getClassTimeStartHour()*100 + newStartTime);
                    //        int endTime = newStartTime + MilitaryTime(tc.GetLengthOfExams() + tc.GetTimeBetweenExams());
                    //        fe.SetEndTime(endTime);
                    //        fed.InsertExam(fe);
                    //        return;
                    //    }
                    //    newStartTime = newStartTime + ct.getClassTimeStartHour()*100 + MilitaryTime(tc.GetLengthOfExams() + tc.GetTimeBetweenExams());
                    //}

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
                examWeek[i] = new FinalExamDay();
                examWeek[i].SetDay(i);
                examWeek[i].setNumberOfExams(examSlots);
            }
        }
        private void runScheduler()
        {
           
            if (compressedClassTime != null)
            {
                //checking pigeon hole principle
                if ((examSlots * tc.GetNumberOfDays()) >= compressedClassTime.Count())
                {
                    //debugging info
                    //Debug.WriteLine("Yay we get to schedule");
                    Debug.WriteLine("Size of compressedClassTimes " + compressedClassTime.Count);
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
            AvailableExamSlots();
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
            int totalExams=0;
            foreach (FinalExamDay fed in examWeek)
            {
                totalExams = totalExams + fed.GetNumberOfExams();
                foreach (FinalExam fe in fed.GetExams())
                {
                    Debug.WriteLine("Group " + fe.GetCompressedClasses().getDayOfTheWeek() + " " + "Start Time " + fe.GetStartTime() + " " + "End Time " + fe.GetEndTime());
                }
            }
            Debug.WriteLine("Total Exams "+ totalExams);
        }
        public int GetExamSlots()
        {
            return examSlots;
        }

        public FinalExamDay[] GetExams()
        {
            return examWeek;
        } 



    }
}
