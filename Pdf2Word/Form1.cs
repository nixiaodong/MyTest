using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Pdf2Word
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            System.Windows.Forms.SaveFileDialog savePDFFile;
            string inFileName;
            string outFileName;
            int pos;
            label_Status.Text = "Status: n/a";
            Processing_txt.Text = "";
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "PDF Files (*.pdf) | *.pdf";
            if (openFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            inFileName = openFile.FileName;
            outFileName = inFileName;

            pos = inFileName.LastIndexOf('.');

            if (pos > 0)
            {
                outFileName = outFileName.Substring(0, pos);
            }
            outFileName += ".rtf";
            savePDFFile = new System.Windows.Forms.SaveFileDialog();
            savePDFFile.FileName = outFileName;
            savePDFFile.Filter = "RTF Files (*.rtf)|*.rtf||";
            savePDFFile.Title = "Save File";

            if (savePDFFile.ShowDialog() != DialogResult.OK)
                return;

            outFileName = savePDFFile.FileName;
            Convert(inFileName, outFileName);
        }

        private void Convert(string inFile, string outFile)
        {
            Type type = Type.GetTypeFromProgID("EasyConverter.PDF2Word.4");

            BCL.easyConverter4.Interop.Word.PDF2Word oConverter = (BCL.easyConverter4.Interop.Word.PDF2Word)Activator.CreateInstance(type);
            try
            {
                oConverter.OnPageStart += new BCL.easyConverter4.Interop.Word._IPDF2WordEvents_OnPageStartEventHandler(oConverter_OnPageStart);

                oConverter.OnConversionFinished += new BCL.easyConverter4.Interop.Word._IPDF2WordEvents_OnConversionFinishedEventHandler(oConverter_OnConversionFinished);

                oConverter.ConvertToWord(inFile, outFile, null, null, null);
                string dfileName = System.IO.Path.ChangeExtension(outFile, ".docx");
                //MessageBox.Show("Conversion Success!");
            }
            catch (System.Runtime.InteropServices.COMException err)
            {

                MessageBox.Show(err.Message);
            }
            finally
            {
                oConverter = null;
            }
        }

        private BCL.easyConverter4.Interop.Word.cnvResponse oConverter_OnPageStart(int nPageNumber, int nPageCount, string strFileName)
        {
            label_Status.Text = strFileName ;
            Processing_txt.Text=" Processing page " + (nPageNumber).ToString() +
                " of " + nPageCount.ToString();
            Update();

            return BCL.easyConverter4.Interop.Word.cnvResponse.CNV_CONTINUE;
        }
        private void oConverter_OnConversionFinished(int nResult)
        {
            label_Status.Text = "Status:Completed";
            Processing_txt.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
