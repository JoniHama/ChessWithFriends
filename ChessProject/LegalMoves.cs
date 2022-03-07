using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject
{
    internal class LegalMoves
    {
        public List<int> legalLocations(List<int> location, string[,] board, string name)
        {
            List <int> vs = new List <int>();

            if (name.Contains("Pawn"))
            {
                if (name.Contains("W"))
                {
                    vs = nooneWay(board, location[0], location[1], "forward", 2, "up", name);
                    return vs;

                }
                else if (name.Contains("B"))
                {
                    vs = nooneWay(board, location[0], location[1], "forward", 2, "down", name);
                    return vs;
                }
            }


            return vs;
        }

        public List<int> nooneWay(string[,] board, int xValue, int yValue, string movementType, int moveAmount, string direction, string name)
        {
            List<int> locations = new List<int>();

            switch (movementType)
            {
                case "forward":
                    for (int i = 1; i < moveAmount+1; i++)
                    {
                        if (direction == "up")
                        {
                            if (char.IsLetter(char.Parse(board[xValue, yValue - i])))
                            {
                                //check if enemy piece, unless this moving piece is a pawn, then do not
                                break;
                            }
                            else
                            {
                                locations.Add(xValue);
                                locations.Add(yValue - i);
                            }
                        }
                        if (direction == "down")
                        {
                            if (char.IsLetter(char.Parse(board[xValue, yValue + i])))
                            {
                                //check if enemy piece, unless this moving piece is a pawn, then do not
                                break;
                            }
                            else
                            {
                                locations.Add(xValue);
                                locations.Add(yValue + i);
                            }
                        }
                    }
                    break;
            }
            if (name.Contains("Pawn"))
            {
                if (direction == "up")
                {
                    int checkX = xValue - 1;
                    if (checkX < 0) { return locations; }
                    int checkY = yValue - 1;
                    checkX = xValue + 1;
                    if (checkX > 7) { return locations; }
                    if (checkY < 0) { return locations; }
                    if (char.IsLower(char.Parse(board[xValue - 1, yValue - 1])))
                    {
                        locations.Add(xValue - 1);
                        locations.Add(yValue - 1);
                    }
                    if (char.IsLower(char.Parse(board[xValue + 1, yValue - 1])))
                    {
                        locations.Add(xValue + 1);
                        locations.Add(yValue - 1);
                    }
                }
                else
                {
                    int checkX = xValue + 1;
                    if (checkX > 7) { return locations; }
                    int checkY = yValue + 1;
                    if (checkY > 7) { return locations; }
                    checkX = xValue - 1;
                    if (checkX < 0) { return locations; }

                    if (char.IsUpper(char.Parse(board[xValue + 1, yValue + 1])))
                    {
                        locations.Add(xValue + 1);
                        locations.Add(yValue + 1);
                    }
                    if (char.IsLower(char.Parse(board[xValue - 1, yValue + 1])))
                    {
                        locations.Add(xValue - 1);
                        locations.Add(yValue + 1);
                    }
                }
            }

            return locations;

        }
    }
}
