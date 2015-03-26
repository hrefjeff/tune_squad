using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace LIFES.FileIO
{
    /*
     * Class Name: FileOut.cs
     * Author: Scott Smoke
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
         * Author: Scott Smoke
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
         * Author: Scott Smoke
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * This method will output the final exam schedule to a pdf. 
         * This method uses the open source PDFSharp library by MigraDoc Foundation
         * nore information here: http://www.pdfsharp.net/.
         * This will read the data structure returned from the schedule
         * function and insert the data into a pdf.
         * 
         * Sources: http://csharp.net-informations.com/file/create-pdf.htm
         */
        public void WriteToPDF()
        {
            //to do use pdfsharp
            PdfDocument pdf = new PdfDocument();
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            //testing purposes
            XFont font = new XFont("Times New Roman", 12);
            graph.DrawString("This is my first PDF document", font, XBrushes.Black,
            new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            //end testing
            pdf.Save(filename);

        }
        /*
         * Method: WriteToCSV
         * Parameters: N/A
         * Output: Saved file in the CSV format
         * Author: Scott Smoke
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * This will write the data that is returned from the scheduler
         * to a file in the CSV format.
         */
        public void WriteToCSV()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
            //code to write goes here
            file.Close();
  

       
        }
        /*
         * Method: WriteToText
         * Parameters: N/A
         * Output: A saved file in plain text
         * Author: Scott Smoke
         * Date: 3/24/2015
         * Modified By: Scott Smoke
         * This will write the data that is returned from the scheduler
         * to a plain text file.
         */
        public void WriteToText() 
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
            //code to write goes here
            file.Close();
          
        }

    }
}
