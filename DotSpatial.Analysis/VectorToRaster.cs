// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;

using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;

namespace DotSpatial.Analysis
{
    /// <summary>
    /// VectorToRaster uses the help of GDI+ to create a bitmap, draws the features to
    /// the bitmap, and then converts the color coded cells to a raster format.
    /// This is limited to bitmaps that are within the 8, 000 x 8, 0000 size limits.
    /// </summary>
    public static class VectorToRaster
    {
        #region Methods

        /// <summary>
        /// Creates a new raster with the specified cell size.  If the cell size
        /// is zero, this will default to the shorter of the width or height
        /// divided by 256.  If the cell size produces a raster that is greater
        /// than 8, 000 pixels in either dimension, it will be re-sized to
        /// create an 8, 000 length or width raster.
        /// </summary>
        /// <param name="fs">The featureset to convert to a raster.</param>
        /// <param name="cellSize">The double extent of the cell.</param>
        /// <param name="fieldName">The integer field index of the file.</param>
        /// <param name="outputFileName">The fileName of the raster to create.</param>
        /// <returns>The resulting IRaster generated by the ToRaster operation.</returns>
        public static IRaster ToRaster(IFeatureSet fs, double cellSize, string fieldName, string outputFileName)
        {
            return ToRaster(fs, fs.Extent, cellSize, fieldName, outputFileName, string.Empty, new string[] { }, null);
        }

        /// <summary>
        /// Creates a new raster with the specified cell size.  If the cell size
        /// is zero, this will default to the shorter of the width or height
        /// divided by 256.  If the cell size produces a raster that is greater
        /// than 8, 000 pixels in either dimension, it will be re-sized to
        /// create an 8, 000 length or width raster.
        /// </summary>
        /// <param name="fs">The featureset to convert to a raster.</param>
        /// <param name="cellSize">The double extent of the cell.</param>
        /// <param name="fieldName">The integer field index of the file.</param>
        /// <param name="outputFileName">The fileName of the raster to create.</param>
        /// <param name="driverCode">The optional GDAL driver code to use if using GDAL
        /// for a format that is not discernable from the file extension.  An empty string
        ///  is usually perfectly acceptable here.</param>
        /// <param name="options">For GDAL rasters, they can be created with optional parameters
        ///  passed in as a string array.  In most cases an empty string is perfectly acceptable.</param>
        /// <param name="progressHandler">An interface for handling the progress messages.</param>
        /// <returns>Generates a raster from the vectors.</returns>
        public static IRaster ToRaster(IFeatureSet fs, double cellSize, string fieldName, string outputFileName, string driverCode, string[] options, IProgressHandler progressHandler)
        {
            return ToRaster(fs, fs.Extent, cellSize, fieldName, outputFileName, driverCode, options, progressHandler);
        }

