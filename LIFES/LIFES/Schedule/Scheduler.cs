﻿using System;
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

        private int examSlots;

        private void runScheduler()
        {
            AvailableExamSlots();
            if (compressedClassTime != null)
            {
                if ((examSlots * tc.GetNumberOfDays()) <= compressedClassTime.Count())
                {
                    //run schedule
                }
                else
                {
                    //report error to user
                }
            }

        }
        private void AvailableExamSlots()
        {
            if (tc != null)
            {
                if ((tc.GetLengthOfExams() != 0) && (tc.GetTimeBetweenExams() != 0))
                {
                    examSlots = (int)(((1715 - tc.GetLunchPeriod()) - tc.GetStartTime()) / (((tc.GetLengthOfExams() + tc.GetTimeBetweenExams()) / 60) * 100));
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
