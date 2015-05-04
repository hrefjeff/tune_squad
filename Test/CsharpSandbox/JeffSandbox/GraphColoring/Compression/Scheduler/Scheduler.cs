using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression.Scheduler
{
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

        public void insert(Course someCourse)
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
    * Modified by: Jordan Beck
    * This class is the final exam times that
    * are constructed after the scheduler has ran.
    */
    class Course
    {
        private string _meetingDay;
        private int _startTime;
        private int _endTime;
        private int _enrollment;
        private int _color;

        public Course(string someDay, string someStartTime, 
            string someEndTime, int enrollment)
        {
            _meetingDay = someDay;
            _startTime = Convert.ToInt32(someStartTime);
            _endTime = Convert.ToInt32(someEndTime);
            _enrollment = enrollment;
            _color = -1;
        }

        public string meetingDay
        {
            get { return _meetingDay; }
            set { _meetingDay = value; }
        }

        public int startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public int endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public int enrollment
        {
            get { return _enrollment; }
            set { _enrollment = value; }
        }

        public int color
        {
            get { return _color; }
            set { _color = value; }
        }

    }

}
