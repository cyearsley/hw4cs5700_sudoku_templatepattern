using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sudoku_algorithms;

namespace hw4_sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            sudokuAlgorithm algorithmMethod;
            bool loopFlag = true;
            while(loopFlag)
            {
                Console.WriteLine("\n\nPlease enter one of the following options:");
                Console.WriteLine("==========================================");
                Console.WriteLine("a) Run naive Dancing Links algorithm");
                Console.WriteLine("b) Run imporoved Dancing Links algorithm");
                Console.WriteLine("c) Run Backtracking algorithm");
                Console.WriteLine("x) Exit");
                String userInput = Console.ReadLine();

                switch(userInput.ToLower())
                {
                    case "a":
                        algorithmMethod = new sudokuNaiveDancingLinksAlgorithm();
                        algorithmMethod.solvePuzzle();
                        break;
                    case "b":
                        algorithmMethod = new sudokuDancingLinksAlgorithm();
                        algorithmMethod.solvePuzzle();
                        break;
                    case "c":
                        algorithmMethod = new sudokuRecursiveAlgorithm();
                        algorithmMethod.solvePuzzle();
                        break;
                    case "x":
                        loopFlag = false;
                        break;
                    default:
                        Console.WriteLine("You selected an invalid option, please try again!\n\n");
                        break;
                }
            }

            //sudokuBacktrackingAlgorithm sba = new sudokuBacktrackingAlgorithm();
            //sba.solvePuzzle();

            //sudokuDancingLinksAlgorithm sdla = new sudokuDancingLinksAlgorithm();
            //sdla.solvePuzzle();
        }
    }
}
