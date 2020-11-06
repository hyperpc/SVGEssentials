using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleTesting.MichiganMap
{
    public class ProcessCoord
    {
        public void GenSVG()
        {
            //0. parameter: width=300, decimal=3 degree
            var width_svg = 300;

            //1. load data table
            var dataSet = LoadDataIntoTable();
            if (dataSet == null)
                return;

            var coords = dataSet.Tables["Coords"].AsEnumerable();
            var coords_X = from c in coords select c.Field<decimal>("CoordX");
            var coords_Y = from c in coords select c.Field<decimal>("CoordY");
            var minX = coords_X.ToList().Min();
            var minY = coords_Y.ToList().Min();
            var maxX = coords_X.ToList().Max();
            var maxY = coords_Y.ToList().Max();
            var deltaX = maxX - minX;
            var deltaY = maxY - minY;
            var scale = width_svg / deltaX;
            var height_tmp = deltaY * scale;
            var height_svg = (int)(height_tmp + (decimal)0.5);

            var svg_doc = "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.0//EN\" \"http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd\">";
            var svg_wh = string.Format("<svg width=\"{0}\" height=\"{1}\"", width_svg, height_svg);
            var svg_ns = "    xmlns=\"http://www.w3.org/2000/svg\"";
            var svg_vb = string.Format("    viewBox=\"{0} {1} {2} {3}\">", minX, minY, deltaX, deltaY);
            var svg_title = "    <title>Map constructed from michigan.dat</title>";
            var svg_top_g = "    <g style=\"fill: none; stroke: black; stroke-width: 0.0266839033333333\">";

            var svgfile = GenerateSVGFile();
            using(var sr=new StreamWriter(svgfile, true, Encoding.UTF8))
            {
                sr.WriteLine(svg_doc);
                sr.WriteLine(svg_wh);
                sr.WriteLine(svg_ns);
                sr.WriteLine(svg_vb);
                sr.WriteLine(svg_title);
                sr.WriteLine("");
                sr.WriteLine(svg_top_g);
            }

            var polygons_no = from c in coords select c.Field<int>("PolygonNo");
            var maxPloygonNo = polygons_no.ToList().Max();
            for(int i=1;i<= maxPloygonNo; i++)
            {
                using (var sr = new StreamWriter(svgfile, true, Encoding.UTF8))
                {
                    sr.WriteLine();
                    var svg_polygon = string.Format("        <polyline id=\"poly{0}\" points=\"", i);
                    if (i == 4)
                    {
                        sr.WriteLine("        <!--data issue: first or last coordination(x,y) should be removed, or some horizontal lines drew.-->");
                        svg_polygon = string.Format("        <polyline id=\"poly{0}\" stroke=\"green\" points=\"", i);
                    }
                    sr.WriteLine(svg_polygon);
                }

                var polygons_current = coords.AsEnumerable()
                                        .Where(c => c.Field<int>("PolygonNo") == i)
                                        .OrderBy(c=>c.Field<int>("CoordIndex"))
                                        .Select(c => c);
                
                var coordIndex_current = from c in polygons_current select c.Field<int>("CoordIndex");
                var maxCoordIndex = coordIndex_current.ToList().Max();
                var sbCoordsLine = new StringBuilder();
                var newLineCount = 0;
                for(int j = 0; j < maxCoordIndex; j++)
                {
                    var coordX_c = polygons_current
                                    .Where(c => c.Field<int>("CoordIndex") == (j + 1))
                                    .Select(c => c.Field<decimal>("CoordX"))
                                    .FirstOrDefault();
                    var coordY_c = polygons_current
                                    .Where(c => c.Field<int>("CoordIndex") == (j + 1))
                                    .Select(c => c.Field<decimal>("CoordY"))
                                    .FirstOrDefault();

                    //var degree_d = 3;
                    var coord_X = ((decimal)((int)(coordX_c * 1000)) / 1000);
                    var coord_Y = ((decimal)((int)((minY + maxY - coordY_c) * 1000)) / 1000);
                    if (coord_X == (decimal)0 || coord_Y == 0) { continue; }
                    sbCoordsLine.AppendFormat("{0} {1} ", coord_X, coord_Y);
                    newLineCount++;
                    if (newLineCount % 8 == 0)
                    {
                        using (var sr = new StreamWriter(svgfile, true, Encoding.UTF8))
                        {
                            var sb_tmp = new StringBuilder();
                            sr.Write("                ");
                            sr.Write(sbCoordsLine.ToString().Trim());
                            sr.WriteLine();
                            sbCoordsLine.Clear();
                        }
                    }
                }

                using (var sr = new StreamWriter(svgfile, true, Encoding.UTF8))
                {
                    var svg_polygon_close = string.Format("        \"/>");
                    sr.WriteLine(svg_polygon_close);
                }
            }

            using (var sr = new StreamWriter(svgfile, true, Encoding.UTF8))
            {
                sr.WriteLine();
                sr.WriteLine("    </g>");
                sr.WriteLine("</svg>");
            }
        }

        private DataSet LoadDataIntoTable()
        {
            #region create data table in Memory
            DataSet dataSet;
            var table = new DataTable("Coords");

            var column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "CoordIndex";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "PolygonNo";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "CoordX";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "CoordY";
            table.Columns.Add(column);

            dataSet = new DataSet();
            dataSet.Tables.Add(table);
            #endregion

            var datafile = @"D:\Workspace\local\ILP_Test\SimpleTesting\MichiganMap\michigan.dat";
            if (!File.Exists(datafile))
                return null;

            #region Read file data into data table
            using (var fs = new FileStream(datafile, FileMode.Open, FileAccess.Read))
            {
                using (var st = new StreamReader(fs))
                {
                    var polyline_no = 0;
                    var indx = 1;

                    while (!st.EndOfStream)
                    {
                        var line = st.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        decimal coorX = decimal.MinValue;
                        decimal coorY = decimal.MinValue;
                        var lineArr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var lineArr_Length = lineArr.Length;
                        if (lineArr_Length == 2)
                        {
                            var cx_f = 0d;
                            if (!Double.TryParse(lineArr[0], out cx_f))
                            {
                                continue;
                            }
                            coorX = (decimal)cx_f;
                            var cy_f = 0d;
                            if (!Double.TryParse(lineArr[1], out cy_f))
                            {
                                continue;
                            }
                            coorY = (decimal)cy_f;
                            DataRow row = table.NewRow();
                            row["CoordIndex"] = indx;
                            row["PolygonNo"] = polyline_no;
                            row["CoordX"] = coorX;
                            row["CoordY"] = coorY;
                            table.Rows.Add(row);
                            indx++;
                        }
                        else if (lineArr_Length == 3)
                        {
                            var cx_f = 0d;
                            if (!Double.TryParse(lineArr[1], out cx_f))
                            {
                                continue;
                            }
                            coorX = (decimal)cx_f;
                            var cy_f = 0d;
                            if (!Double.TryParse(lineArr[2], out cy_f))
                            {
                                continue;
                            }
                            coorY = (decimal)cy_f;
                            polyline_no++;
                            DataRow row = table.NewRow();
                            row["CoordIndex"] = indx;
                            row["PolygonNo"] = polyline_no;
                            row["CoordX"] = coorX;
                            row["CoordY"] = coorY;
                            table.Rows.Add(row);
                            indx++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            #endregion

            return dataSet;
        }

        private string GenerateSVGFile()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(rootPath, "files");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fileFullPath = string.Format("{0}/{1}", filePath.Trim('/').Trim('\\'), "michigan.svg");
            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }

            return fileFullPath;
        }
    }
}
