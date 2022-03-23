using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public class Board
    {
        public string[,] board = new string[8, 8];
        public Board(int size)
        {
            board = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)

                {
                    board[i, j] = " ";
                }
            }
            PrintBoard();

        }
        public void AddPeace(int Player, int x, int y)
        {
            if (Player == 0)
            {
                board[x, y] = "W";
            }
            else
            {
                board[x, y] = "B";
            }
        }
        public void PrintBoard()
        {
            int size = board.GetLength(0);

            Console.WriteLine("-------------------------------------------------------------------");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("|");
                    Console.Write(board[i, j]);
                    Console.Write("|");
                    Console.Write("  ");
                }
                Console.WriteLine("\n-------------------------------------------------------------------");
            }
        }
    }

    class Program
    {

        public static void Main(string[] args)
        {
            int size;
            bool Terminate = false;
            int Player = 0;
            int x = 0, y = 0;
            string currentPlayer;
            int MatrixX = x, MatrixY = y;
            int MatchPiece = 0;
            int Piece = 0;
            int turn = 0;
            Console.WriteLine("Enter size of the Board:");
            size = Convert.ToInt32(Console.ReadLine());
            Board cb = new Board(size);
            while (Terminate == false)
            {
               if (Player == 0)
                {
                    Player = 1;
                    bool position = true;
                    while (position == true)
                    {
                        Console.WriteLine("Player 1st Enter a Position:");
                        Console.WriteLine("Enter a Position of x:");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter a position of y:");
                        y = Convert.ToInt32(Console.ReadLine());

                        if (x >= size || y >= size)
                        {
                            Console.WriteLine("Out Of Bounds Input");
                            position = true;
                        }
                        else
                        {
                            turn++;
                            position = false;
                            if (cb.board[x, y] == "W" || cb.board[x, y] == "B")
                            {
                                Console.WriteLine("Player 2 Already Set Position");
                                position = true;
                            }
                        }
                    }

                    cb.AddPeace(Player, x, y);
                    cb.PrintBoard();

                }
                else
                {
                    bool position = true;
                    while (position == true)
                    {
                        Player = 0;
                        Console.WriteLine("Player 2nd Enter a Position:");
                        Console.WriteLine("Enter a Position of x:");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter a position of y:");
                        y = Convert.ToInt32(Console.ReadLine());
                        if (x >= size || y >= size || x <= -1 || y <= -1)
                        {
                            Console.WriteLine("Out Of Bounds Input");
                            position = true;
                        }
                        else
                        {
                            turn++;
                            position = false;
                        }
                        if (cb.board[x, y] == "W" || cb.board[x, y] == "B")
                        {
                            Console.WriteLine("Player 1 Already Set Position");
                            position = true;
                        }
                    }

                    cb.AddPeace(Player, x, y);
                    cb.PrintBoard();
                }
                if (Player == 0)
                {
                    currentPlayer = "W";
                }
                else
                {
                   currentPlayer = "B";
                }
               if (turn >= 9)
                {
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                    // Cheacking on BOTOOM side X
                    for (int i = 0; i <= 3; i++)
                    {
                     
                        if (MatrixX < size - 1 && MatrixX >= 0)
                        {
                            MatrixX = MatrixX + 1;
                        }


                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                          
                            MatchPiece++;
                            if (MatchPiece == 4)
                            {
                               
                                Terminate = true;
                               
                            }
                            Piece = MatchPiece;
                         
                        }
                    }
                    // Cheacking on UP side X
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                  
                    for (int i = 0; i <= 3; i++)
                    {
                        if (MatrixX < size-1  && MatrixX > 0)
                        {
                            MatrixX = MatrixX - 1;
                        }
                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                            MatchPiece++;
                            if (MatchPiece == 4)
                            {
                              
                                Terminate = true;
                            }

                            Piece = MatchPiece + Piece;
                           
                            if (Piece == 4)
                            {
                             
                                Terminate = true;
                            }
                        }
                    }
                    // Cheacking on Right side Y

                    Piece = 0;
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (MatrixY < size-1 && MatrixY >= 0)
                        {
                            MatrixY = MatrixY + 1;
                        }
                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                            MatchPiece++;
                            if (MatchPiece == 4)
                            {
                               
                               Terminate = true;
                            }
                            Piece = MatchPiece;
                        }
                    }
                    // Cheacking on Left side Y
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (MatrixY < size && MatrixY > 0)
                        {
                            MatrixY = MatrixY - 1;
                        }
                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                            MatchPiece++;
                            Piece = MatchPiece + Piece;
                            if (MatchPiece == 4)
                            {
                              
                                Terminate = true;
                            }
                            if (Piece == 4)
                            {
                               
                               Terminate = true;
                            }
                        }
                    }
                    // Cheacking Top On Right Side  -X,+Y:
                    Piece = 0;
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (MatrixX < size-1 && MatrixX > 0 && MatrixY < size-1 && MatrixY >= 0)
                        {
                            MatrixX = MatrixX - 1;
                            MatrixY = MatrixY + 1;                       
                        }
                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                            MatchPiece++;
                            Piece = MatchPiece;
                            if (MatchPiece == 4)
                            {
                            
                              Terminate = true;
                            }
                        }
                    }
                    // Cheacking Top On Left Side  -X,-Y:
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (MatrixX < size && MatrixX > 0 && MatrixY < size && MatrixY > 0)
                        {
                                MatrixX = MatrixX - 1;
                                MatrixY = MatrixY - 1;
                        }
                     
                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                            MatchPiece++;
                            Piece = MatchPiece + Piece;
                            if (MatchPiece == 4)
                            {
                               
                                Terminate = true;
                            }
                            if (Piece == 4)
                            { 
                                Terminate = true;
                            }
                        }
                    }
                    // Cheacking BOTOOM On Left Side  +X,-Y:
                    Piece = 0;
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                    for (int i = 0; i <= 3; i++)
                    {

                        if (MatrixX < size-1 && MatrixX >= 0 && MatrixY < size && MatrixY > 0)
                        {
                            MatrixX = MatrixX + 1;
                            MatrixY = MatrixY - 1;
                        }
                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                            MatchPiece++;
                            Piece = MatchPiece;
                            if (MatchPiece == 4)
                            {
                              
                                Terminate = true;   
                            }

                        }

                    }
                    // Cheacking Top On Left Side  +X,+Y:
                    MatrixX = x; MatrixY = y;
                    MatchPiece = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (MatrixX < size-1 && MatrixX > 0 && MatrixY < size-1 && MatrixY > 0 )
                        {
                            MatrixX = MatrixX + 1;
                            MatrixY = MatrixY + 1;
                        }
                       
                        if (cb.board[MatrixX, MatrixY] == currentPlayer)
                        {
                            MatchPiece++;
                            Piece = MatchPiece + Piece;
                            if (MatchPiece == 4)
                            {
                               
                                Terminate = true;
                            }
                            if (Piece == 4)
                            { 
                              
                                Terminate = true;
                            }
                        }
                    }
                }


            }

            if (Player == 0)
            {
                Console.WriteLine("Player 2nd Won");
            }
            else
            {
                Console.WriteLine("Player 1st Won");
            }
        }
    }
}


