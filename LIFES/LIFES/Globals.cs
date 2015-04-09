using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFES
{
    /*
     * Class Name: Globals
     * Created By: Scott Smoke
     * Date: 3/26/2015
     * Modified BY: Scott Smoke
     * This class will contain all the global 
     * variables that are used throughout the project.
     */ 
    public static class  Globals
    {
        public static string timeConstraintsFileName = "";
        public static string totalEnrollemntsFileName = "";
        public static TimeConstraints timeConstraints = new TimeConstraints(0,0,0,0,0);
        public static string semester = "";
        public static string year = "0";
        //Save file if applicable
        //final exam schedule
    }
}
