using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace LIFES.FileIO
{
    /*
     * Class Name: FileOut.cs
     * Created By: Scott Smoke
     * Date: 3/24/2015
     * Modified by: Scott Smoke
     * This class will output the created final exam in the requested
     * format.
     */
    class FileOut
    {
        private string filename;
        /*
         * Method: FileOut
         * Parameters: String filename
         * Output: N/A
         * Created By: Scott Smoke
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * This constructs an object. 
         */
        public FileOut(string file)
        {
            filename = file;
        }

        /*
         * Method: WriteToPDF
         * Parameters: String filename
         * Output: Saved file of the pdf format
         * Created By: Scott Smoke
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * This method will output the final exam schedule to a pdf. 
         * This method uses the open source PDFSharp library by MigraDoc Foundation
         * nore information here: http://www.pdfsharp.net/.
         * This will read the data structure returned from the schedule
         * function and insert the data into a pdf.
         * 
         * Sources: http://csharp.net-informations.com/file/create-pdf.htm
         *          http://www.pdfsharp.net/wiki/TextLayout-sample.ashx?AspxAutoDetectCookieSupport=1
         */
        public void WriteToPDF()
        {
            //to do use pdfsharp
            PdfDocument pdf = new PdfDocument();
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Times New Roman", 12);
            XTextFormatter tf = new XTextFormatter(graph);
            //adding data to pdf
            tf.DrawString(Globals.semester + " " + Globals.year, font,
                XBrushes.Black, new XRect(40, 0, pdfPage.Width.Point,
                    pdfPage.Height.Point), XStringFormats.TopLeft);

            tf.DrawString(Globals.totalEnrollemntsFileName, font,
                XBrushes.Black, new XRect(40, 12, pdfPage.Width.Point,
                    pdfPage.Height.Point), XStringFormats.TopLeft);

            tf.DrawString(Globals.timeConstraints.ToString(), font,
                XBrushes.Black, new XRect(40, 24, pdfPage.Width.Point,
                    pdfPage.Height.Point), XStringFormats.TopLeft);
            //add schedule
     
 
            pdf.Save(filename);

        }
        /*
         * Method: WriteToCSV
         * Parameters: N/A
         * Output: Saved file in the CSV format
         * Created By: Scott Smoke
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * This will write the data that is returned from the scheduler
         * to a file in the CSV format.
         */
        public void WriteToCSV()
        {
            if (filename !="")
            {
                System.IO.StreamWriter file = 
                    new System.IO.StreamWriter(filename);
                //code to write goes here
                file.WriteLine(Globals.semester + " " + Globals.year);
                file.WriteLine(Globals.totalEnrollemntsFileName);
                file.WriteLine(Globals.timeConstraints.ToString());
                //place exam schedule
                file.Close();
            }

       
        }
        /*
         * Method: WriteToText
         * Parameters: N/A
         * Output: A saved file in plain text
         * Created By: Scott Smoke
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * This will write the data that is returned from the scheduler
         * to a plain text file.
         */
        public void WriteToText() 
        {
            if (filename != "")
            {
                System.IO.StreamWriter file = 
                    new System.IO.StreamWriter(filename);
                //code to write goes here
                file.WriteLine(Globals.semester + " " +Globals.year);
                file.WriteLine(Globals.totalEnrollemntsFileName);
                file.WriteLine(Globals.timeConstraints.ToString());
                //place exam schedule
                file.Close();
            }
            
          
        }

    }
}
