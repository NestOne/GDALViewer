using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OSGeo.GDAL;

namespace GDALViewer
{
    public partial class FormNC2Tiff : Form
    {
        public FormNC2Tiff()
        {
            InitializeComponent();

            dateTimePickerTime.Enabled = false;
            groupboxGeoTransform.Enabled = false;
            comboBoxUnit.SelectedIndex = 2; // 默认选中 '日'
        }

        private void buttonNCPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "NetCDF File | *.nc";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxNCPath.Text = fileDialog.FileName;
            }
        }

        private void buttonTiffOutputPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxTiffOutputPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBoxNCPath.Text))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(textBoxNCPath.Text);
                Dataset dataset = Gdal.Open(file.FullName, Access.GA_ReadOnly);
                Driver tiffDriver = Gdal.GetDriverByName("GTIFF");
               

                if(tiffDriver == null)
                {
                    MessageBox.Show("Create GeoTiff driver failed");
                    return;
                }

                Driver memDriver = Gdal.GetDriverByName("MEM");
                //Dataset memCopyDt = memDriver.CreateCopy("", dataset, 0, null, null, "Sample Data");

                String outputPath = textBoxTiffOutputPath.Text;
                for (int i = 1; i <= dataset.RasterCount; i++)
                {
                    Band band = dataset.GetRasterBand(i);
                    int width = band.XSize;
                    int height = band.YSize;
                    var dataType = band.DataType;
                    byte[] a = new byte[width * height * 8];

                    var res = band.ReadRaster(0, 0, width, height, a, width, height, 0, 0);

                    Dataset memDt = memDriver.Create("", width, height, 1, dataType, null);
                    
                    Band newBand = memDt.GetRasterBand(1);
                    res = newBand.WriteRaster(0, 0, width, height, a, width, height, 0, 0);

                    String timeString = band.GetMetadataItem("NETCDF_DIM_time", "");
                    String fileTimeStr = "";
                    DateTime fileDateTime = DateTime.Now;
                    if (CalcTimedFileName(timeString, out fileTimeStr, out fileDateTime))
                    {
                        string[] domains = band.GetMetadataDomainList();
                        foreach (string domain in domains)
                        {
                            string[] metas = band.GetMetadata(domain);
                            // 将记录的时间替换为具体的时间
                            string[] converted = Array.ConvertAll(metas, s => s.StartsWith("NETCDF_DIM_time") ? "NETCDF_DIM_time=" + fileDateTime.ToString("yyyy/MM/dd HH:mm:ss") : s);
                            memDt.SetMetadata(converted, domain);

                            double top, left, bottom, right;
                            if(checkboxGeoTransform.Checked &&
                                Double.TryParse(textBoxTop.Text, out top) &&
                                Double.TryParse(textBoxLeft.Text, out left) &&
                                Double.TryParse(textBoxBottom.Text, out bottom) &&
                                Double.TryParse(textBoxRight.Text, out right))
                            {
                                double xResolution = (right - left) / (double)band.XSize;
                                double yResolution = (top - bottom) / (double)band.YSize;

                                // geotransform[0] = top left x
                                // geotransform[1] = w - e pixel resolution
                                // geotransform[2] = 0
                                // geotransform[3] = top left y
                                // geotransform[4] = 0
                                // geotransform[5] = n - s pixel resolution(negative value)

                                double[] geotransform = new double[6];
                                geotransform[0] = left;
                                geotransform[1] = xResolution;
                                geotransform[2] = 0;
                                geotransform[3] = top;
                                geotransform[4] = 0;
                                geotransform[5] = yResolution;

                                memDt.SetGeoTransform(geotransform);
                            }
                        }

                        string outputFilePath = System.IO.Path.Combine(outputPath, file.Name + "-" + fileTimeStr + ".tiff");

                        string[] options = new string[] { "TILED=YES" , "COMPRESS=LZW" };
                        Dataset copyDt = tiffDriver.CreateCopy(outputFilePath, memDt, 0, options, null, "");
                        copyDt.Dispose();
                    }
                    newBand.Dispose();
                    memDt.Dispose();

                    a = null;
                }

                dataset.Dispose();
            }

            MessageBox.Show("NetCDF to Tiff done!");
        }

        private bool CalcTimedFileName(string timeString, out string timeStr2File, out DateTime fileDateTime)
        {
            long timeValue = 0;
            if (Int64.TryParse(timeString, out timeValue))
            {
                DateTime startDate = dateTimePickerDate.Value;
                fileDateTime = startDate;
                bool hasTime = checkBoxStartTime.Checked;
                if (hasTime)
                {
                    string date2String = startDate.ToString("yyyy/MM/dd");
                    string time2String = dateTimePickerTime.Value.ToString(" HHmmss");

                    fileDateTime = DateTime.ParseExact(date2String + time2String, "yyyy/MM/dd HHmmss", System.Globalization.CultureInfo.CurrentCulture);
                }
                else
                {
                    // 去掉时间内容
                    fileDateTime = new DateTime(fileDateTime.Year, fileDateTime.Month, fileDateTime.Day);
                }

                switch (comboBoxUnit.SelectedIndex)
                {
                    case 0: // 年
                        fileDateTime = fileDateTime.AddYears((int)timeValue);
                        break;
                    case 1: // 月
                        fileDateTime = fileDateTime.AddMonths((int)timeValue);
                        break;
                    case 2: // 日
                        fileDateTime = fileDateTime.AddDays(timeValue);
                        break;
                    case 3: // 时
                        fileDateTime = fileDateTime.AddHours(timeValue);
                        break;
                    case 4: // 分
                        fileDateTime = fileDateTime.AddMinutes(timeValue);
                        break;
                    case 5: // 秒
                        fileDateTime = fileDateTime.AddSeconds(timeValue);
                        break;
                }

                timeStr2File = hasTime ? fileDateTime.ToString("yyyy.MM.dd-HHmmss") : fileDateTime.ToString("yyyy.MM.dd");

                return true;
            }

            timeStr2File = "";
            fileDateTime = DateTime.Now;

            return false;
        }

        private void checkBoxStartTime_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerTime.Enabled = checkBoxStartTime.Checked;
        }

        private void checkboxGeoTransform_CheckedChanged(object sender, EventArgs e)
        {
            groupboxGeoTransform.Enabled = checkboxGeoTransform.Checked;
        }
    }
}
