using System;

namespace SimpleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
             // 1. generate star coordination
            var starCoord = new RedFlag.CalStarCoord();
            //first little
            starCoord.PrintLittleStarTop(300, 60, 274, 75);
            //second little
            starCoord.PrintLittleStarTop(360, 120, 330, 124);
            //third little
            starCoord.PrintLittleStarMid(360, 210, 331, 202);
            //forth little
            starCoord.PrintLittleStarBtm(300, 270, 277, 251);
            // main star
            starCoord.PrintLittleStarMid(0, 0, -29, -2);

            // 2. generate red flag svg
            var redflag = new RedFlag.ProcessStarCoord();
            redflag.GenSVG();

            Console.ReadKey();
        }
    }
}
