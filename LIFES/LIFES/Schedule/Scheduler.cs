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
   public class Scheduler
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

        /*
          * Method: GetNumberOfExams
          * Parameters: N/A
          * Output: int
          * Created By: Scott Smoke
          * Date: 5/3/2015
          * Modified By: Jordan Beck
          * 
          * Description: Scedules the Exams
          * 
          */
        private void Schedule(CompressedClassTime ct)
        {
            int i = 0;
            foreach (FinalExamDay fed in examWeek)
            {
                int startTime = ct.getClassTimeStartHour()*100;
                int endTime = startTime + MilitaryTime( tc.GetLengthOfExams()
                    + tc.GetTimeBetweenExams());
                if(fed.HasAvailableTime(startTime,endTime))
                {
                    FinalExam fe = new FinalExam(ct);
                    Debug.WriteLine("Class start hour " + ct.
                        getClassTimeStartHour()*100);
                    fe.SetStartTime(startTime);
                    fe.SetEndTime(endTime);
                    fed.InsertExam(fe);
                    //debugging info
                    Debug.WriteLine("Day: " + fed.GetDay().ToString() + " " + 
                        fed.GetNumberOfExams());
                    return;
                }
                else
                {
                    //int newStartHour = tc.GetStartTime();
                    startTime = tc.GetStartTime();
                    endTime = startTime + MilitaryTime(tc.GetLengthOfExams() + 
                        tc.GetTimeBetweenExams());
                    while (startTime < 1715)
                    {
                        if (fed.HasAvailableTime(startTime,endTime))
                        {
                            FinalExam fe = new FinalExam(ct);
                            Debug.WriteLine("Class start hour " + 
                                ct.getClassTimeStartHour() * 100);
                            fe.SetStartTime(startTime);
                            fe.SetEndTime(endTime);
                            fed.InsertExam(fe);
                            //debugging info
                            Debug.WriteLine("Day: " + fed.GetDay().ToString() 
                                + " " + fed.GetNumberOfExams());
                            return;
                        }
                        startTime = startTime + MilitaryTime(tc.
                            GetLengthOfExams() + tc.GetTimeBetweenExams());
                        endTime = startTime + MilitaryTime(tc.
                            GetLengthOfExams() + tc.GetTimeBetweenExams());
                    }
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
                examWeek[i].SetDay(i+1);
                examWeek[i].setNumberOfExams(examSlots);
            }
        }
        private void runScheduler()
        {
           
            if (compressedClassTime != null)
            {
                //checking pigeon hole principle
                if ((examSlots * tc.GetNumberOfDays()) >= 
                    compressedClassTime.Count())
                {
                    //debugging info
                    //Debug.WriteLine("Yay we get to schedule");
                    Debug.WriteLine("Size of compressedClassTimes " + 
                        compressedClassTime.Count);
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
         * Modified By: Jordan Beck
         * 
         * Description: This will calculate the total number
         * of exam slots that are available per day
         * 
         */ 
        private void AvailableExamSlots()
        {
            if (tc != null)
            {
                if ((tc.GetLengthOfExams() != 0) && 
                    (tc.GetTimeBetweenExams() != 0))
                {
                    //time when exams cannot pass
                    int endTime = 1715;
                    //converting values to floats
                    float lP = tc.GetLunchPeriod();
                    float sT = tc.GetStartTime();
                    float eL = tc.GetLengthOfExams();
                    float b = tc.GetTimeBetweenExams();
                    //getting to total amount of exams + break time 
                    // then converting it to hours
                    float toHours = (eL + b) / 60;
                    //getting the minute portion for the total time 
                    // allocated for exam on a particular day
                    float decPortion = ((endTime - lP - sT) % 100) / 60;
                    //getting the hour portion
                    int lengthOfExamDay = (int)(endTime - lP - sT) / 100;
                    //adding the minute and hours portions
                    float totalLength = lengthOfExamDay+decPortion;
                    //total slots available for exams on a single day
                    examSlots = (int)(totalLength / toHours);
                    //debugging stuff
                    Debug.WriteLine("Number of exam slots: " + 
                        examSlots.ToString());
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
         * Modified By: Jordan Beck
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
                    Debug.WriteLine("Day " + fed.GetDay() + " " + "Group " + 
                        fe.GetCompressedClasses().getDayOfTheWeek() + " "+
                        "Start Time " + fe.GetStartTime() + " " + "End Time " +
                        fe.GetEndTime());
                }
            }
            Debug.WriteLine("Total Exams "+ totalExams);
        }

        /*
          * Method: GetExam SLots
          * Parameters: N/A
          * Output: int
          * Created By: Scott Smoke
          * Date: 5/3/2015
          * Modified By: Jordan Beck
          * 
          * Description: Getter for Exam Slots
          * 
          */
        public int GetExamSlots()
        {
            return examSlots;
        }

        /*
          * Method: GetNumberOfExams
          * Parameters: N/A
          * Output: int
          * Created By: Scott Smoke
          * Date: 5/3/2015
          * Modified By: Jordan Beck
          * 
          * Description: Getter for exam week
          */
        public FinalExamDay[] GetExams()
        {
            return examWeek;
        } 



    }
}
