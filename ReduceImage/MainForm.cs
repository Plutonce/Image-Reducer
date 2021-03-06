﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ReduceImage
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Variables
        public string[] filePaths;
        public string tempPath;
        public long beforeFileSize;
        public long afterFileSize;

        #endregion

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (CBxIFormat.Text != "")
                ReduceImageSize();
            else
                MessageBox.Show("Please select image format.", "Image Size Reducer");
        }

        private void ReduceImageSize()
        {
            try
            {
                GetFilePathsInFolder(CBxIFormat.Text);
                    if (filePaths.Length == 0 && filePaths != null) 
                        this.Text = "Count: " + filePaths.Length.ToString();
                    
                for (int i = 0; i < filePaths.Length; i++)
                {
                    GetImageCount();

                    tempPath = filePaths[i];
                    Bitmap src = Image.FromFile(tempPath) as Bitmap;
                    Rectangle cropRect = new Rectangle(0, 0, src.Width, src.Height);
                    Bitmap target = new Bitmap(src, cropRect.Width, cropRect.Height);
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder,trackBar1.Value<5?25L:50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    src.Dispose();
                    File.Delete(tempPath);
                    target.Save(tempPath, jpgEncoder, myEncoderParameters);
                    logWriter(filePaths[i].ToString() + " Decrased. | "+ i.ToString() + Environment.NewLine, textBox1);
                }

                afterFileSize=FolderSizeCalculation(SelectFolderDialog.SelectedPath);
                MessageBox.Show("Completed. Total Reduced Image Size : "+(beforeFileSize-afterFileSize).ToString()+" Byte", "Image Size Reducer");

                this.Text = "Image Size Reducer";
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Failed.", "Image Size Reducer");
            }
        }

        private void GetImageCount()
        {
            this.Text = "Count: " + filePaths.Length.ToString();
            Application.DoEvents();
        }

        private void GetFilePathsInFolder(string FileType)
        {
            DialogResult result = SelectFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                    beforeFileSize = FolderSizeCalculation(SelectFolderDialog.SelectedPath);
                    filePaths = Directory.GetFiles(SelectFolderDialog.SelectedPath, FileType, SearchOption.AllDirectories);
            }
            else if(result == DialogResult.Cancel)
            {
                    
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static long FolderSizeCalculation(string yol)
        {
            long size = 0;
            string[] folders = Directory.GetFiles(yol, "*.*", SearchOption.AllDirectories);
            foreach (string folder in folders)
            {
                FileInfo fileInfo = new FileInfo(folder);
                size += fileInfo.Length;
            }
              return size;
        }
        public void logWriter(string txt, TextBox log)
        {
            //Log yazdırma."log" isimli textBox gerektirir.
            //Ex:logWriter("Hello World")
            if (log.Text.Length > 5000)
                log.Text = String.Empty;
            log.Text += DateTime.Now.ToString("dd MMM") + " - " + DateTime.Now.ToString("HH:mm:ss") + "  --  " + txt + Environment.NewLine;
            log.SelectionStart = log.TextLength;
            log.ScrollToCaret();
        }
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
