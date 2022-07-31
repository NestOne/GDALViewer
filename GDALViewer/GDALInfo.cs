using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDALViewer
{
    /******************************************************************************
 * $Id$
 *
 * Name:     GDALInfo.cs
 * Project:  GDAL CSharp Interface
 * Purpose:  A sample app to read GDAL raster data information.
 * Author:   Tamas Szekeres, szekerest@gmail.com
 *
 ******************************************************************************
 * Copyright (c) 2007, Tamas Szekeres
 *
 * Permission is hereby granted, free of charge, to any person obtaining a
 * copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 *****************************************************************************/

    using System;

    using OSGeo.GDAL;
    using OSGeo.OSR;


    /**
     * <p>Title: GDAL C# GDALRead example.</p>
     * <p>Description: A sample app to read GDAL raster data information.</p>
     * @author Tamas Szekeres (szekerest@gmail.com)
     * @version 1.0
     */



    /// <summary>
    /// A C# based sample to read GDAL raster data information.
    /// </summary>

    class GDALInfo
    {

        public static String GetInfo(Dataset ds)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                if (ds == null)
                {
                    return "";
                }

                //builder.AppendLine("  Projection: " + ds.GetProjectionRef());
               
                
                /* -------------------------------------------------------------------- */
                /*      Get driver                                                      */
                /* -------------------------------------------------------------------- */
                Driver drv = ds.GetDriver();
                
                if (drv == null)
                {
                    return "Can't get driver.";
                }

                builder.AppendLine("Driver " + drv.ShortName + "/" + drv.LongName);

                string[] fileList = ds.GetFileList();
                if (fileList.Length > 0)
                {
                    builder.AppendLine("Files:");
                    for (int iMeta = 0; iMeta < fileList.Length; iMeta++)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(fileList[iMeta]);
                        String fileName = Encoding.UTF8.GetString(bytes);
                        builder.AppendLine("      " + fileName);
                    }
                }
                builder.AppendLine("BandCount: " + ds.RasterCount);
                builder.AppendLine("Size is " + ds.RasterXSize + ", " + ds.RasterYSize);

                /* -------------------------------------------------------------------- */
                /*      Report projection.                                              */
                /* -------------------------------------------------------------------- */
                string projection = ds.GetProjectionRef();
                if (projection != null)
                {
                    SpatialReference srs = new SpatialReference(null);
                    if (srs.ImportFromWkt(ref projection) == 0)
                    {
                        string wkt;
                        srs.ExportToPrettyWkt(out wkt, 0);
                        builder.AppendLine("Coordinate System is:");
                        builder.AppendLine(wkt);
                    }
                    else
                    {
                        builder.AppendLine("Coordinate System is:");
                        builder.AppendLine(projection);
                    }
                }

                /* -------------------------------------------------------------------- */
                /*      Report GCPs.                                                    */
                /* -------------------------------------------------------------------- */
                if (ds.GetGCPCount() > 0)
                {
                    builder.AppendLine("GCP Projection: " + ds.GetGCPProjection());
                    GCP[] GCPs = ds.GetGCPs();
                    for (int i = 0; i < ds.GetGCPCount(); i++)
                    {
                        builder.AppendLine("GCP[" + i + "]: Id=" + GCPs[i].Id + ", Info=" + GCPs[i].Info);
                        builder.AppendLine("          (" + GCPs[i].GCPPixel + "," + GCPs[i].GCPLine + ") -> ("
                                    + GCPs[i].GCPX + "," + GCPs[i].GCPY + "," + GCPs[i].GCPZ + ")");
                        builder.AppendLine("");
                    }
                    builder.AppendLine("");

                    double[] geotransform = new double[6];
                    Gdal.GCPsToGeoTransform(GCPs, geotransform, 0);
                    builder.AppendLine("GCP Equivalent geotransformation parameters: " + ds.GetGCPProjection());
                    for (int i = 0; i < 6; i++)
                        builder.AppendLine("t[" + i + "] = " + geotransform[i].ToString());
                    builder.AppendLine("");
                }

                double[] transform = GetGeoTransform(ds);
                builder.AppendLine("Origin = (" + GDALInfoGetPosition(transform, 0.0, 0.0) + ")");
                builder.AppendLine("Pixel Size = (" + transform[1].ToString("f16") + "," + transform[5].ToString("f16") + ")");

                /* -------------------------------------------------------------------- */
                /*      Get metadata                                                    */
                /* -------------------------------------------------------------------- */
                string[] metadata = ds.GetMetadata("");
                if (metadata.Length > 0)
                {
                    builder.AppendLine("Metadata:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                        builder.AppendLine("  " + metadata[iMeta]);
                    }
                }

                /* -------------------------------------------------------------------- */
                /*      Report "IMAGE_STRUCTURE" metadata.                              */
                /* -------------------------------------------------------------------- */
                metadata = ds.GetMetadata("IMAGE_STRUCTURE");
                if (metadata.Length > 0)
                {
                    builder.AppendLine("Image Structure Metadata:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                        builder.AppendLine("  " + metadata[iMeta]);
                    }
                }

                /* -------------------------------------------------------------------- */
                /*      Report subdatasets.                                             */
                /* -------------------------------------------------------------------- */
                metadata = ds.GetMetadata("SUBDATASETS");
                if (metadata.Length > 0)
                {
                    builder.AppendLine("  Subdatasets:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                        builder.AppendLine("    " + metadata[iMeta]);
                    }
                    builder.AppendLine("");
                }

                /* -------------------------------------------------------------------- */
                /*      Report geolocation.                                             */
                /* -------------------------------------------------------------------- */
                metadata = ds.GetMetadata("GEOLOCATION");
                if (metadata.Length > 0)
                {
                    builder.AppendLine("  Geolocation:");
                    for (int iMeta = 0; iMeta < metadata.Length; iMeta++)
                    {
                        builder.AppendLine("    " + metadata[iMeta]);
                    }
                    builder.AppendLine("");
                }

                /* -------------------------------------------------------------------- */
                /*      Report corners.                                                 */
                /* -------------------------------------------------------------------- */
                builder.AppendLine("Corner Coordinates:");
                builder.AppendLine("  Upper Left (" + GDALInfoGetPosition(transform, 0.0, 0.0) + ")");
                builder.AppendLine("  Lower Left (" + GDALInfoGetPosition(transform, 0.0, ds.RasterYSize) + ")");
                builder.AppendLine("  Upper Right (" + GDALInfoGetPosition(transform, ds.RasterXSize, 0.0) + ")");
                builder.AppendLine("  Lower Right (" + GDALInfoGetPosition(transform, ds.RasterXSize, ds.RasterYSize) + ")");
                builder.AppendLine("  Center (" + GDALInfoGetPosition(transform, ds.RasterXSize / 2, ds.RasterYSize / 2) + ")");
                builder.AppendLine("");

                

                /* -------------------------------------------------------------------- */
                /*      Get raster band                                                 */
                /* -------------------------------------------------------------------- */
                for (int iBand = 1; iBand <= ds.RasterCount; iBand++)
                {
                    Band band = ds.GetRasterBand(iBand);
                    int blockXSize, blockYSize;
                    band.GetBlockSize(out blockXSize, out blockYSize);
                
                    builder.Append("Band ");
                    builder.Append(iBand );
                    builder.Append(" Block=");
                    builder.Append(blockXSize);
                    builder.Append("x");
                    builder.Append(blockYSize);
                    builder.Append(", Type=");
                    builder.Append(Gdal.GetDataTypeName(band.DataType));
                    builder.Append(", ColorInterp=");
                    builder.Append(Gdal.GetColorInterpretationName(band.GetRasterColorInterpretation()));
               
                    double val;
                    int hasval;
                    band.GetMinimum(out val, out hasval);
                    if (hasval != 0) builder.Append(", Minimum=" + val.ToString());
                    band.GetMaximum(out val, out hasval);
                    if (hasval != 0) builder.Append(", Maximum=" + val.ToString());
                    band.GetNoDataValue(out val, out hasval);
                    if (hasval != 0) builder.Append(", NoDataValue=" + val.ToString());
                    band.GetOffset(out val, out hasval);
                    if (hasval != 0) builder.Append(", Offset=" + val.ToString());
                    band.GetScale(out val, out hasval);
                    if (hasval != 0) builder.Append(", Scale=" + val.ToString());
                    builder.AppendLine("");

                    if (band.GetOverviewCount() > 0)
                    {
                        builder.Append(" OverViews: ");
                        for (int iOver = 0; iOver < band.GetOverviewCount(); iOver++)
                        {
                            Band over = band.GetOverview(iOver);
                            builder.Append(over.XSize + "x" + over.YSize + ", ");
                            // builder.AppendLine("         DataType: " + over.DataType);
                            // builder.AppendLine("         Size (" + over.XSize + "," + over.YSize + ")");
                            //builder.AppendLine("         PaletteInterp: " + over.GetRasterColorInterpretation().ToString());
                        }
                        builder.AppendLine("");
                    }

                    ColorTable ct = band.GetRasterColorTable();
                    if (ct != null)
                    {
                        builder.AppendLine(" Band has a color table with " + ct.GetCount() + " entries.");
                    }

                    String des = band.GetDescription();
                    if (des != null && !String.IsNullOrWhiteSpace(des))
                    {
                        builder.AppendLine(" Description: " + band.GetDescription());
                    }

                    string[] bandMetadata = band.GetMetadata("");
                    if (bandMetadata.Length > 0)
                    {
                        builder.AppendLine("Metadata:");
                        for (int iMeta = 0; iMeta < bandMetadata.Length; iMeta++)
                        {
                            builder.AppendLine("  " + bandMetadata[iMeta]);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                return "Application error: " + e.Message;
            }

            return builder.ToString();
        }

        private static string GDALInfoGetPosition(double[] adfGeoTransform, double x, double y)
        {
            double dfGeoX, dfGeoY;
           // double[] adfGeoTransform = GetGeoTransform(ds);

            dfGeoX = adfGeoTransform[0] + adfGeoTransform[1] * x + adfGeoTransform[2] * y;
            dfGeoY = adfGeoTransform[3] + adfGeoTransform[4] * x + adfGeoTransform[5] * y;

            return dfGeoX.ToString("f7") + ", " + dfGeoY.ToString("f7");
        }

        private static double[] GetGeoTransform(Dataset ds)
        {
            double[] adfGeoTransform = new double[6];
            ds.GetGeoTransform(adfGeoTransform);
            return adfGeoTransform;
        }
    }
}
