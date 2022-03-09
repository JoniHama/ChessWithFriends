using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject
{
    internal class LegalMoves
    {
        public static string Name;
        public static bool enemyBlock = false;
        public List<int> legalLocations(List<int> location, string[,] board, string name)
        {
            Name = name;
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
            if (name.Contains("Knight"))
            {
                vs = nooneWay(board, location[0], location[1], "knight", 2, "down", name);
                return vs;
            }
            if (name.Contains("Bishop"))
            {
                vs = nooneWay(board, location[0], location[1], "sideways", 99, "down", name);
                return vs;
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
                case "sideways":
                    // 4 different directions
                    for (int i = 1; i < moveAmount; i++)
                    {
                        if (!isEnemy(board, xValue - i, yValue - i))
                        {
                            break;
                        }
                        else
                        {
                            if (enemyBlock == true)
                            {
                                locations.Add(xValue - i);
                                locations.Add(yValue - i);
                                enemyBlock = false;
                                break;
                            }
                            else
                            {
                                locations.Add(xValue - i);
                                locations.Add(yValue - i);
                            }
                        }
                    }
                    for (int i = 1; i < moveAmount; i++)
                    {
                        if (!isEnemy(board, xValue + i, yValue + i))
                        {
                            break;
                        }
                        else
                        {
                            if (enemyBlock == true)
                            {
                                locations.Add(xValue + i);
                                locations.Add(yValue + i);
                                enemyBlock = false;
                                break;
                            }
                            else
                            {
                                locations.Add(xValue + i);
                                locations.Add(yValue + i);
                            }
                        }
                        if (enemyBlock == true) { break; }

                    }
                    for (int i = 1; i < moveAmount; i++)
                    {
                        if (!isEnemy(board, xValue - i, yValue + i))
                        {
                            break;
                        }
                        else
                        {
                            if (enemyBlock == true)
                            {
                                locations.Add(xValue - i);
                                locations.Add(yValue + i);
                                enemyBlock = false;
                                break;
                            }
                            else
                            {
                                locations.Add(xValue - i);
                                locations.Add(yValue + i);
                            }
                        }
                    }
                    for (int i = 1; i < moveAmount; i++)
                    {
                        if (!isEnemy(board, xValue + i, yValue - i))
                        {
                            break;
                        }
                        else
                        {
                            if (enemyBlock == true)
                            {
                                locations.Add(xValue + i);
                                locations.Add(yValue - i);
                                enemyBlock = false;
                                break;
                            }
                            else
                            {
                                locations.Add(xValue + i);
                                locations.Add(yValue - i);
                            }
                        }
                    }

                    break;


                case "knight":
                    if (isEnemy(board, xValue - 1, yValue - 2))
                    {
                        locations.Add(xValue - 1);
                        locations.Add(yValue - 2);
                    }
                    if (isEnemy(board, xValue + 1, yValue - 2))
                    {
                        locations.Add(xValue + 1);
                        locations.Add(yValue - 2);
                    }
                    if (isEnemy(board, xValue + 2, yValue - 1))
                    {
                        locations.Add(xValue + 2);
                        locations.Add(yValue - 1);
                    }
                    if (isEnemy(board, xValue - 2, yValue - 1))
                    {
                        locations.Add(xValue - 2);
                        locations.Add(yValue - 1);
                    }
                    if (isEnemy(board, xValue - 1, yValue + 2))
                    {
                        locations.Add(xValue - 1);
                        locations.Add(yValue + 2);
                    }
                    if (isEnemy(board, xValue + 1, yValue + 2))
                    {
                        locations.Add(xValue + 1);
                        locations.Add(yValue + 2);
                    }
                    if (isEnemy(board, xValue + 2, yValue + 1))
                    {
                        locations.Add(xValue + 2);
                        locations.Add(yValue + 1);
                    }
                    if (isEnemy(board, xValue - 2, yValue + 1))
                    {
                        locations.Add(xValue - 2);
                        locations.Add(yValue + 1);
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

        public bool isEnemy(string[,] board, int xValue, int yValue)
        {
            char pieceChar;
            try
            {
                pieceChar = char.Parse(board[xValue, yValue]);
            }
            catch
            {
                return false;
            }

            if (pieceChar == '-')
            {
                return true;
            }
            if (Name[0] == 'W')
            {
                if (char.IsUpper(pieceChar))
                {
                    return false;
                }
                if (char.IsLower(pieceChar))
                {
                    enemyBlock = true;
                    return true;
                }
            }
            if (Name[0] == 'B')
            {
                if (char.IsUpper(pieceChar))
                {
                    enemyBlock = true;
                    return true;
                }
                if (char.IsLower(pieceChar))
                {
                    return false;
                }
            }
            return false;
        }
    }
}
