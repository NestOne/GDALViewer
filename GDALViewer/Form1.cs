using OSGeo.GDAL;
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

namespace TiffViewer
{
    public partial class Form1 : Form
    {
        private enum RasterMode
        {
            SingleGray,
            SinglePalette,
            MultiColor
        }

        static Form1()
        {
            GdalConfiguration.ConfigureGdal();
        }

        private String m_imagePath = "";
        public Form1(String[] parms)
        {
            InitializeComponent();
      
            this.Load += Form1_Load;
            this.SizeChanged += Form1_SizeChanged;

            if(parms.Length > 0)
            {
                m_imagePath = parms[0];
            }
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

            int noData = 0;
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            if(width == 0 || height == 0)
            {
                return;
            }

            //String path = @"E:\CloudStation\ImageData\LC81310402017119LGN00_B1.TIF";
            //String path = @"E:\CloudStation\ImageData\T275_266jz.img";
            //String path = @"G:\ImageData\510000SC\510000SC\510000SC_L5_TM_2006\510000SC_L5_TM_2006_R1C1.TIF";
            Dataset dataset = Gdal.Open(m_imagePath, Access.GA_ReadOnly);

            richTextBox1.Text = GDALInfo.GetInfo(dataset);

            Debug.WriteLine("Open dataset " + m_imagePath + " successed!");
            int bandCount = dataset.RasterCount;
            Debug.WriteLine("contains " + bandCount + " bands");
            int srcWidth = dataset.RasterXSize;
            Debug.WriteLine("width " + srcWidth + " pixels");
            int srcHeight = dataset.RasterYSize;
            Debug.WriteLine("height " + srcHeight + " pixels");
            string description = dataset.GetDescription();
            Debug.WriteLine("description: " + description);

            // Creating a Bitmap to store the GDAL image in
            // _bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);

            _bitmap = ReadBitmapDirect(dataset, 0, 0, srcWidth, srcHeight, width, height);
            pictureBox1.Image = _bitmap;
            return;

            Band redBand = dataset.GetRasterBand(1);
            //Band greenBand = dataset.GetRasterBand(2);
            //Band blueBand = dataset.GetRasterBand(3);

            //ColorPalette pal = _bitmap.Palette;
            //for (int i = 0; i < 256; i++)
            //    pal.Entries[i] = Color.FromArgb(255, i, i, i);00
            //_bitmap.Palette = pal;
            DataType srcType = redBand.DataType;//byte类型

            DateTime start = DateTime.Now;

            int[] bandArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                bandArray[i] = i + 1;
            }


            // BitmapData bitmapData = _bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            // Obtaining the bitmap buffer
            long before = DateTime.Now.Ticks;
            BitmapData bitmapData = _bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            try
            {
                

                //int stride = bitmapData.Stride;
                //IntPtr buf = bitmapData.Scan0;

                //blueBand.ReadRaster(0, 0, redBand.XSize, redBand.YSize, buf, width, height, DataType.GDT_Byte, 4, stride);
                //greenBand.ReadRaster(0, 0, redBand.XSize, redBand.YSize, new IntPtr(buf.ToInt32() + 1), width, height, DataType.GDT_Byte, 4, stride);
                //redBand.ReadRaster(0, 0, redBand.XSize, redBand.YSize, new IntPtr(buf.ToInt32() + 2), width, height, DataType.GDT_Byte, 4, stride);
                //TimeSpan renderTime = DateTime.Now - start;
                //Console.WriteLine("SaveBitmapDirect fetch time: " + renderTime.TotalMilliseconds + " ms");

                int stride = bitmapData.Stride;
                IntPtr buf = bitmapData.Scan0;
                CPLErr err = dataset.ReadRaster(0, 0, redBand.XSize, redBand.YSize, buf, width, height, DataType.GDT_Int32, 3, bandArray, 0, 0, 0);

                //for (int i = 0; i < srcHeight; i++)
                //{
                //    CPLErr err = redBand.ReadRaster(0, 0, redBand.XSize, redBand.YSize, buf, width, height, DataType.GDT_Byte, 1, stride);
                //}


                if (err != CPLErr.CE_None)
                {
                    Debug.WriteLine("Read failed");
                }
            }
            finally
            {
                _bitmap.UnlockBits(bitmapData);
            }

            long span = (DateTime.Now.Ticks - before) / 1000;
            Debug.WriteLine("Read cost :" + span + " ms");

            Color read;
            Color left = Color.Black;
            //using (Graphics g = Graphics.FromImage(_bitmap))
            //{
            //    int startX = 0;
            //    int startY = 0;
            //    for (int i = 0; i < height; i++)
            //    {
            //        //for (int j = 0; j < width; j++)
            //        {
            //            read = _bitmap.GetPixel(i, i);

