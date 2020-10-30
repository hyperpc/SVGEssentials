using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleTesting.MichiganMap
{
    public class ProcessCoord
    {
        public string GenSVG()
        {
            var sb_SVG = new StringBuilder();

            //0. parameter: width=300, decimal=3 degree
            //              minX, maxX, minY, maxY
            var width_svg = 300;
            var degree_d = 3;
            var minX = decimal.MaxValue;
            var minY = decimal.MaxValue;
            var maxX = decimal.MinValue;
            var maxY = decimal.MinValue;

            //1. read file
            var datafile = @"D:\Workspace\local\ILP_Test\SimpleTesting\MichiganMap\michigan.dat";
            if (!File.Exists(datafile))
                return sb_SVG.ToString();
            using (var fs = new FileStream(datafile, FileMode.Open, FileAccess.Read))
            {
                using (var st = new StreamReader(fs))
                {
                    var path_coord = new StringBuilder();
                    var polyline_no = 1;
                    var lineCount = 0;
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
                            var cx_s = lineArr[0];
                            if(Double.TryParse(cx_s, out cx_f))
                            {
                                coorX = (decimal)cx_f;
                            }
                            else
                            {
                                continue;
                            }
                            var cy_f = 0d;
                            var cy_s = lineArr[1];
                            if (Double.TryParse(cy_s, out cy_f))
                            {
                                coorY = (decimal)cy_f;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (lineArr_Length == 3)
                        {
                            var cx_f = 0d;
                            var cx_s = lineArr[1];
                            if (Double.TryParse(cx_s, out cx_f))
                            {
                                coorX = (decimal)cx_f;
                            }
                            else
                            {
                                continue;
                            }
                            var cy_f = 0d;
                            var cy_s = lineArr[2];
                            if (Double.TryParse(cy_s, out cy_f))
                            {
                                coorY = (decimal)cy_f;
                            }
                            else
                            {
                                continue;
                            }
                            path_coord.AppendLine("<polyline id=\"poly"+ polyline_no + "\" points=\"");
                        }
                        else
                        {
                            continue;
                        }

                        minX = (coorX < minX) ? coorX : minX;
                        minY = (coorY < minY) ? coorY : minY;
                        maxX = (coorX > maxX) ? coorX : maxX;
                        maxY = (coorY > maxY) ? coorY : maxY;
                    }
                }
            }
            //2. check line content (END, Array.Length<2)

            //3. process x,y
            //   decimal x = (decimal)0.451584200000000E+02;
            //$coord = $min_y + ($max_y - $coord); 

            //4. 8 coord each line

            //

            return sb_SVG.ToString();
        }
    }
}
