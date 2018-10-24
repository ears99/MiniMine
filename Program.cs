using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMine {
    class Program {
        //2D 5x5 array
        static int[,] grid = new int[5, 5];
        static int bombAmount = 0;
        static int bombTotal = 5;
        static Random randomSpace = new Random();
        //random bomb y coordinate
        static int rcol = randomSpace.Next(1, 5);
        //random bomb x coordinate
        static int rrow = randomSpace.Next(1, 5);
        static int score = 0;

        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            menu();
            Console.ReadLine();
        }

        static void menu() {
            char choice;
            Console.WriteLine("================");
            Console.WriteLine(" ** MINI MINE **");
            Console.WriteLine("================");
            Console.WriteLine();
            Console.WriteLine("P: PLAY");
            Console.WriteLine("Q: QUIT");
            Console.Write("> ");
           choice = Convert.ToChar(Console.ReadLine());
            switch(choice) {
                case 'P':
                case 'p':
                    Console.Clear();
                    Gengrid();
                    break;
                case 'Q':
                case 'q':
                    break;
                default:
                    menu();
                    break;
            }
        }



        static void Gengrid() {
            for(int i = 0; i < 5; i++) {
                for(int j = 0; j < 5; j++) {
                    //place a bomb (1) at a random location in the grid.
                    grid[rcol, rrow] = 1;
                    
                    //while the grid's random position has a value of one, and the bombTotal is greater than zero...
                    while(grid[rcol, rrow] == 1 && bombTotal > 0) {
                        //add one to the bomb amount...
                        bombAmount++;
                        //and subtract one from the bomb total.
                        bombTotal--;
                    }
                }
            }
            //Print the grid
            printGrid();
        }

        static void printGrid() {
            Console.WriteLine("Score: {0}", score); //display score
            //actually display the grid: 
            Console.WriteLine("  =================================");
            Console.WriteLine("  | 1  |   2  |   3  |   4  |   5 |");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("1 |    |      |      |      |     |");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("2 |    |      |      |      |     |");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("3 |    |      |      |      |     |");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("4 |    |      |      |      |     |");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("5 |    |      |      |      |     |");
            Console.WriteLine("  |----|------|------|------|-----|");
            Console.WriteLine("  =================================");
            getUserInput(); // allow user to input coordinates
        }

     static void getUserInput() {

            //TEST
            int bombX = rrow; int bombY = rcol; //bombX and bombY are the coordinates
            int bomb = grid[bombX, bombY]; //bomb placement

            Console.Write("Please enter the X coordinate (column): ");
            int userCol = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the Y coordinate (row): ");
            int userRow = Convert.ToInt32(Console.ReadLine());

                if(userCol == bombX && userRow == bombY) {

                //if the player selects a bomb coordinate, the player loses, and their current score is printed.
                char replay;
                    Console.WriteLine("You exploded! Your score is: {0}", score);
                    Console.Write("Play again? (Y/n): ");
                    replay = Convert.ToChar(Console.ReadLine());
                     if(replay == 'Y') {
                        score = 0;
                        Console.Clear();
                        Gengrid();
                    } else { return; }
            } else {
                //else if the player survives, add 500 to the score.
                score += 500;
                Console.Clear();
                printGrid();
                   }
                }
            }
        }
