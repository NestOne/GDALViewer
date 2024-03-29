﻿using OSGeo.GDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace GDALViewer
{
    public partial class Form1 : Form
    {
        private bool m_hasReadInfo = false;
        private static readonly String VERSION = " v0.3";
        private static Dictionary<String, String> dicDriverExt = new Dictionary<string, string>();

        private enum RasterMode
        {
            SingleGray,
            SinglePalette,
            MultiColor
        }

        static Form1()
        {
            GdalConfiguration.ConfigureGdal();

            var num = Gdal.GetDriverCount();
            for (var i = 0; i < num; i++)
            {
                var driver = Gdal.GetDriver(i);

                string extension = driver.GetMetadataItem("DMD_EXTENSION", "");
                if (!String.IsNullOrWhiteSpace(extension) && !dicDriverExt.ContainsKey(extension))
                {
                    dicDriverExt.Add(extension, string.Format("{1} - {2}|*.{0}", extension, driver.ShortName, driver.LongName));
                }
            }
        }

        private String m_imagePath = "";
        public Form1(String[] parms)
        {
            InitializeComponent();
            LocalizeUI();

            this.Load += Form1_Load;
            this.SizeChanged += Form1_SizeChanged;

            if(parms.Length > 0)
            {
                m_imagePath = parms[0];
            }
        }

        private void LocalizeUI()
        {
            this.Text = GDALViewer.Properties.GDALViewerResource.MainForm_Title + VERSION;
            toolStripDropDownButtonFile.Text = GDALViewer.Properties.GDALViewerResource.Files;
            ToolStripMenuItemOpen.Text = GDALViewer.Properties.GDALViewerResource.Open;
            ToolStripMenuItemClose.Text = GDALViewer.Properties.GDALViewerResource.Close;
            tabPageImage.Text = GDALViewer.Properties.GDALViewerResource.Image;
            tabPageInfo.Text = GDALViewer.Properties.GDALViewerResource.Info;
            toolStripLabelDisplayMode.Text = GDALViewer.Properties.GDALViewerResource.DisplayMode;
            toolStripComboBoxDisplayMode.Items.AddRange(new String[] { GDALViewer.Properties.GDALViewerResource.Original, GDALViewer.Properties.GDALViewerResource.CompositeBands, GDALViewer.Properties.GDALViewerResource.SingleBand});
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ReadImage();
        }

        Bitmap _bitmap = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            InitUI();
            ReadImage();
        }

        private void InitUI()
        {
            toolStripComboBoxDisplayMode.SelectedIndex = 0;

            ShowDisplayModeUI(0);
        }

        private static Bitmap ReadBitmapDirect(Dataset ds, int xOff, int yOff, int width, int height, int imageWidth, int imageHeight)
        {
            if (ds.RasterCount == 0)
                return null;

            int[] bandMap = new int[4] { 1, 1, 1, 1 };
            int channelCount = 1;
            bool hasAlpha = false;
            bool isIndexed = false;
            int channelSize = 8;
            ColorTable colortable = null;
            // Evaluate the bands and find out a proper image transfer format
            for (int i = 0; i < ds.RasterCount; i++)
            {
                Band band = ds.GetRasterBand(i + 1);
                if (Gdal.GetDataTypeSize(band.DataType) > 8)
                    channelSize = 16;

                ColorInterp colorMode = band.GetRasterColorInterpretation();
                switch (colorMode)
                {
                    case ColorInterp.GCI_AlphaBand:
                        channelCount = 4;
                        hasAlpha = true;
                        bandMap[3] = i + 1;
                        break;
                    case ColorInterp.GCI_BlueBand:
                        if (channelCount < 3)
                            channelCount = 3;
                        bandMap[0] = i + 1;
                        break;
                    case ColorInterp.GCI_RedBand:
                        if (channelCount < 3)
                            channelCount = 3;
                        bandMap[2] = i + 1;
                        break;
                    case ColorInterp.GCI_GreenBand:
                        if (channelCount < 3)
                            channelCount = 3;
                        bandMap[1] = i + 1;
                        break;
                    case ColorInterp.GCI_PaletteIndex:
                        colortable = band.GetRasterColorTable();
                        isIndexed = true;
                        bandMap[0] = i + 1;
                        break;
                    case ColorInterp.GCI_GrayIndex:
                        isIndexed = true;
                        bandMap[0] = i + 1;
                        break;
                    default:
                        // we create the bandmap using the dataset ordering by default
                        if (i < 4 && bandMap[i] == 0)
                        {
                            if (channelCount < i)
                                channelCount = i;
                            bandMap[i] = i + 1;
                        }
                        break;
                }
            }

            // find out the pixel format based on the gathered information
            PixelFormat pixelFormat;
            DataType dataType;
            int pixelSpace;

            if (isIndexed)
            {
                pixelFormat = PixelFormat.Format8bppIndexed;
                dataType = DataType.GDT_Byte;
                pixelSpace = 1;
            }
            else
            {
                if (channelCount == 1)
                {
                    if (channelSize > 8)
                    {
                        pixelFormat = PixelFormat.Format16bppGrayScale;
                        dataType = DataType.GDT_Int16;
                        pixelSpace = 2;
                    }
                    else
                    {
                        pixelFormat = PixelFormat.Format24bppRgb;
                        channelCount = 3;
                        dataType = DataType.GDT_Byte;
                        pixelSpace = 3;
                    }
                }
                else
                {
                    if (hasAlpha)
                    {
                        if (channelSize > 8)
                        {
                            pixelFormat = PixelFormat.Format64bppArgb;
                            dataType = DataType.GDT_UInt16;
                            pixelSpace = 8;
                        }
                        else
                        {
                            pixelFormat = PixelFormat.Format32bppArgb;
                            dataType = DataType.GDT_Byte;
                            pixelSpace = 4;
                        }
                        channelCount = 4;
                    }
                    else
                    {
                        if (channelSize > 8)
                        {
                            pixelFormat = PixelFormat.Format48bppRgb;
                            dataType = DataType.GDT_UInt16;
                            pixelSpace = 6;
                        }
                        else
                        {
                            pixelFormat = PixelFormat.Format24bppRgb;
                            dataType = DataType.GDT_Byte;
                            pixelSpace = 3;
                        }
                        channelCount = 3;
                    }
                }
            }

            // Create a Bitmap to store the GDAL image in
            Bitmap bitmap = new Bitmap(imageWidth, imageHeight, pixelFormat);

            if (isIndexed)
            {
                // setting up the color table
                if (colortable != null)
                {
                    int iCol = colortable.GetCount();
                    ColorPalette pal = bitmap.Palette;
                    for (int i = 0; i < iCol; i++)
                    {
                        ColorEntry ce = colortable.GetColorEntry(i);
                        pal.Entries[i] = Color.FromArgb(ce.c4, ce.c1, ce.c2, ce.c3);
                    }
                    bitmap.Palette = pal;
                }
                else
                {
                    // grayscale
                    ColorPalette pal = bitmap.Palette;
                    for (int i = 0; i < 256; i++)
                        pal.Entries[i] = Color.FromArgb(255, i, i, i);
                    bitmap.Palette = pal;
                }
            }

            // Use GDAL raster reading methods to read the image data directly into the Bitmap
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, imageWidth, imageHeight), ImageLockMode.ReadWrite, pixelFormat);

            try
            {
                int stride = bitmapData.Stride;
                IntPtr buf = bitmapData.Scan0;

                ds.ReadRaster(xOff, yOff, width, height, buf, imageWidth, imageHeight, dataType,
                    channelCount, bandMap, pixelSpace, stride, 1);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            return bitmap;
        }

        private void ReadImage()
        {
            if (String.IsNullOrWhiteSpace(m_imagePath))
            {
                return;
            }

            int width = pictureBoxImage.Width;
            int height = pictureBoxImage.Height;

            if(width == 0 || height == 0)
            {
                return;
            }

            System.IO.FileInfo file = new System.IO.FileInfo(m_imagePath);

            Dataset dataset = Gdal.Open(m_imagePath, Access.GA_ReadOnly);

            if(dataset == null)
            {
                toolStripStatusLabel.Text = "File open failed";
                return;
            }
            //String[] rpcs = dataset.GetMetadata("RPC");

            if(!m_hasReadInfo)
            {
                richTextBoxInfo.Text = GDALInfo.GetInfo(dataset);
                m_hasReadInfo = true;
            }

            if(dataset.RasterCount < 1)
            {
                toolStripStatusLabel.Text = "File has no bands";
                return;
            }

            int overviewCount = dataset.GetRasterBand(1).GetOverviewCount();
            if (overviewCount == 0 && file.Length > 1024 * 1024 * 200) //没有金字塔的数据且超过100MB，默认不显示，需要手动刷新
            {
                toolStripStatusLabel.Text = GDALViewer.Properties.GDALViewerResource.StopDisplayImageForBigImageNoOverview;
                return;
            }

            // Creating a Bitmap to store the GDAL image in
            // _bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);

            int srcWidth = dataset.RasterXSize;
            int srcHeight = dataset.RasterYSize;

            if(width > height)
            {
                // 控件横向，图像纵向。影像高缩放到图像高度
                width = (int)(height / (double)srcHeight * srcWidth);
                
            }
            else 
            {
               // 图像和控件方向相同，不用修改
                height = (int)(width / (double)srcWidth * srcHeight);
            }
            
            _bitmap = ReadBitmapDirect(dataset, 0, 0, srcWidth, srcHeight, width, height);
            pictureBoxImage.Image = _bitmap;

            // Mat source = new Mat(m_imagePath, ImreadModes.Color);
            // int percent = 50;
            // double half_percent = percent / 200.0;
            // Mat[] splits = Cv2.Split(source);

            // Mat[] outChanle;
            // foreach (var channel in splits)
            // {
            //     int chaWidth = channel.Size().Width;
            //     int chaHeight = channel.Size().Height;

            //     long vec_size = width * height;
            //     Mat flat = channel.Reshape(1, 1);
            //     Cv2.Sort(flat, flat, SortFlags.Ascending | SortFlags.EveryRow);

            //     int lowval = flat.At<byte>((int)Math.Floor(flat.Cols * half_percent));
            //     int highval = flat.At<byte>((int)Math.Ceiling(flat.Cols * (1-half_percent)));

            //     Debug.WriteLine("lowval" + lowval + " highval" + highval);

            //     Mat newMat = new Mat();
            //     newMat.CopyTo(flat);

            //     newMat.SetTo(lowval, )
            // }
            
        
        
            // source.Resize(new OpenCvSharp.Size(500, 500));
            // Cv2.ImShow("Demo", source);
            // 
            // Cv2.WaitKey(0);
            // using (var window = new Window("people detector", WindowMode.Normal, source))
            // {
            //    // window.SetProperty(WindowProperty.Fullscreen, 1);
            //     Cv2.WaitKey(0);
            // }
        }


        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            ClearAll();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            StringBuilder stringBuilder = new StringBuilder(GDALViewer.Properties.GDALViewerResource.SomeRasterFormat);
            stringBuilder.Append("|*.IMG;*.TIF;*.TIFF|");
            stringBuilder.Append(GDALViewer.Properties.GDALViewerResource.SomeImageFormat);
            stringBuilder.Append("|*.JPG;*.PNG;*.GIF");

            foreach (String val in dicDriverExt.Values)
            {
                stringBuilder.Append("|");
                stringBuilder.Append(val);
            }

            stringBuilder.Append("|");
            stringBuilder.Append(GDALViewer.Properties.GDALViewerResource.AllFormat);
            stringBuilder.Append("|*.*");

            openFileDialog.Filter = stringBuilder.ToString();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_imagePath = openFileDialog.FileName;
            }

            ReadImage();
        }

        private void ClearAll()
        { 
            if(pictureBoxImage.Image != null)
            {
                pictureBoxImage.Image.Dispose();
                pictureBoxImage.Image = null;
            }

            richTextBoxInfo.Text = "";

            InitUI();
           
        }

        private void ToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void toolStripComboBoxDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDisplayModeUI(toolStripComboBoxDisplayMode.SelectedIndex);
        }

        private void ShowDisplayModeUI(int mode)
        {
            bool rgbMode = mode == 1;
            toolStripLabelR.Visible = rgbMode;
            toolStripComboBoxR.Visible = rgbMode;
            toolStripLabelG.Visible = rgbMode;
            toolStripComboBoxG.Visible = rgbMode;
            toolStripLabelB.Visible = rgbMode;
            toolStripComboBoxB.Visible = rgbMode;

            bool singleMode = mode == 2;
            toolStripComboBoxSingle.Visible = singleMode;
        }

        private void buttonSpeedTest_Click(object sender, EventArgs e)
        {
            var watch = Stopwatch.StartNew();

            int width = pictureBoxImage.Width;
            int height = pictureBoxImage.Height;
            Dataset dataset = Gdal.Open(m_imagePath, Access.GA_ReadOnly);
            int srcWidth = dataset.RasterXSize / 3;
            int srcHeight = dataset.RasterYSize / 3;
            _bitmap = ReadBitmapDirect(dataset, 0, 0, srcWidth, srcHeight, width, height);
            watch.Stop();
            dataset.Dispose();

            MessageBox.Show("Read speed is " + watch.Elapsed.ToString());
        }

        private void buttonNC2Tiff_Click(object sender, EventArgs e)
        {
            FormNC2Tiff formNC2Tiff = new FormNC2Tiff();
            formNC2Tiff.Show();
        }
    }
}

