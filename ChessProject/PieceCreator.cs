using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;

namespace ChessProject
{
    internal class PieceCreator
    {
        public List<Image> PieceCreation(string[,] board)
        {
            int height = 100;
            int width = 100;

            List<Image> pieces = new List<Image>();

            for (int k = 0; k < board.GetLength(0); k++)
            {
                for (int l = 0; l < board.GetLength(1); l++)
                {
                    Image pawn = new Image()
                    {
                        Height = height,
                        Width = width,
                        Name = PieceName(char.Parse(board[k, l])),
                    };

                    if (pawn.Name == "B_Error" || pawn.Name == "B_Nothing")
                    {
                        continue;
                    }

                    pawn.Source = GetImageFromSource(pawn.Name);
                    Canvas.SetLeft(pawn, k * 100);
                    Canvas.SetTop(pawn, l * 100);
                    pieces.Add(pawn);
                }
            }
            Console.WriteLine(pieces);

            return pieces;
        }

        public string PieceName(char c)
        {
            Console.WriteLine("C " + c);

            string name;

            if (Char.IsUpper(c))
            {
                name = "W_";
            }
            else
            {
                name = "B_";
            }

            Console.WriteLine("name " + name);

            switch(Char.ToLower(c))
            {
                case (char)114:
                    name += "Rook";
                    break;
                case (char)110:
                    name += "Knight";
                    break;
                case (char)98:
                    name += "Bishop";
                    break;
                case (char)113:
                    name += "Queen";
                    break;
                case (char)107:
                    name += "King";
                    break;
                case (char)112:
                    name += "Pawn";
                    break;
                case (char)45:
                    name += "Nothing";
                    break;
                default:
                    Console.WriteLine("WARNING! PIECE IS ERROR!");
                    name = "Error";
                    break;
            }
            return name;
        }

        public BitmapImage GetImageFromSource(string name)
        {
            string fileName = @"Assets\" + name + ".png";

            string combining = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));

            string combination = Path.Combine(combining, fileName);

            Console.WriteLine(combining);

            Console.WriteLine(combination);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri(combination, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            return bitmapImage;
        }

    }
}
