using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.Remoting.Channels;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Collections.Specialized;

namespace TICTACTOEnewversion
{
    internal class Program
    {
        class Board : Program
        {
            static char Player = 'X';
            static char Computer = 'O';
            public char[,] cells = new char[3, 3]
            {
                {' ' ,' ', ' '},
                {' ', ' ', ' '},
                {' ' ,' ', ' '},

            };

            public void DrawBoard()
            {
                Console.WriteLine("--------------");
                Console.WriteLine("| {0} | {1} | {2} |", cells[0, 0], cells[0, 1], cells[0, 2]);
                Console.WriteLine("--------------");
                Console.WriteLine("| {0} | {1} | {2} |", cells[1, 0], cells[1, 1], cells[1, 2]);
                Console.WriteLine("--------------");
                Console.WriteLine("| {0} | {1} | {2} |", cells[2, 0], cells[2, 1], cells[2, 2]);
                Console.WriteLine("--------------");
                Console.ReadLine();
            }
            public void Winner()
            {
                if (((cells[0, 0] == Player) && (cells[0, 1] == Player) && (cells[0, 2] == Player))
                    || ((cells[1, 0] == Player) && (cells[1, 1] == Player) && (cells[1, 2] == Player))
                    || ((cells[2, 0] == Player) && (cells[2, 1] == Player) && (cells[2, 2] == Player))
                    || ((cells[0, 0] == Player) && (cells[1, 0] == Player) && (cells[2, 0] == Player))
                    || ((cells[0, 1] == Player) && (cells[1, 1] == Player) && (cells[2, 1] == Player))
                    || ((cells[0, 2] == Player) && (cells[1, 2] == Player) && (cells[2, 2] == Player))
                    || ((cells[0, 2] == Player) && (cells[1, 1] == Player) && (cells[2, 0] == Player))
                    || ((cells[0, 0] == Player) && (cells[1, 1] == Player) && (cells[2, 2] == Player)))
                {
                    Console.WriteLine("!!!!!!!!!! Congratulation X is the WINNER !!!!!!!!!");
                    Console.WriteLine(" Let Play Again !!! ");
                    Console.ReadKey();
                    ResetBoard();

                }
                if (((cells[0, 0] == Computer) && (cells[0, 1] == Computer) && (cells[0, 2] == Computer))
                    || ((cells[1, 0] == Computer) && (cells[1, 1] == Computer) && (cells[1, 2] == Computer))
                    || ((cells[2, 0] == Computer) && (cells[2, 1] == Computer) && (cells[2, 2] == Computer))
                    || ((cells[0, 0] == Computer) && (cells[1, 0] == Computer) && (cells[2, 0] == Computer))
                    || ((cells[0, 1] == Computer) && (cells[1, 1] == Computer) && (cells[2, 1] == Computer))
                    || ((cells[0, 2] == Computer) && (cells[1, 2] == Computer) && (cells[2, 2] == Computer))
                    || ((cells[0, 2] == Computer) && (cells[1, 1] == Computer) && (cells[2, 0] == Computer))
                    || ((cells[0, 0] == Computer) && (cells[1, 1] == Computer) && (cells[2, 2] == Computer)))
                {
                    Console.WriteLine("!!!!!!!!!! Congratulation O is the WINNER !!!!!!!!!");
                    Console.WriteLine(" Let Play Again !!! ");
                    Console.ReadKey();
                    ResetBoard();
                }
            }
            public void ResetBoard()
            {
                char[,] aircells = new char[3, 3]
                {
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' }
                };
                cells = aircells;
                DrawBoard();
            }
        }

        class Game : Program
        {
            static char Player = 'X';
            static char Computer = 'O';
            public void PlayerMove(Board board,int inputX)
            {
                bool validX = false;
                Console.WriteLine(" Player X is your choice : \n ");
                while (!validX)
                {
                    validX = int.TryParse(Console.ReadLine(), out inputX);
                    if (!validX)
                    {
                        Console.WriteLine(" \n Give Another Choice ");
                    }
                }
                switch (inputX)
                {
                    case 0:
                        board.cells[0, 0] = Player; break;
                    case 1:
                        board.cells[0, 1] = Player; break;
                    case 2:
                        board.cells[0, 2] = Player; break;
                    case 3:
                        board.cells[1, 0] = Player; break;
                    case 4:
                        board.cells[1, 1] = Player; break;
                    case 5:
                        board.cells[1, 2] = Player; break;
                    case 6:
                        board.cells[2, 0] = Player; break;
                    case 7:
                        board.cells[2, 1] = Player; break;
                    case 8:
                        board.cells[2, 2] = Player; break;
                }
                if (((board.cells[0, 0] == Player) && (board.cells[0, 0] == Computer))
                    || ((board.cells[0, 1] == Player) && (board.cells[0, 1] == Computer))
                    || ((board.cells[0, 2] == Player) && (board.cells[0, 2] == Computer))
                    || ((board.cells[1, 0] == Player) && (board.cells[1, 0] == Computer))
                    || ((board.cells[1, 1] == Player) && (board.cells[1, 1] == Computer))
                    || ((board.cells[1, 2] == Player) && (board.cells[1, 2] == Computer))
                    || ((board.cells[2, 0] == Player) && (board.cells[2, 0] == Computer))
                    || ((board.cells[2, 1] == Player) && (board.cells[2, 1] == Computer))
                    || ((board.cells[2, 2] == Player) && (board.cells[2, 2] == Computer)))
                {
                    Console.WriteLine("Press The Number Again : ");
                }
            }
        }

