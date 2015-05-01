using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace LIFES.FileIO
{
    /*
     * Class Name: CompressedClassTimes.cs
     * Author: Joshua Ford.
     * Date: 3/28/15
     * Modified by: Joshua Ford.
     * Description: Takes as a parameter a fileName. The data is read in,
     *              checked for proper formatting, and checked for data
     *              accuracy. The class times are then compressed in
     *              decending order based on the popularity of the 
     *              classtimes. The result is a list of most popular classtimes
     *              with their intersecting classes.
     */
    public class CompressedClassTimes
    {
        private ArrayList errorList = new ArrayList();
        private ArrayList warningList = new ArrayList();
        private readonly List<CompressedClassTime> compressedClassTimes;

        /*
         * Method Name: CompressedClassTimes
         * Parameters: filename - The name of the file containing the data to 
         *                        be processed.
         * Output: No explicit output.
         * 
         * Author: Joshua Ford.
         * Date: 3/28/15
         * Modified by: Joshua Ford.
         * Description: Reads in line by line from the file and then validates 
         *              that the line is in proper format, checks for valid 
         *              data, and compresses data.
         */
        public CompressedClassTimes(String filename)
        {
            // Creates a temparary Dict to hold the compressed day and time.
            var tmpCompressedClassTimes = new Dictionary<String, 
                CompressedClassTime>();
            int warning = 0;



            // Read in the file line by line.
            using (var sr = new StreamReader(filename))
            {
                // Line count (for giving a line number with errors).
                int lineCounter = 0;
                
                // Read until end of file (AKA read the entire file).
                while (!sr.EndOfStream)
                {
                    lineCounter++;

                    // Read one line.
                    String line = sr.ReadLine();

                    // Check that line format is correct.
                    Match validRow = new Regex("^[A-Z]+\\s[0-9]{4}\\s-\\s" +
                    "[0-9]{4},[0-9]+$").Match(line);
                    if (validRow.Success)
                    {
                        // Attempt to put each component of 
                        // line into a respective variable.
                        try
                        {
							String dayOfTheWeek = new Regex
								("[A-Z]+").Match(line).Value;
							
							if(dayOfTheWeek.Equals(false))
							{
								throw new Exception("Error - Invalid day " + 
									"of week");
							}

                            int classStartTime = int.Parse
                                (new Regex("[0-9]+").Match(line).Value);

                            if (classStartTime.Equals(false))
							{
								throw new Exception("Error - Invalid class " +
									"start time");
							}
                            int classEndTime = int.Parse(new 
                                Regex("[0-9]+").Match(line).NextMatch().Value);
                            int studentsEnrolled = 
                                int.Parse(new Regex("[0-9]+").Match(line).
                                NextMatch().NextMatch().Value);

                            if (studentsEnrolled.Equals(false))
                            {
                                throw new Exception("Error - Student Enrolled");
                            }
                            // Create new instance of ClassTime and pass line
                            // components.
                            var classTime = 
                                new ClassTime(dayOfTheWeek, classStartTime, 
                                    classEndTime, studentsEnrolled);

                            foreach (var c in dayOfTheWeek.ToCharArray())
                            {
                                // Round class start time down to the hour of.
                                int classStartTimeHour = classStartTime / 100;
                                String key = c.ToString() + classStartTimeHour;

                                // If tmpCompressedClassTimes does not have a 
                                // key, create one.
                                if (!tmpCompressedClassTimes.ContainsKey(key))
                                {
                                    tmpCompressedClassTimes.Add(key, 
                                        new CompressedClassTime(c.ToString(), 
                                            classStartTimeHour));
                                }
                                // Add the class time to 
                                // tmpCompressedClassTimes.
                                tmpCompressedClassTimes[key].
                                    addClassTime(classTime);
                            }

                        }
                        // Raise an error if any of the portions of the line 
                        // were not correct.
                        catch (Exception e)
                        {
                            if (e.Message != "")
                            {
                                if (e.Message.StartsWith("Error"))
                                {
                                    errorList.Add(e.Message
                                        + " on line " + lineCounter);
                                }
                                else
                                {
                                    warning++;
                                    
                                    warningList.Add(e.Message
                                        + " on line " + lineCounter);
                                }
                            }
                        }
                    }
                    // If row is invalid, raise error.
                    else
                    {
                        errorList.Add("Error on Line" 
                            + lineCounter + "\"" + line + "\"");
                    }
                }
            }

            // Create and populate compressedClassTimes with values from 
            // tmpCompressedClassTimes.
            compressedClassTimes = new List<CompressedClassTime>
                (tmpCompressedClassTimes.Values);


            // Sorts and ranks while removing classes once they have been used.
            compressedClassTimes.Sort();
            for (int i = 0; i < compressedClassTimes.Count; i++)
            {
                compressedClassTimes[i].markProccessed();
                compressedClassTimes.Sort();
            }
            // Cleans up any classes that got zeroed out during the sorting and
            // ranking.
            compressedClassTimes.RemoveAll(c => 
                c.getTotalStudentsEnrolled() == 0);

        }
        
        /*
         * Method Name: getCompressedClassTimes
         * Parameters:  None
         * Return:      compressedClassTimes - Gets class variable. 
         * Author:      Joshua Ford
         * Date:        3/28/15
         * Modified by: Joshua Ford
         * Description: Accessor for compressedClassTimes variable.
         */
        public List<CompressedClassTime> getCompressedClassTimes()
        {
            return compressedClassTimes;
        }

        /*
         * Method Name: getErrorList
         * Parameters:  None.
         * Return:      errorList   - Gets class variable, errorList.
         * Author:      Joshua Ford
         * Date:        4/19/15
         * Modified by: Joshua Ford
         * Description: Accessor for errorList variable.
         */
        public ArrayList getErrorList()
        {
            return errorList;
        }

        /*
         * Method Name: getWarningList
         * Parameters:  None
         * Return:      warningList - Gets class variable, warningList. 
         * Author:      Joshua Ford
         * Date:        4/19/15
         * Modified by: Joshua Ford
         * Description: Accessor for warningList variable.
         */
        public ArrayList getWarningList()
        {
            return warningList;
        }
    }
}