        /// <summary>
        /// Creates a new raster with the specified cell size.  If the cell size
        /// is zero, this will default to the shorter of the width or height
        /// divided by 256.  If the cell size produces a raster that is greater
        /// than 8, 000 pixels in either dimension, it will be re-sized to
        /// create an 8, 000 length or width raster.
        /// </summary>
        /// <param name="fs">The featureset to convert to a raster.</param>
        /// <param name="extent">Force the raster to this specified extent.</param>
        /// <param name="cellSize">The double extent of the cell.</param>
        /// <param name="fieldName">The integer field index of the file.</param>
        /// <param name="outputFileName">The fileName of the raster to create.</param>
        /// <param name="driverCode">The optional GDAL driver code to use if using GDAL
        /// for a format that is not discernable from the file extension.  An empty string
        ///  is usually perfectly acceptable here.</param>
        /// <param name="options">For GDAL rasters, they can be created with optional parameters
        ///  passed in as a string array.  In most cases an empty string is perfectly acceptable.</param>
        /// <param name="progressHandler">An interface for handling the progress messages.</param>
        /// <returns>Generates a raster from the vectors.</returns>
        public static IRaster ToRaster(IFeatureSet fs, Extent extent, double cellSize, string fieldName, string outputFileName, string driverCode, string[] options, IProgressHandler progressHandler)
        {
            Extent env = extent;
            if (cellSize == 0)
            {
                if (env.Width < env.Height)
                {
                    cellSize = env.Width / 256;
                }
                else
                {
                    cellSize = env.Height / 256;
                }
            }

            int w = (int)Math.Ceiling(env.Width / cellSize);
            if (w > 8000)
            {
                w = 8000;
                cellSize = env.Width / 8000;
            }

            int h = (int)Math.Ceiling(env.Height / cellSize);
            if (h > 8000)
            {
                h = 8000;
            }

            Bitmap bmp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.None;
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            Hashtable colorTable;
            MapArgs args = new MapArgs(new Rectangle(0, 0, w, h), env, g);

            switch (fs.FeatureType)
            {
                case FeatureType.Polygon:
                    {
                        MapPolygonLayer mpl = new MapPolygonLayer(fs);
                        PolygonScheme ps = new PolygonScheme();
                        colorTable = ps.GenerateUniqueColors(fs, fieldName);
                        mpl.Symbology = ps;

                        // first draw the normal colors and then the selection colors on top
                        mpl.DrawRegions(args, new List<Extent> { env }, false);
                        mpl.DrawRegions(args, new List<Extent> { env }, true);
                    }

                    break;
                case FeatureType.Line:
                    {
                        MapLineLayer mpl = new MapLineLayer(fs);
                        LineScheme ps = new LineScheme();
                        colorTable = ps.GenerateUniqueColors(fs, fieldName);
                        mpl.Symbology = ps;

                        // first draw the normal colors and then the selection colors on top
                        mpl.DrawRegions(args, new List<Extent> { env }, false);
                        mpl.DrawRegions(args, new List<Extent> { env }, true);
                    }

                    break;
                default:
                    {
                        MapPointLayer mpl = new MapPointLayer(fs);
                        PointScheme ps = new PointScheme();
                        colorTable = ps.GenerateUniqueColors(fs, fieldName);
                        mpl.Symbology = ps;

                        // first draw the normal colors and then the selection colors on top
                        mpl.DrawRegions(args, new List<Extent> { env }, false);
                        mpl.DrawRegions(args, new List<Extent> { env }, true);
                    }

                    break;
            }

            Type tp = fieldName == "FID" ? typeof(int) : fs.DataTable.Columns[fieldName].DataType;

            // We will try to convert to double if it is a string
            if (tp == typeof(string))
            {
                tp = typeof(double);
            }

            InRamImageData image = new InRamImageData(bmp, env);
            ProgressMeter pm = new ProgressMeter(progressHandler, "Converting To Raster Cells", h);

            var output = Raster.Create(outputFileName, driverCode, w, h, 1, tp, options);
            output.Bounds = new RasterBounds(h, w, env);

            double noDataValue = output.NoDataValue;

            if (fieldName != "FID")
            {
                // We can't use this method to calculate Max on a non-existent FID field.
                double dtMax = Convert.ToDouble(fs.DataTable.Compute("Max(" + fieldName + ")", string.Empty));
                double dtMin = Convert.ToDouble(fs.DataTable.Compute("Min(" + fieldName + ")", string.Empty));

                if (dtMin <= noDataValue && dtMax >= noDataValue)
                {
                    if (dtMax != GetFieldValue(tp, "MaxValue"))
                    {
                        output.NoDataValue = noDataValue;
                    }
                    else if (dtMin != GetFieldValue(tp, "MinValue"))
                    {
                        output.NoDataValue = noDataValue;
                    }
                }
            }

            List<RcIndex> locations = new List<RcIndex>();
            List<string> failureList = new List<string>();
            for (int row = 0; row < h; row++)
            {
                for (int col = 0; col < w; col++)
                {
                    Color c = image.GetColor(row, col);
                    if (c.A == 0)
                    {
                        output.Value[row, col] = output.NoDataValue;
                    }
                    else
                    {
                        if (colorTable.ContainsKey(c) == false)
                        {
                            if (c.A < 125)
                            {
                                output.Value[row, col] = output.NoDataValue;
                                continue;
                            }

                            // Use a color matching distance to pick the closest member
                            object val = GetCellValue(w, h, row, col, image, c, colorTable, locations);

                            output.Value[row, col] = GetDouble(val, failureList);
                        }
                        else
                        {
                            output.Value[row, col] = GetDouble(colorTable[c], failureList);
                        }
                    }
                }

                pm.CurrentValue = row;
            }

            const int MaxIterations = 5;
            int iteration = 0;
            while (locations.Count > 0)
            {
                List<RcIndex> newLocations = new List<RcIndex>();
                foreach (RcIndex location in locations)
                {
                    object val = GetCellValue(w, h, location.Row, location.Column, image, image.GetColor(location.Row, location.Column), colorTable, newLocations);
                    output.Value[location.Row, location.Column] = GetDouble(val, failureList);
                }

                locations = newLocations;
                iteration++;
                if (iteration > MaxIterations)
                {
                    break;
                }
            }

            pm.Reset();
            return output;
        }

        private static object GetCellValue(int w, int h, int row, int col, IImageData image, Color c, Hashtable colorTable, ICollection<RcIndex> locations)
        {
            double dmin = double.MaxValue;
            object val = 0;
            bool empty = true;

            // Search 8 neighbor cells for likely blended neighbors
            // (otherwise distant shapes might match better incorrectly)
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == j && j == 0)
                    {
                        continue;
                    }

                    if (row + i < 0 || row + i >= h)
                    {
                        continue;
                    }

                    if (col + j < 0 || col + j >= w)
                    {
                        continue;
                    }

                    Color nc = image.GetColor(row + i, col + j);
                    if (colorTable.ContainsKey(nc) == false)
                    {
                        continue;
                    }

                    double d = ((nc.R - c.R) * (nc.R - c.R)) + ((nc.G - c.G) * (nc.G - c.G)) + ((nc.B - c.B) * (nc.B - c.B));
                    if (d >= dmin)
                    {
                        continue;
                    }

                    val = colorTable[nc];
                    dmin = d;
                    empty = false;
                    image.SetColor(row, col, nc);
                }
            }

            if (empty)
            {
                locations.Add(new RcIndex(row, col));
            }

            return val;
        }

        private static double GetDouble(object val, IList<string> failureList)
        {
            double dVal;
            string sVal = val.ToString();
            if (double.TryParse(sVal, out dVal) == false)
            {
                if (failureList.Contains(sVal))
                {
                    dVal = failureList.IndexOf(sVal);
                }
                else
                {
                    failureList.Add(sVal);
                    dVal = failureList.Count - 1;
                }
            }

            return dVal;
        }

        private static double GetFieldValue(Type tp, string fieldstr)
        {
            FieldInfo field = tp.GetField(fieldstr, BindingFlags.Public | BindingFlags.Static);
            if (field == null)
            {
                // There's no TypeArgumentException, unfortunately. You might want
                // to create one :)
                throw new InvalidOperationException("Invalid type argument for GetFieldValue: " + tp.Name);
            }

            return Convert.ToDouble(field.GetValue(null));
        }

        #endregion
    }
}