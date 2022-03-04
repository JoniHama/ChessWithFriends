using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.IO;
using System.Xml;

namespace ChessProject
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private readonly ImageSource[] pawnImages = new ImageSource[]
        {
            // Black pawns
            new BitmapImage(new Uri(@"F:\Visual Studio Projektit\ChessProject\ChessProject\Assets\Chess_bdt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_kdt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_ndt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_pdt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_qdt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_rdt45.png", UriKind.Relative)),

            // White pawns
            new BitmapImage(new Uri("Assets/Chess_blt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_klt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_nlt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_plt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_qlt45.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Chess_rlt45.png", UriKind.Relative)),
         };

        private async void boardCanvas_Initialized(object sender, EventArgs e)
        {
            BoardCreation();
            BoardManager boardmanager = new BoardManager();
            var board = boardmanager.Creator("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            //For vizualisation without images through console output
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
            Image pawn = new Image();
            pawn.Width = 1000;
            pawn.Height = 100;
            pawn.Name = "test";
            pawn.Margin = new Thickness(5);
            pawn.Source = GetImageFromSource();
            Console.WriteLine(pawn.Source);
            Canvas.SetTop(pawn, 100);
            Board.Children.Add(pawn);
            Console.WriteLine("hei");

        }

        public BitmapImage GetImageFromSource()
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri(@"F:\Visual Studio Projektit\ChessProject\ChessProject\Assets\Chess_bdt45.png", UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public void BoardCreation()
        {
            int linerow = 8;
            for (int i = 0; i < linerow; i++)
            {
                for (int j = 0; j < linerow; j++)
                {
                    var rec = new System.Windows.Shapes.Rectangle();
                    rec.Width = 100;
                    rec.Height = 100;

                    if (j % 2 == 0)
                    {
                        if (i % 2 == 0)
                        {
                            rec.Fill = (Brush)(new BrushConverter().ConvertFrom("#eeeed2"));
                        }
                        else
                        {
                            rec.Fill = (Brush)(new BrushConverter().ConvertFrom("#769656"));
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            rec.Fill = (Brush)(new BrushConverter().ConvertFrom("#769656"));
                        }
                        else
                        {
                            rec.Fill = (Brush)(new BrushConverter().ConvertFrom("#eeeed2"));
                        }
                    }
                    Canvas.SetRight(rec, j * 100);
                    Canvas.SetBottom(rec, i * 100);
                    Board.Children.Add(rec);
                    BoardManager asd = new BoardManager();
                }
            }
        }
    }
}
