using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFES.Schedule
{
    /*
     * Class Name: FinalExamTime.cs
     * Author: Scott Smoke
     * Date: 3/25/2015
     * Modified by: Scott Smoke
     * This class is the final exam times that
     * are constructed after the scheduler has ran.
     */ 
    class FinalExamTime
    {
    }

    /*
     * Class Name: MaxBinaryHeapOfClasses
     * Author: Jeffrey Allen
     * Date: 4/8/2015
     * Modified by: Jeffrey Allen
     * This class is the final exam times that
     * are constructed after the scheduler has ran.
     */
    class MaxBinaryHeapOfClasses
    {
        public List<CompressedClasses> listOfCompressedClasses;

        public void insert(Class someClass)
        {
        }
    }

    /*
     * Class Name: CompressedClasses
     * Author: Jeffrey Allen
     * Date: 4/8/2015
     * Modified by: Jeffrey Allen
     * This class is the final exam times that
     * are constructed after the scheduler has ran.
     */ 
    class CompressedClasses
    {
        private List<Class> listOfClasses;
        private int _totalEnrollments;
        private int _totalNumberOfClasses;

        public void insertClass() { }
        public void removeClass() { }
        public void summary() { }
    }

    /*
    * Class Name: Class
    * Author: Jeffrey Allen
    * Date: 4/8/2015
    * Modified by: Jeffrey Allen
    * This class is the final exam times that
    * are constructed after the scheduler has ran.
    */ 
    class Class
    {
        private string _meetingDay;
        private string _startTime;
        private string _endTime;
        private int _enrollment;

        public string meetingDay
        {
            get { return _meetingDay; }
            set { _meetingDay = value; }
        }

        public string startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public string endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public int enrollment
        {
            get { return _enrollment; }
            set { _enrollment = value; }
        }

    }

}
