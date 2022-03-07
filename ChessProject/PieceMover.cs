using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Threading.Tasks;

namespace ChessProject
{
    internal class PieceMover
    {
        public UIElement Mover(UIElement piece, string name, List<int> toLocation, List<int> fromLocation, GeneralTransform test)
        {
            int yDifference = fromLocation[1] - toLocation[1];
            int xDifference = fromLocation[0] - toLocation[0];

            piece.RenderTransform = new TranslateTransform(-xDifference * 100, -yDifference * 100);

            return piece;
        }
    }
}
