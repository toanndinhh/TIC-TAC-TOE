using System;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace TICTACTOEnewversion
{
    internal class Program
    {
        class Board : Program
        {
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
            public void Winner(Game game, char player)
            {
                if (((cells[0, 0] == game.player[0]) && (cells[0, 1] == game.player[0]) && (cells[0, 2] == game.player[0]))
                    || ((cells[1, 0] == game.player[0]) && (cells[1, 1] == game.player[0]) && (cells[1, 2] == game.player[0]))
                    || ((cells[2, 0] == game.player[0]) && (cells[2, 1] == game.player[0]) && (cells[2, 2] == game.player[0]))
                    || ((cells[0, 0] == game.player[0]) && (cells[1, 0] == game.player[0]) && (cells[2, 0] == game.player[0]))
                    || ((cells[0, 1] == game.player[0]) && (cells[1, 1] == game.player[0]) && (cells[1, 2] == game.player[0]))
                    || ((cells[0, 2] == game.player[0]) && (cells[1, 2] == game.player[0]) && (cells[2, 2] == game.player[0]))
                    || ((cells[0, 2] == game.player[0]) && (cells[1, 1] == game.player[0]) && (cells[2, 0] == game.player[0]))
                    || ((cells[0, 0] == game.player[0]) && (cells[1, 1] == game.player[0]) && (cells[2, 2] == game.player[0])))
                {
                    Console.WriteLine("!!!!!!!!!! Congratulation X is the WINNER !!!!!!!!!");
                    Console.WriteLine("Let Play Again !!! ");
                    Console.ReadKey();
                    ResetBoard();

                }
                if (((cells[0, 0] == game.player[1]) && (cells[0, 1] == game.player[1]) && (cells[0, 2] == game.player[1]))
                    || ((cells[1, 0] == game.player[1]) && (cells[1, 1] == game.player[1]) && (cells[1, 2] == game.player[1]))
                    || ((cells[2, 0] == game.player[1]) && (cells[2, 1] == game.player[1]) && (cells[2, 2] == game.player[1]))
                    || ((cells[0, 0] == game.player[1]) && (cells[1, 0] == game.player[1]) && (cells[2, 0] == game.player[1]))
                    || ((cells[0, 1] == game.player[1]) && (cells[1, 1] == game.player[1]) && (cells[1, 2] == game.player[1]))
                    || ((cells[0, 2] == game.player[1]) && (cells[1, 2] == game.player[1]) && (cells[2, 2] == game.player[1]))
                    || ((cells[0, 2] == game.player[1]) && (cells[1, 1] == game.player[1]) && (cells[2, 0] == game.player[1]))
                    || ((cells[0, 0] == game.player[1]) && (cells[1, 1] == game.player[1]) && (cells[2, 2] == game.player[1])))
                {
                    Console.WriteLine("!!!!!!!!!! Congratulation O is the WINNER !!!!!!!!!");
                    Console.WriteLine("Let Play Again !!! ");
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
            public char[] player = { 'X', 'O' };
            public int CurrentPlayer = 0;
            public void PlayerMove(Board board, int inputX)
            {
                bool validX = false;
                Console.WriteLine(" Player X is your choice : \n ", CurrentPlayer);
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
                        board.cells[0, 0] = player[CurrentPlayer]; break;
                    case 1:
                        board.cells[0, 1] = player[CurrentPlayer]; break;
                    case 2:
                        board.cells[0, 2] = player[CurrentPlayer]; break;
                    case 3:
                        board.cells[1, 0] = player[CurrentPlayer]; break;
                    case 4:
                        board.cells[1, 1] = player[CurrentPlayer]; break;
                    case 5:
                        board.cells[1, 2] = player[CurrentPlayer]; break;
                    case 6:
                        board.cells[2, 0] = player[CurrentPlayer]; break;
                    case 7:
                        board.cells[2, 1] = player[CurrentPlayer]; break;
                    case 8:
                        board.cells[2, 2] = player[CurrentPlayer]; break;
                }
                if (((board.cells[0, 0] == player[0]) && (board.cells[0, 0] == player[1])) 
                    || ((board.cells[0, 1] == player[0]) && (board.cells[0, 1] == player[1]))
                    || ((board.cells[0, 2] == player[0]) && (board.cells[0, 2] == player[1]))
                    || ((board.cells[1, 0] == player[0]) && (board.cells[1, 0] == player[1]))
                    || ((board.cells[1, 1] == player[0]) && (board.cells[1, 1] == player[1]))
                    || ((board.cells[1, 2] == player[0]) && (board.cells[1, 2] == player[1]))
                    || ((board.cells[2, 0] == player[0]) && (board.cells[2, 0] == player[1]))
                    || ((board.cells[2, 1] == player[0]) && (board.cells[2, 1] == player[1]))
                    || ((board.cells[2, 2] == player[0]) && (board.cells[2, 2] == player[1])))

                {
                    Console.WriteLine("Press The Number Again : ");
                }
            }
        }

        class AIcomputer : Program
        {

            public static int[] score = { };
            public int Currentplayer = 1;
            public int[] Minimax(Board board, Game game, int depth, char player)
            {
                int[] move = new int[3] ;
                if (depth == 0)
                {
                    move[0] = Score(board, game);
                    return move;
                }
                if (player == 'X')
                {
                    move[0] = int.MaxValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board.cells[i, j] == ' ')
                            {
                                board.cells[i, j] = 'X';
                                int[] temp = Minimax(board, game, depth - 1, 'O');
                                if (temp[0] > move[0])
                                {
                                    move[0] = temp[0];
                                    move[1] = i;
                                    move[2] = j;
                                }
                                board.cells[i, j] = ' ';
                            }
                        }
                    }
                return move;
                }
                else 
                {
                    move[0] = int.MinValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board.cells[i, j] == ' ')
                            {
                                board.cells[i, j] = 'O';
                                int[] temp = Minimax(board, game, depth - 1 , 'X');
                                if (temp[0] > move[0])
                                {
                                    move[0] = temp[0];
                                    move[1] = i;
                                    move[2] = j;
                                }
                                board.cells[i, j] = ' ';
                            }
                        }
                    }
                return move;
                }
            }

            public void AIMove(Game game, Board board)
            {
                int[] move = new int[2];
                move = Minimax( board,game,6, game.player[Currentplayer % 2]).Skip(1).Take(2).ToArray();
                board.cells[move[0], move[1]] = game.player[Currentplayer % 2];
            }

            public bool ISwin(Board board,Game game, char player)
            {
                if (((board.cells[0, 0] == game.player[0]) && (board.cells[0, 1] == game.player[0]) && (board.cells[0, 2] == game.player[0]))
                    || ((board.cells[1, 0] == game.player[0]) && (board.cells[1, 1] == game.player[0]) && (board.cells[1, 2] == game.player[0]))
                    || ((board.cells[2, 0] == game.player[0]) && (board.cells[2, 1] == game.player[0]) && (board.cells[2, 2] == game.player[0]))
                    || ((board.cells[0, 0] == game.player[0]) && (board.cells[1, 0] == game.player[0]) && (board.cells[2, 0] == game.player[0]))
                    || ((board.cells[0, 1] == game.player[0]) && (board.cells[1, 1] == game.player[0]) && (board.cells[1, 2] == game.player[0]))
                    || ((board.cells[0, 2] == game.player[0]) && (board.cells[1, 2] == game.player[0]) && (board.cells[2, 2] == game.player[0]))
                    || ((board.cells[0, 2] == game.player[0]) && (board.cells[1, 1] == game.player[0]) && (board.cells[2, 0] == game.player[0]))
                    || ((board.cells[0, 0] == game.player[0]) && (board.cells[1, 1] == game.player[0]) && (board.cells[2, 2] == game.player[0])))
                {
                    return true;
                }
                if (((board.cells[0, 0] == game.player[1]) && (board.cells[0, 1] == game.player[1]) && (board.cells[0, 2] == game.player[1]))
                    || ((board.cells[1, 0] == game.player[1]) && (board.cells[1, 1] == game.player[1]) && (board.cells[1, 2] == game.player[1]))
                    || ((board.cells[2, 0] == game.player[1]) && (board.cells[2, 1] == game.player[1]) && (board.cells[2, 2] == game.player[1]))
                    || ((board.cells[0, 0] == game.player[1]) && (board.cells[1, 0] == game.player[1]) && (board.cells[2, 0] == game.player[1]))
                    || ((board.cells[0, 1] == game.player[1]) && (board.cells[1, 1] == game.player[1]) && (board.cells[1, 2] == game.player[1]))
                    || ((board.cells[0, 2] == game.player[1]) && (board.cells[1, 2] == game.player[1]) && (board.cells[2, 2] == game.player[1]))
                    || ((board.cells[0, 2] == game.player[1]) && (board.cells[1, 1] == game.player[1]) && (board.cells[2, 0] == game.player[1]))
                    || ((board.cells[0, 0] == game.player[1]) && (board.cells[1, 1] == game.player[1]) && (board.cells[2, 2] == game.player[1])))
                {
                    return true;
                }


                    return false;
            }

            public int Score(Board board, Game game)
            {
                if (ISwin(board, game , 'X')) { return 1; }
                if (ISwin(board, game , 'O')) { return -1; }
                else { return 0; }
            }

        }
        static void Main(string[] args)
        {   
            int inputX = 0;
            int depth =0;
            char player='O' ;
            int CurrentPlayer = 0;
            Game game = new Game();
            Board board = new Board();
            AIcomputer ai = new AIcomputer();
            while (true)
            {
                board.DrawBoard();
                game.PlayerMove(board, inputX);
                CurrentPlayer = (CurrentPlayer + 1) % 2;
                ai.AIMove(game, board);
                CurrentPlayer = (CurrentPlayer + 1) % 2;
                ai.Minimax(board, game, depth, player);
                ai.Score(board,game);
                ai.ISwin(board,game, player);
                board.Winner(game,player);
            }
        }
    }
}





