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
        public UIElement Mover(UIElement piece, string name, List<int> location)
        {
            UIElement Piece = piece;
            //Piece.RenderTransformOrigin = new TranslateTransform(0, -100);
            return Piece;
        }
    }
}
