using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTesting.RedFlag
{
    class CalStarCoord
    {
        /// <summary>
        /// Print first little star: (300, 60, 274, 75),
        /// and second little star: (360, 120, 330, 124)
        /// </summary>
        /// <param name="centerX">300</param>
        /// <param name="centerY">60</param>
        /// <param name="centerX">274</param>
        /// <param name="centerY">75</param>
        public void PrintLittleStarTop(int centerX, int centerY, int topX, int topY)
        {
            if (centerX == 300)
                Console.WriteLine("1");
            else
                Console.WriteLine("2");
            // 1
            var point_1 = new StarPoint { X = topX, Y = topY };
            Console.WriteLine($"{point_1.X},{point_1.Y}");
            // 2
            var point_2 = new StarPoint();
            point_2.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 1 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_2.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 1 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_2.X},{point_2.Y}");
            // 3
            var point_3 = new StarPoint();
            point_3.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 2 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_3.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 2 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_3.X},{point_3.Y}");
            // 4
            var point_4 = new StarPoint();
            point_4.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 3 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_4.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 3 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_4.X},{point_4.Y}");
            // 5
            var point_5 = new StarPoint();
            point_5.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 4 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_5.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 4 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_5.X},{point_5.Y}");
            // 6
            var point_6 = new StarPoint();
            point_6.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 5 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_6.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 5 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_6.X},{point_6.Y}");
            // 7
            var point_7 = new StarPoint();
            point_7.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 6 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_7.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 6 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_7.X},{point_7.Y}");
            // 8
            var point_8 = new StarPoint();
            point_8.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 7 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_8.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 7 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_8.X},{point_8.Y}");
            // 9
            var point_9 = new StarPoint();
            point_9.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 8 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_9.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 8 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_9.X},{point_9.Y}");
            // 10
            var point_10 = new StarPoint();
            point_10.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 9 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_10.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 9 + Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_10.X},{point_10.Y}");
        }
        /// <summary>
        /// Print third little star: (360, 210, 331, 202),
        /// and main start: (0, 0, -29, -2)
        /// </summary>
        /// <param name="centerX">360</param>
        /// <param name="centerY">210</param>
        /// <param name="topX">331</param>
        /// <param name="topY">202</param>
        public void PrintLittleStarMid(int centerX, int centerY, int topX, int topY)
        {
            if (centerX == 0)
            {
                Console.WriteLine("5");
            }
            else
            {
                Console.WriteLine("3");
            }
            // 1
            var point_1 = new StarPoint { X = topX, Y = topY };
            Console.WriteLine($"{point_1.X},{point_1.Y}");
            // 2
            var point_2 = new StarPoint();
            point_2.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 1 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_2.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 1 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_2.X},{point_2.Y}");
            // 3
            var point_3 = new StarPoint();
            point_3.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 2 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_3.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 2 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_3.X},{point_3.Y}");
            // 4
            var point_4 = new StarPoint();
            point_4.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 3 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_4.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 3 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_4.X},{point_4.Y}");
            // 5
            var point_5 = new StarPoint();
            point_5.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 4 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_5.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 4 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_5.X},{point_5.Y}");
            // 6
            var point_6 = new StarPoint();
            point_6.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 5 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_6.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 5 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_6.X},{point_6.Y}");
            // 7
            var point_7 = new StarPoint();
            point_7.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 6 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_7.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 6 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_7.X},{point_7.Y}");
            // 8
            var point_8 = new StarPoint();
            point_8.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 7 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_8.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 7 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_8.X},{point_8.Y}");
            // 9
            var point_9 = new StarPoint();
            point_9.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 8 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_9.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 8 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_9.X},{point_9.Y}");
            // 10
            var point_10 = new StarPoint();
            point_10.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 9 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_10.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 9 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_10.X},{point_10.Y}");
        }
        /// <summary>
        /// Print forth little star: (300, 270, 277, 251)
        /// </summary>
        /// <param name="centerX">300</param>
        /// <param name="centerY">270</param>
        /// <param name="topX">277param>
        /// <param name="topY">251</param>
        public void PrintLittleStarBtm(int centerX, int centerY, int topX, int topY)
        {
            Console.WriteLine("4");
            // 1
            var point_1 = new StarPoint { X = topX, Y = topY };
            Console.WriteLine($"{point_1.X},{point_1.Y}");
            // 2
            var point_2 = new StarPoint();
            point_2.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos(Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)) - (double)36 / 360 * 2 * Math.PI);
            point_2.Y = centerY - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin(Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)) - (double)36 / 360 * 2 * Math.PI);
            Console.WriteLine($"{point_2.X},{point_2.Y}");
            // 3
            var point_3 = new StarPoint();
            point_3.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI - (Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)) - (double)36 / 360 * 2 * Math.PI));
            point_3.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI - (Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)) - (double)36 / 360 * 2 * Math.PI));
            Console.WriteLine($"{point_3.X},{point_3.Y}");
            // 4
            var point_4 = new StarPoint();
            point_4.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 3 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_4.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 3 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_4.X},{point_4.Y}");
            // 5
            var point_5 = new StarPoint();
            point_5.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 4 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_5.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 4 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_5.X},{point_5.Y}");
            // 6
            var point_6 = new StarPoint();
            point_6.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 5 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_6.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 5 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_6.X},{point_6.Y}");
            // 7
            var point_7 = new StarPoint();
            point_7.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 6 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_7.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 6 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_7.X},{point_7.Y}");
            // 8
            var point_8 = new StarPoint();
            point_8.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 7 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_8.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 7 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_8.X},{point_8.Y}");
            // 9
            var point_9 = new StarPoint();
            point_9.X = centerX - (double)30 * Math.Cos((double)36 / 360 * 2 * Math.PI * 8 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_9.Y = centerY + (double)30 * Math.Sin((double)36 / 360 * 2 * Math.PI * 8 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_9.X},{point_9.Y}");
            // 10
            var point_10 = new StarPoint();
            point_10.X = centerX - (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Cos((double)36 / 360 * 2 * Math.PI * 9 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            point_10.Y = centerY + (double)10 / Math.Cos((double)36 / 360 * 2 * Math.PI) * Math.Sin((double)36 / 360 * 2 * Math.PI * 9 - Math.Atan((double)Math.Abs(point_1.Y - centerY) / (double)Math.Abs(point_1.X - centerX)));
            Console.WriteLine($"{point_10.X},{point_10.Y}");

        }
    }
}
