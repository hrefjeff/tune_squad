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
    /*
     * Class Name: Scheduler
     * Created By: Scott Smoke
     * Date: 5/1/2015
     * Modified By: Scott Smoke
     * 
     * Description: This class schedules the final
     * exams.
     * 
     */ 
   public class Scheduler
    {
       //Scheduler constrains
        private TimeConstraints tc;
       //Totals enrollments data
        private List<CompressedClassTime> compressedClassTime;
       //final exam week
        private FinalExamDay[] examWeek;
       //total number of exams that can be scheduled
        private int examSlots;
        string error;
       /*
        * Method: FinaAvailableSlot
        * Parameters: FinalExamDay fed, CompressedClassTime ct,
        *             int startTime, int endTime
        * Output: N/A
        * Created By: Scott Smoke
        * Date: 5/4/2015
        * Modified By: Scott Smoke
        * 
        * Description: This method finds an available time slot
        * and inserts the exam into it.
        * 
        */ 
        private void FindAvailableSlot(FinalExamDay fed, CompressedClassTime ct,
            int startTime, int endTime)
        {
             while (startTime < Globals.END_OF_EXAM_DAY)
                {
                    if (fed.HasAvailableTime(startTime, endTime))
                    {
                        InsertExam(fed, ct, startTime, endTime);
                        return;
                    }
                    startTime = startTime +
                        MilitaryTime(tc.GetLengthOfExams()
                        + tc.GetTimeBetweenExams());

                    endTime = startTime +
                        MilitaryTime(tc.GetLengthOfExams()
                           + tc.GetTimeBetweenExams());
                }

        }
       /*
        * Method: ReSchedule
        * Parameters: CompressedClassTime ct
        * Output: N/A
        * Created By: Scott Smoke
        * Date: 5/4/2015
        * Modified By: Scott Smoke
        * 
        * Description: This takes a breath first approach by inserting
        * an exam in the first day near the time of the start time of the compressed class time.
        * Once there are no more slots at the time of the compressed class it then moves onto checking
        * if there are any more slots avalable for each day.
        * 
        */ 
        private void ReSchedule(CompressedClassTime ct)
        {
            //checks the nearest time slots to the compressed class times start time.
            foreach (FinalExamDay fed in examWeek)
            {
                //correcting for CompressedClassTime getClassTimeStartHour only returning a 2 digit integer
                int startTime = ct.getClassTimeStartHour() * 100;
                int endTime = startTime + MilitaryTime(tc.GetLengthOfExams() +
                    tc.GetTimeBetweenExams());

                if (fed.HasAvailableTime(startTime, endTime))
                {
                    InsertExam(fed, ct, startTime, endTime);
                    return;
                }
                
            }
            //if there were not any start times avaialable near the start time of the compressed time.
            foreach (FinalExamDay fed in examWeek)
            {
                int startTime = tc.GetStartTime();
                int endTime = startTime + MilitaryTime(tc.GetLengthOfExams() +
                    tc.GetTimeBetweenExams());
                FindAvailableSlot(fed, ct, startTime, endTime);
            } 
        }
       /*
       * Method: MilitaryTime
       * Parameters: int time
       * Output: int
       * Created By: Scott Smoke
       * Date: 5/1/2015
       * Modified By: Scott Smoke
       * 
       * Description: This method takes in a
       * integer value that represents time then it convers
       * it to military time. Note this does not take in standard
       * time. It refers to the time that I am using in my Schedule method.
       * 
       */
        private int MilitaryTime(int time)
        {
            int hour = time / 60;
            int min = time % 60;
            int militaryTime = (hour * 100) + min;
            return militaryTime;
        }
       /*
        * Method: InsertExam
        * Parameters: FinalExamDay fed, CompressedClassTime ct, 
        *             int startTime, int endTime
        * Output: N/A
        * Created By: Scott Smoke
        * Date: 5/3/2015
        * Modified By: Scott Smoke
        * 
        * Description: This inserts an exam into the specified
        * exam day with the specified start and end times.Notes this adds the
        * break time to the length of the exam.
        * 
        */ 
        private void InsertExam(FinalExamDay fed, CompressedClassTime ct, 
            int startTime, int endTime)
        {
            FinalExam fe = new FinalExam(ct);
            Debug.WriteLine("Class start hour " + ct.getClassTimeStartHour() * 100);
            fe.SetStartTime(startTime);
            fe.SetEndTime(endTime);
            fed.InsertExam(fe);
            //debugging info
            Debug.WriteLine("Day: " + fed.GetDay().ToString() + " " 
                + fed.GetNumberOfExams());
        }
       /*
        * Method: Schedule
        * Parameters: CompressedClassTime ct
        * Output: N/A
        * Created By: Scott Smoke
        * Date: 5/3/2015
        * Modified By: Scott Smoke
        * 
        * Description: This takes a depth first approach and fills up
        * each day before moving onto the second. In more specific terms, it takes in
        * a compressed class time and sees if it will fit into the first exam day, nearest the start time of
        * the compressed class time, if not
        * then it sees if there are any available time slots for that day left. If there are 
        * no more exam slots for that day then it moves onto the next.
        */ 
        private void Schedule(CompressedClassTime ct)
        {
            foreach (FinalExamDay fed in examWeek)
            {
                //correcting for CompressedClassTime getClassTimeStartHour only returning a 2 digit integer
                int startTime = ct.getClassTimeStartHour()*100;
                int endTime = startTime + MilitaryTime( tc.GetLengthOfExams() +
                    tc.GetTimeBetweenExams());
                //cheecks the nearest slot available to compressed class start time
                if(fed.HasAvailableTime(startTime,endTime))
                {
                    InsertExam(fed, ct, startTime, endTime);
                    return;
                }
                else
                {
                    startTime = tc.GetStartTime();
                    endTime = startTime + MilitaryTime(tc.GetLengthOfExams() + 
                        tc.GetTimeBetweenExams());
                    //if not then we check for any available start times on current day.
                    while (startTime < Globals.END_OF_EXAM_DAY)
                    {
                        if (fed.HasAvailableTime(startTime, endTime))
                        {
                            InsertExam(fed, ct, startTime, endTime);
                            return;
                        }
                        startTime = startTime +
                            MilitaryTime(tc.GetLengthOfExams()
                            + tc.GetTimeBetweenExams());

                        endTime = startTime +
                            MilitaryTime(tc.GetLengthOfExams()
                               + tc.GetTimeBetweenExams());
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
                examWeek[i].SetNumberOfExams(AvailaibleTimeSlotsWithoutLp());
                if (tc.GetLunchPeriod() != 0)
                {
                    FinalExam fe = new FinalExam(new CompressedClassTime("Lunch", 12));
                    fe.SetStartTime(1200);
                    fe.SetEndTime(1200 + MilitaryTime(tc.GetLunchPeriod()));
                    examWeek[i].InsertExam(fe);
                }
                
            }
        }
       /*
        * Method: AvailableTimeSlotsWithoutLp
        * Parameters: N/A
        * Output: N/A
        * Created By: Scott Smoke
        * Date: 5/4/2015
        * Modified By: Scott Smoke
        * 
        * Description: This will return the number of exam
        * slots without a lunch period.
        * 
        */
        private int AvailaibleTimeSlotsWithoutLp()
        {
            ////time when exams cannot pass
            int endTime = Globals.END_OF_EXAM_DAY;
            //converting values to floats
            float lP = tc.GetLunchPeriod();
            float sT = tc.GetStartTime();
            float eL = tc.GetLengthOfExams();
            float b = tc.GetTimeBetweenExams();
            //getting to total amount of exams + break time then converting it to hours
            float toHours = (eL + b) / 60;
            //getting the minute portion for the total time allocated for exam on a particular day
            float decPortion = ((endTime - sT) % 100) / 60;
            //getting the hour portion
            int lengthOfExamDay = (int)(endTime - sT) / 100;
            //adding the minute and hours portions
            float totalLength = lengthOfExamDay + decPortion;
            int slotsWithoutLP = (int)(totalLength / toHours);
            return slotsWithoutLP;
        }
       /*
        * Method: RunScheduler
        * Parameters: N/A
        * Output: N/A
        * Created By: Scott Smoke
        * Modified By: Scott Smoke
        * 
        * Description: This will initiate the
        * Schedule method if it passes the 
        * pigeon hole principle.
        * 
        */ 
        private void RunScheduler()
        {

            if (compressedClassTime != null && tc != null)
            {
                //checking pigeon hole principle
                if ((examSlots * tc.GetNumberOfDays()) >= compressedClassTime.Count())
                {
                    //debugging info
                    //Debug.WriteLine("Yay we get to schedule");
                    //Debug.WriteLine("Size of compressedClassTimes " + compressedClassTime.Count);
                    foreach (CompressedClassTime ct in compressedClassTime)
                    {
                        Schedule(ct);
                    }
                }
                else
                {
                    //debugging info
                    //Debug.WriteLine("Bummer we can't schedule");
                    //report error to user
                    error = "Please modify the time constraints to run the "+
                        "scheduler";
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
                    int endTime = Globals.END_OF_EXAM_DAY;
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
                   // Debug.WriteLine("Number of exam slots: " + examSlots.ToString());
                }
            }
 
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
        private void RunReScheduler()
        {
            if (compressedClassTime != null && tc != null)
            {
                if ((examSlots * tc.GetNumberOfDays()) >= compressedClassTime.Count())
                {
                    //debugging info
                    //Debug.WriteLine("Yay we get to schedule");
                    //Debug.WriteLine("Size of compressedClassTimes " + compressedClassTime.Count);
                    foreach (CompressedClassTime ct in compressedClassTime)
                    {
                        ReSchedule(ct);
                    }
                }
                else
                {
                    //debugging info
                    //Debug.WriteLine("Bummer we can't schedule");
                    //report error to user
                    error = "Please modify the time constraints to run the " +
                            "scheduler";
                }
            }
            //to do
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
         * Method: scheduler
         * Parameters: N/A
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: Calls the RunSchedule method.Served as a testing
         * method during testing.
         * 
         */ 
        public void Schedule()
        {
            RunScheduler();

            /* For debugging purposes
            int totalExams=0;
            foreach (FinalExamDay fed in examWeek)
            {
                totalExams = totalExams + fed.GetNumberOfExams();
                foreach (FinalExam fe in fed.GetExams())
                {
                    Debug.WriteLine("Day " + fed.GetDay() + " " + "Group " + fe.GetCompressedClass().GetDayOfTheWeek() + " "+ "Start Time " + fe.GetStartTime() + " " + "End Time " + fe.GetEndTime());
                }
            }
            Debug.WriteLine("Total Exams "+ totalExams);*/
        }
        public void ReSchedule()
        {
            RunReScheduler();
        }
       /*
        * Method: GetExamSlots
        * Parameters; N/A
        * Output: int
        * Created By: Scott Smoke
        * Date: 5/1/2015
        * Modified By: Scott Smoke
        * 
        * Description: This returns the total number
        * of exams that can be scheduled.
        * 
        */ 
        public int GetExamSlots()
        {
            return examSlots;
        }
       /*
        * Method: GetExams
        * Parameters: N/A
        * Output: FinalExams[]
        * Created By: Scott Smoke
        * Date: 5/1/2015
        * Modified By: Scott Smoke
        * 
        * Description: This returns an array of final exam days for
        * which the exams have been scheduled.
        * 
        */ 
        public FinalExamDay[] GetExams()
        {
            return examWeek;
        }

        public string GetErrorMessage()
        {
            return error;
        }
    }
}