        class AIcomputer : Program
        {
            public int row;
            public int col;

            static char Player = 'X';
            static char Computer = 'O';

            static bool TheMoveLeft(Board board)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board.cells[i, j] == ' ')
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            static int Count(Board b)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (b.cells[row, 0] == b.cells[row, 1] && b.cells[row, 1] == b.cells[row, 2])
                    {
                        if (b.cells[row, 0] == Player)
                        {
                            return +10;
                        }
                        else if (b.cells[row, 0] == Computer)
                        {
                            return -10;
                        }
                    }
                    if (b.cells[row, 0] == Player && b.cells[row, 1] ==Player && b.cells[row, 2]==Player)
                    {
                        return +20;
                    }
                    else(b.cells[row, 0] == Computer && b.cells[row, 1] == Computer && b.cells[row, 2] == Computer){
                        return -20;
                    }
                }
                for (int col =0; col < 3; col++)
                {
                    if (b.cells[0,col] == b.cells[1, col] && b.cells[1, col] == b.cells[2, col])
                    {
                        if (b.cells[0,col] == Player)
                        {
                            return +10;
                        }
                        else if (b.cells[0,col] == Computer)
                        {
                            return -10;
                        }
                    }
                }
                if (b.cells[0, 0] == b.cells[1, 1] && b.cells[1,1]== b.cells[2, 2])
                {
                    if (b.cells[0, 0] == Player)
                    {
                        return +10;
                    }
                    else if (b.cells[0, 0] == Computer)
                    {
                        return -10;
                    }
                }
                if (b.cells[0, 2] == b.cells[1, 1] && b.cells[1, 1] == b.cells[2, 0])
                {
                    if (b.cells[0, 2] == Player)
                    {
                        return +10;
                    }
                    else if (b.cells[0, 2] == Computer)
                    {
                        return -10;
                    }
                }
                return 0;
            }
            static int MiniMax(Board board, int depth, bool IsMax)
            {
                int score = Count(board);
                if (score == 10) return score;
                else if (score == -10) return score;
                else if (TheMoveLeft(board) == false) return 0;
                else if (IsMax)
                {
                    int best = int.MinValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board.cells[i, j] == ' ')
                            {
                                board.cells[i, j] = Player;
                                best = Math.Max(best, MiniMax(board, depth + 1, !IsMax));
                                board.cells[i, j] = ' ';
                            }
                        }
                    }
                    return best;
                }
                else
                {
                    int best = int.MaxValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board.cells[i, j] == ' ')
                            {
                                board.cells[i, j] = Computer;
                                best = Math.Min(best, MiniMax(board, depth + 1, !IsMax));
                                board.cells[i, j] = ' ';
                            }
                        }
                    }
                    return best;
                }
            }

            static AIcomputer FindBestMove(Board board, Game game)
            {

                int bestVal = int.MinValue;
                AIcomputer bestMove = new AIcomputer();
                bestMove.row = -1;
                bestMove.col = -1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board.cells[i, j] == ' ')
                        {
                            board.cells[i, j] = Player;
                            int moveVal = MiniMax(board, 0, false);
                            board.cells[i, j] = ' ';
                            if (moveVal > bestVal)
                            {
                                bestMove.row = i;
                                bestMove.col = j;
                                bestVal = moveVal;
                                Console.WriteLine("bP:"+bestVal);
                            }
                        }
                    }
                }
                return bestMove;
            }


            static void Main(string[] args)
            {
                int inputX = 0;
                Game game = new Game();
                Board board = new Board();
                AIcomputer ai = new AIcomputer();
                while (true)
                {
                    board.DrawBoard();
                    game.PlayerMove(board, inputX);
                    AIcomputer bestMove = FindBestMove(board, game);
                    board.cells[bestMove.row, bestMove.col] = Computer;
                    board.Winner();
                }
            }
        }
    }
}










