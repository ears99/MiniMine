using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMine {
    class Program {
        static int[,] grid = new int[5, 5];
        static int bombAmount = 0;
        static int bombTotal = 5;
        static Random randomSpace = new Random();
        static int rcol = randomSpace.Next(1, 5);
        static int rrow = randomSpace.Next(1, 5);
        static int score = 0;

        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Gengrid();
            Console.ReadLine();
        }

        static void Gengrid() {
            for(int i = 0; i < 5; i++) {
                for(int j = 0; j < 5; j++) {
                    //place a bomb (1) at a random location in the grid.
                    grid[rcol, rrow] = 1;

                    //this is for testing purposes only: 
                    while(grid[rcol, rrow] == 1 && bombTotal > 0) {
                        bombAmount++;
                        bombTotal--;
                    }
                }
            }

            printGrid();
        }

        static void printGrid() {
            Console.WriteLine("Bombs: {0}", bombAmount);
            Console.WriteLine("Score: {0}", score);
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
            getUserInput();
        }

     static void getUserInput() {

            //TEST
            int bombX = rrow; int bombY = rcol;
            int bomb = grid[bombX, bombY];

            Console.Write("Please enter the X coordinate (column): ");
            int userCol = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the Y coordinate (row): ");
            int userRow = Convert.ToInt32(Console.ReadLine());

                if(userCol == bombX && userRow == bombY) {
                    Console.WriteLine("You exploded! Your score is: {0}", score);
                } else {
                score += 500;
                Console.Clear();
                printGrid();
                     }
                }
            }
        }
