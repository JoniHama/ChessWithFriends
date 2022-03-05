using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject
{
    internal class BoardValueToMatrix
    {
        public int BoardValue(int xValue, int yValue)
        {
            if (xValue > 7) { xValue = 7; }
            if (yValue > 7) { yValue = 7; }
            if (xValue < 0) { xValue = 0; }
            if (yValue < 0) { yValue = 0; }

            int value = 0;

            switch (xValue)
            {
                case 0:
                    value += 8 + (yValue*8); break;
                case 1:
                    value += 7 + (yValue*8); break;
                case 2:
                    value += 6 + (yValue * 8); break;
                case 3:
                    value += 5 + (yValue * 8); break;
                case 4:
                    value += 4 + (yValue * 8); break;
                case 5:
                    value += 3 + (yValue * 8); break;
                case 6:
                    value += 2 + (yValue * 8); break;
                case 7:
                    value += 1 + (yValue * 8); break;

            }
            Console.WriteLine(value);
            return value;
        }
    }
}
