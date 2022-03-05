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
        public List<Image> pieces = new List<Image>();
        public string[,] board = new string[8, 8];
        public Rectangle clickedBoard;
        public Brush clickedBrush;
        public Point pt;

        public GameWindow()
        {
            InitializeComponent();
        }

        private readonly ImageSource[] pawnImages = new ImageSource[]
        {
            // Black pawns
            new BitmapImage(new Uri(@"F:\Visual Studio Projektit\ChessProject\ChessProject\Assets\test.png", UriKind.RelativeOrAbsolute)),
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
            board = boardmanager.Creator("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            //For vizualisation without images through console output
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
            PieceCreator creator = new PieceCreator();
            pieces = creator.PieceCreation(board);

            foreach (Image piece in pieces)
            {
                Console.WriteLine(piece.Name);
                pieceCanvas.Children.Add(piece);
            }

            /*
            Image pawn = new Image();
            pawn.Width = 1000;
            pawn.Height = 100;
            pawn.Name = "test";
            pawn.Margin = new Thickness(5);
            pawn.Source = GetImageFromSource();
            Console.WriteLine(pawn.Source);
            Canvas.SetTop(pawn, 100);
            Board.Children.Add(pawn);
            Console.WriteLine("hei");*/

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
                    Canvas.SetLeft(rec, j * 100);
                    Canvas.SetTop(rec, i * 100);
                    Board.Children.Add(rec);
                    BoardManager asd = new BoardManager();
                }
            }
        }

        private void pieceCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //not used atm
            var elementname = (e.OriginalSource as FrameworkElement).Name;
            var element = pieceCanvas.InputHitTest(e.GetPosition(this)) as UIElement;
            Console.WriteLine(elementname);

            if (element == null)
            {
                return;
            }
            pieceCanvas.Children.Remove(element);
            Point p = Mouse.GetPosition(this);
            Console.WriteLine(elementname);
            //element.PreviewMouseDown += Element_PreviewMouseDown;
        }

        UIElement dragObject = null;
        Point offset;

        private void Element_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //not used atm
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this.pieceCanvas);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            this.pieceCanvas.CaptureMouse();
        }
        private void pieceCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //not used atm
            if (this.dragObject == null)
            {
                return;
            }
            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
            Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
        }

        private void pieceCanvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //not used atm
            this.dragObject = null;
            this.pieceCanvas.ReleaseMouseCapture();
        }

        private void Board_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pt = e.GetPosition((UIElement)sender);
            Console.WriteLine(pt);
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }
        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(Image))
            {
                Console.WriteLine("HEI");
                var index = pieceCanvas.Children.IndexOf((Image)result.VisualHit);
                Console.WriteLine(index);
                UIElement piece = pieceCanvas.Children[index];
                string name = (piece as FrameworkElement).Name;
                //piece.RenderTransform = new TranslateTransform(0, -100);
                Console.WriteLine("Piece " + name + " selected!");
                BoardManager boardmanager = new BoardManager();
                List<int> a = boardmanager.Location(pt);

                BoardValueToMatrix boardValueMatrix = new BoardValueToMatrix();

                (Board.Children[boardValueMatrix.BoardValue(4,5)] as Rectangle).Fill = Brushes.Red;
                (Board.Children[boardValueMatrix.BoardValue(4, 4)] as Rectangle).Fill = Brushes.Red;

                LegalMoves legalMoves = new LegalMoves();
                legalMoves.Highlighter(a, board);

                PieceMover pieceMover = new PieceMover();
                pieceMover.Mover(piece, name, a);

                foreach (var i in a)
                {
                    Console.WriteLine(i);
                }
            }

            if (result.VisualHit.GetType() == typeof(Rectangle))
            {
                if(clickedBoard != null)
                {
                    clickedBoard.Fill = clickedBrush;
                    clickedBrush = null;
                    clickedBrush = null;
                }
                clickedBrush = (((Rectangle)result.VisualHit).Fill);
                ((Rectangle)result.VisualHit).Fill = Brushes.Yellow;
                clickedBoard = ((Rectangle)result.VisualHit);
            }
            return HitTestResultBehavior.Continue;
        }

    }
}
