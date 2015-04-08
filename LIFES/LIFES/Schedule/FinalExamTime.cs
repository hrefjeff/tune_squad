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
     * Class Name: MaxBinaryHeapOfCourses
     * Author: Jeffrey Allen
     * Date: 4/8/2015
     * Modified by: Jeffrey Allen
     * This class is the final exam times that
     * are constructed after the scheduler has ran.
     */
    class MaxBinaryHeapOfCourses
    {
        public List<CompressedCourses> listOfCompressedCourses;

        public void insert(Cource someCourse)
        {
        }
    }

    /*
     * Class Name: CompressedCourses
     * Author: Jeffrey Allen
     * Date: 4/8/2015
     * Modified by: Jeffrey Allen
     * This class is the final exam times that
     * are constructed after the scheduler has ran.
     */ 
    class CompressedCourses
    {
        private List<Course> listOfCourses;
        private int _totalEnrollments;
        private int _totalNumberOfCourses;

        public void insertCourse() { }
        public void removeCourse() { }
        public void summary() { }
    }

    /*
    * Class Name: Course
    * Author: Jeffrey Allen
    * Date: 4/8/2015
    * Modified by: Jeffrey Allen
    * This class is the final exam times that
    * are constructed after the scheduler has ran.
    */ 
    class Course
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
