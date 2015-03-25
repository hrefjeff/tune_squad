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
     * This class will output the final exam schedule to the requested 
     * file type.
     *  
     * Author: Scott Smoke
     * Last Modified by: Scott Smoke
     */
    class FileOut
    {
        private string filename;
        public FileOut(string file)
        {
            filename = file;
        }

        /*
         * This method will output the final exam schedule to a pdf. 
         * This method uses the open source PDFSharp library by MigraDoc Foundation
         * nore information here: http://www.pdfsharp.net/.
         * This will read the data structure returned from the schedule
         * function and insert the data into a pdf.
         * 
         * Sources: http://csharp.net-informations.com/file/create-pdf.htm
         * 
         * Author: Scott Smoke
         * Modified by: Scott Smoke
         */
        public void writeToPDF()
        {
            //to do use pdfsharp
            //PdfDocument pdf = new PdfDocument();
            //PdfPage pdfPage = pdf.AddPage();
            //XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            //XFont font = new XFont("Times New Roman", 12);
            //graph.DrawString("This is my first PDF document", font, XBrushes.Black,
            //new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            //pdf.Save("firstpage.pdf");

        }
        /*
        * This method will output the final exam schedule to a csv. 
        * 
        * Author: Scott Smoke
        * Modified by: Scott Smoke
        */
        public void writeToCSV()
        {
            //to do
        }
        /*
        * This method will output the final exam schedule to a plain text file. 
        * 
        * Author: Scott Smoke
        * Modified by: Scott Smoke
        */
        public void writeToText() 
        {
            //to do
        }

    }
}
