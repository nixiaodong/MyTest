using RasterEdge.Imaging.Basic;
using RasterEdge.XDoc.PDF;

using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textdall
{
    public class Pdf2WordHelper
    {
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="path"></param>
        public void TransferPdf(string path)
        {
            try
            {
                PdfDocument pdf = new PdfDocument();
                pdf.LoadFromFile(path, FileFormat.DOC);
                pdf.SaveToFile("testpdf.doc", FileFormat.DOC);
                System.Diagnostics.Process.Start("testpdf.doc");
            }
            catch (Exception e)
            {

            }

        }
        //private RasterEdge.XImage.WinFormsViewer.WinViewer winViewer1;
        public void transfer2Pdf(string path)
        {
            String filename = path.Replace("\\", "/");
            int posi = filename.LastIndexOf("/");
            String _savename = filename.Substring(posi + 1);
            posi = _savename.LastIndexOf(".");
            String _convertName = _savename.Substring(0, posi);
            posi = filename.LastIndexOf(".");
            String _ocrname = filename.Substring(0, posi);
          

            PDFDocument doc = new PDFDocument(filename);
            //winViewer1.LoadFromFile(filename);
            String outputFilePath2 = "F:\\" + "asdas.docx";
            doc.ConvertToDocument(DocumentType.DOCX, outputFilePath2);
            //PdfDocument pdf = new PdfDocument();
            //pdf.LoadFromFile(filename, FileFormat.DOC);
            //pdf.SaveToFile("asdds.doc", FileFormat.DOC);
            //System.Diagnostics.Process.Start("asdds.doc");
        }
    }
}
