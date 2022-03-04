﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject
{
    internal class BoardManager
    {
        public string[,] Creator(string FEN)
        {
            int row = 0;
            int idx = 0;
            string[,] board = new string[8, 8];
            bool hasbeenspace = false;
            foreach(char c in FEN)
            {
                Console.WriteLine("Row " + row);
                Console.WriteLine("Index " + idx);
                Console.WriteLine("FEN-value " + c);

                if (c == (char)114)
                {
                    Console.WriteLine("r");
                }

                if (c == (char)47)
                {
                    row++;
                    idx = 0;
                    continue;
                }
                else if (c == (char)32)
                {
                    hasbeenspace = true;
                    Console.WriteLine("Hasbeenspace!");
                }
                else if (hasbeenspace == false)
                {
                    if (char.IsLetter(c))
                    {
                        if (char.IsUpper(c))
                        {
                            switch (c)
                            {
                                case (char)82:
                                    board[idx, row] = "R";
                                    break;
                                case (char)78:
                                    board[idx, row] = "N";
                                    break;
                                case (char)66:
                                    board[idx, row] = "B";
                                    break;
                                case (char)81:
                                    board[idx, row] = "Q";
                                    break;
                                case (char)75:
                                    board[idx, row] = "K";
                                    break;
                                case (char)80:
                                    board[idx, row] = "P";
                                    break;
                            }
                        }
                        else
                        {
                            switch (c)
                            {
                                case (char)114:
                                    board[idx, row] = "r";
                                    break;
                                case (char)110:
                                    board[idx, row] = "n";
                                    break;
                                case (char)98:
                                    board[idx, row] = "b";
                                    break;
                                case (char)113:
                                    board[idx, row] = "q";
                                    break;
                                case (char)107:
                                    board[idx, row] = "k";
                                    break;
                                case (char)112:
                                    board[idx, row] = "p";
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (hasbeenspace == false)
                        {
                            for (int i = 0; i < ((int)c-1); i++)
                            {
                                try
                                {
                                    board[i, row] = "-";
                                }
                                catch { Console.WriteLine("Null value at" + idx + " " + i); break; }
                            }
                        }
                        else
                        {
                            //look for whose turn it is
                        }
                    }
                }
                else
                {
                    //castling availability
                }
                idx++;
            }

            return board;
        }


    }
}