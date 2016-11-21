using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_algorithms
{
    public abstract class sudokuAlgorithm
    {
        int numberOfSolutions;
        private List<List<int>> solvedPuzzle;
        private List<List<int>> rawPuzzle;
        private String puzzleFile;
        protected abstract void executeSudokuAlgorithm(List<List<int>> puzzle);

        public sudokuAlgorithm()
        {
            this.numberOfSolutions = 0;
            this.solvedPuzzle = new List<List<int>>();
        }

        public void solvePuzzle()
        {
            if (getFileName())
            {
                if (checkFormat())
                {
                    read();
                    executeSudokuAlgorithm(rawPuzzle);
                    print();
                }
                else
                {
                    Console.WriteLine("The puzzle given by this file does NOT have an appropriate format!");
                }
            } else
            {
                Console.WriteLine("There was a problem identifying the file you specified!");
            }
        }

        private bool checkFormat()
        {
            // TODO: read the specified file to ensure that the puzzle structure is valid using puzzleFile.
            return true;
        }

        private void read()
        {
            // TODO: from the puzzleFile, read the contents and build the puzzle.
            this.rawPuzzle = new List<List<int>>();
        }

        private void print()
        {
            Console.WriteLine("print the output to a file");
            if (numberOfSolutions == 1)
            {
                Console.WriteLine("You have solved the puzzle!");
                Console.WriteLine("The solution has been saved to the file: solution.txt");
                // TODO: print the solution to a file.
            }
            else
            {
                // TODO: handle logic to determine why there was no solution.
            }
        }

        private bool getFileName()
        {
            this.puzzleFile = "testing.txt";
            return true;
        }
    }
}
