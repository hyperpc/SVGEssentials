using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleTesting.RedFlag
{
    public class ProcessStarCoord
    {
        public void GenSVG()
        {
            var svg_w = 900;
            var svg_h = 600;

            var dataSet = LoadDataIntoTable();
            if (dataSet == null)
                return;

            var svg_doc = "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.0//EN\" \"http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd\">";
            var svg_dim = string.Format("<svg width=\"{0}\" height=\"{1}\" viewBox=\"0 0 900 600\"", svg_w, svg_h);
            var svg_ns1 = "    xmlns=\"http://www.w3.org/2000/svg\"";
            var svg_ns2 = "    xmlns:xlink=\"http://www.w3.org/1999/xlink\">";
            var svg_title = "    <title>Red Flag constructed from starCoord.dat</title>";
            var svg_top_g = "    <g style=\"fill: none; stroke: none; \">";
            var svg_red_bg_full = "        <rect width=\"900\" height=\"600\" fill=\"red\" />";
            var svg_red_bg_lt = "        <rect width=\"450\" height=\"300\" fill=\"red\" transform=\"translate(0, 0)\" />";

            var file = GenerateSVGFile();
            using (var sr = new StreamWriter(file, true, Encoding.UTF8))
            {
                sr.WriteLine(svg_doc);
                sr.WriteLine(svg_dim);
                sr.WriteLine(svg_ns1);
                sr.WriteLine(svg_ns2);
                sr.WriteLine(svg_title);
                sr.WriteLine("");
                sr.WriteLine(svg_top_g);
                sr.WriteLine(svg_red_bg_full);
                sr.WriteLine(svg_red_bg_lt);
            }

            var coords = dataSet.Tables["Coords"].AsEnumerable();
            var star_no = from c in coords select c.Field<int>("StarNo");
            var maxStarNo = star_no.ToList().Max();
            for(int i=1;i<=maxStarNo; i++)
            {
                using(var sr = new StreamWriter(file, true, Encoding.UTF8))
                {
                    sr.WriteLine();
                    if (i == maxStarNo && i==5)
                    {
                        sr.WriteLine(string.Format("        <polygon id=\"little_star_{0}\" transform=\"scale(3) translate(50,50) rotate(14)\" fill=\"yellow\" stroke=\"yellow\"", i));
                    }
                    else
                    {
                        sr.WriteLine(string.Format("        <polygon id=\"little_star_{0}\" fill=\"yellow\" stroke=\"yellow\"", i));
                    }
                    sr.WriteLine("                points=\"");
                }
                var polygons_current = coords.AsEnumerable()
                                        .Where(c => c.Field<int>("StarNo") == i)
                                        .OrderBy(c => c.Field<int>("CoordIndex"))
                                        .Select(c => c);

                var coordIndex_current = from c in polygons_current select c.Field<int>("CoordIndex");
                var maxCoordIndex = coordIndex_current.ToList().Max();
                var sbCoordsLine = new StringBuilder();
                var newLineCount = 0;
                for (int j = 0; j < maxCoordIndex; j++)
                {
                    var coord_X = polygons_current
                                    .Where(c => c.Field<int>("CoordIndex") == (j + 1))
                                    .Select(c => c.Field<double>("CoordX"))
                                    .FirstOrDefault();
                    var coord_Y = polygons_current
                                    .Where(c => c.Field<int>("CoordIndex") == (j + 1))
                                    .Select(c => c.Field<double>("CoordY"))
                                    .FirstOrDefault();

                    if (coord_X == (double)0 || coord_Y == (double)0) { continue; }
                    sbCoordsLine.AppendFormat("{0} {1} ", coord_X, coord_Y);
                    newLineCount++;
                    if (newLineCount % 2 == 0)
                    {
                        using (var sr = new StreamWriter(file, true, Encoding.UTF8))
                        {
                            var sb_tmp = new StringBuilder();
                            sr.Write("                ");
                            sr.Write(sbCoordsLine.ToString().Trim());
                            sr.WriteLine();
                            sbCoordsLine.Clear();
                        }
                    }
                }

                using (var sr = new StreamWriter(file, true, Encoding.UTF8))
                {
                    sr.WriteLine("        \"/>");
                }
            }

            using (var sr = new StreamWriter(file, true, Encoding.UTF8))
            {
                // draw main star: (360, 210)[scale(3)] ->(1080, 630)[translate(-210, -52)] -> (150, 150)
                //sr.WriteLine("        <use xlink:href=\"#little_star_3\" transform=\"scale(3) translate(-210, -52) \"/>");

                sr.WriteLine("        <line x1=\"0\" x2=\"450\" y1=\"150\" y2=\"150\" stroke=\"green\" fill=\"green\"/>");
                sr.WriteLine("        <line x1=\"150\" x2=\"150\" y1=\"0\" y2=\"300\" stroke=\"green\" fill=\"green\"/>");
                sr.WriteLine("        <line x1=\"0\" x2=\"900\" y1=\"300\" y2=\"300\" stroke=\"blue\" fill=\"blue\"/>");
                sr.WriteLine("        <line x1=\"450\" x2=\"450\" y1=\"0\" y2=\"600\" stroke=\"blue\" fill=\"blue\"/>");
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
            column.ColumnName = "StarNo";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "CoordX";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "CoordY";
            table.Columns.Add(column);

            dataSet = new DataSet();
            dataSet.Tables.Add(table);
            #endregion

            var datafile = @"D:\Workspace\local\ILP_Test\SimpleTesting\RedFlag\starCoord_900_600.dat";
            if (!File.Exists(datafile))
                return null;

            #region Read file data into data table
            using (var fs = new FileStream(datafile, FileMode.Open, FileAccess.Read))
            {
                using (var st = new StreamReader(fs))
                {
                    var star_no = 0;
                    var indx = 1;

                    while (!st.EndOfStream)
                    {
                        var line = st.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        var coorX = 0d;
                        var coorY = 0d;
                        var lineArr = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        var lineArr_Length = lineArr.Length;
                        if (lineArr_Length == 2)
                        {
                            var cx = lineArr[0];
                            if (!Double.TryParse(cx, out coorX))
                            {
                                continue;
                            }
                            var cy = lineArr[1];
                            if (!Double.TryParse(cy, out coorY))
                            {
                                continue;
                            }
                            DataRow row = table.NewRow();
                            row["CoordIndex"] = indx;
                            row["StarNo"] = star_no;
                            row["CoordX"] = coorX;
                            row["CoordY"] = coorY;
                            table.Rows.Add(row);
                            indx++;
                        }
                        else if (lineArr_Length == 1)
                        {
                            star_no++;
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
            var fileFullPath = string.Format("{0}/{1}", filePath.Trim('/').Trim('\\'), "redFlag.svg");
            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }

            return fileFullPath;
        }
    }
}
