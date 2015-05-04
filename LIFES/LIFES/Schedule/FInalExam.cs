using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIFES.FileIO;

namespace LIFES.Schedule
{
    /*
     * Class Name: FinalExam.cs
     * Created By: Scott Smoke
     * Date: 4/30/2015
     * Modified By: Scott Smoke
     * 
     * Description: This class represents a single
     * final exam for the day. It implements the IComparable interface
     * that allows this class to be sorted. This also serves as
     * a wrapper for the CompressedClassTime class.
     * 
     */ 
    public class FinalExam : IComparable<FinalExam>
    {
        private CompressedClassTime compressedClass;
        private int startTime;
        private int endTime;
        /*
         * Method: FinalExam
         * Parameters: CompressedClassTime ct
         * OutPut: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: Constructor for the class.
         * 
         */ 
        public FinalExam(CompressedClassTime ct)
        {
            compressedClass = ct;
            endTime = 0;
        }
        /*
         * Method: SetStartTime
         * Parameters: int st
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 4/30/15
         * Modifed By: Scott Smoke
         * 
         * Description: Sets the startTime variable if the startTime is in 
         * 24 hr format.
         */ 
        public void SetStartTime(int st)
        {
            if (st > 0 && st < 2459)
            {
                startTime = st;
            }
            else
            {
                st = 0;
            }
           
        }
        /*
         * Method: setEndTime
         * Parameters: int et
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: Sets the endTime variable if it is in 24 hr format.
         * 
         */ 
        public void SetEndTime(int  et)
        {
            if (et > 0 && et < 2459)
            {
                endTime = et;
            }
            else
            {
                et = 0;
            }
        }
        /*
         * Method: getStartTime
         * Parameters: N/A
         * Output: int
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This returns the setTime variable.
         * 
         */ 
        public int GetStartTime()
        {
            return startTime;
        }
        /*
         * Method: GetCompressClass.
         * Parameters: N/A
         * Output: CompressedClassTime
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This returns the CompressedClassTime
         * that this exam is for.
         * 
         */ 
        public CompressedClassTime GetCompressedClass()
        {
            return compressedClass;
        }
        /*
         * Method: getEndTime
         * Parameters: N/A
         * Output: int
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This returns the endTime variable
         * 
         */ 
        public int GetEndTime()
        {
            return endTime;
        }
        /*
         * Method: CompareTo
         * Parameters: FinalExam exam
         * Output: int
         * Created By: Scott Smoke
         * Date: 4/30/2015
         * Modified By: Scott Smoke
         * 
         * Description: This overrides the compareTo method
         * inherited from the IComparable interace. It returns a
         * -1 if the value less than the current value, returns 0
         * if the are the same, and returns 1 if it is greater than
         * the current value.
         * 
         */ 
        public int CompareTo(FinalExam exam)
        {
            if (this.startTime < exam.startTime)
            {
                return -1;
            }
            else if (this.startTime == exam.startTime)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