            //            if ((read.R + read.G + read.B) != noData)
            //            {
            //                startX = i;
            //                startY = i;
            //                break;
            //            }
            //        }
            //    }

            //    int recordX = startX;
            //    int recordY = startY;

            //    do
            //    {
            //        int direction = 0;
            //        int value0 = 0;
            //        int before = 0;
            //        int curValue = 0;

            //        Debug.WriteLine("CurPoint is " + recordX + " , " + recordY);
            //        while (direction <= 8)
            //        {
            //            int curX = recordX;
            //            int curY = recordY;

            //            MoveCur(direction, ref curX, ref curY);

            //            read = _bitmap.GetPixel(curX, curY);
            //            curValue = read.R + read.G + read.B;
            //            Debug.WriteLine("    value: " + curValue + " --- " + direction);

            //            //if(curValue != noData)
            //            //{
            //            //    int inX = recordX;
            //            //    int inY = recordY;

            //            //    MoveCur(0, ref inX, ref inY);

            //            //    read = _bitmap.GetPixel(inX, inY);
            //            //    int value0 = read.R + read.G + read.B;

            //            //    inX = recordX;
            //            //    inY = recordY;

            //            //    MoveCur(2, ref inX, ref inY);

            //            //    read = _bitmap.GetPixel(inX, inY);
            //            //    int value2 = read.R + read.G + read.B;

            //            //    inX = recordX;
            //            //    inY = recordY;

            //            //    MoveCur(4, ref inX, ref inY);

            //            //    read = _bitmap.GetPixel(inX, inY);
            //            //    int value4 = read.R + read.G + read.B;

            //            //    inX = recordX;
            //            //    inY = recordY;

            //            //    MoveCur(6, ref inX, ref inY);

            //            //    read = _bitmap.GetPixel(inX, inY);
            //            //    int value6 = read.R + read.G + read.B;

            //            //    if(value0 == noData || value2 == noData || value4 == noData || value6 == noData)
            //            //    {
            //            //        _bitmap.SetPixel(curX, curY, Color.Red);

            //            //        recordX = curX;
            //            //        recordY = curY;

            //            //        break;
            //            //    }
            //            //}

            //            if (direction == 0)
            //            {
            //                before = curValue;
            //                value0 = curValue;
            //            }

            //            if (before != noData && curValue == noData)
            //            {
            //                curX = recordX;
            //                curY = recordY;

            //                MoveCur(direction - 1, ref curX, ref curY);

            //                _bitmap.SetPixel(curX, curY, Color.Red);

            //                recordX = curX;
            //                recordY = curY;

            //                break;
            //            }

            //            if (before == noData && curValue != noData)
            //            {
            //                _bitmap.SetPixel(curX, curY, Color.Red);

            //                recordX = curX;
            //                recordY = curY;

            //                break;
            //            }

            //            before = curValue;

            //            direction++;
            //        }

            //    } while (!(recordX == startX && recordY == startY));
                
            //}
            pictureBox1.Image = _bitmap;
        }



        /// <summary>
        /// 3 2 1
        /// 4 S 0(8)
        /// 5 6 7
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="curX"></param>
        /// <param name="curY"></param>
        private void MoveCur(int direction, ref int curX, ref int curY)
        {
            switch (direction)
            {
                case 0:
                    {
                        curX++;
                    }
                    break;
                case 1:
                    {
                        curX++;
                        curY--;
                    }
                    break;
                case 2:
                    {
                        curY--;
                    }
                    break;
                case 3:
                    {
                        curX--;
                        curY--;
                    }
                    break;
                case 4:
                    {
                        curX--;
                    }
                    break;
                case 5:
                    {
                        curX--;
                        curY++;
                    }
                    break;
                case 6:
                    {
                        curY++;
                    }
                    break;
                case 7:
                    {
                        curX++;
                        curY++;
                    }
                    break;
                case 8:
                    {
                        curX++;
                    }
                    break;
                default:
                    break;
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            StringBuilder stringBuilder = new StringBuilder("常见影像格式|*.IMG;*.TIF;*.TIFF|常见图片格式|*.JPG;*.PNG;*.GIF");
            Dictionary<String, String> dic = GdalConfiguration.GetDriverExtDic();
            foreach (String val in dic.Values)
            {
                stringBuilder.Append("|");
                stringBuilder.Append(val);
            }

            openFileDialog.Filter = stringBuilder.ToString();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_imagePath = openFileDialog.FileName;
            }

            ReadImage();
        }

        private void ClearAll()
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;

            richTextBox1.Text = "";

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
    }
}

