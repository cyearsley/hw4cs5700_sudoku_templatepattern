using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_algorithms
{
    class sudokuRecursiveAlgorithm : sudokuAlgorithm
    {
        List<List<List<int>>> listOfSolutions = new List<List<List<int>>> { };
        // ============================================================================== //
        protected override void executeSudokuAlgorithm(List<List<int>> sudoku)
        {
            solve(sudoku, 0);
            if (numberOfSolutions == 0)
            {
                Console.WriteLine("There were no solutions for the specified puzzle!");
            }
            else if (numberOfSolutions > 1)
            {
                Console.WriteLine("There was more than one solution - making this puzzle invalid!");
            }

            return;
        }

        private void solve(List<List<int>> puzzle, int x = 0, int y = 0)
        {
            int size = puzzle.Count;
            int currentValue = puzzle[1][0];
            int sectionsSize = (int) Math.Sqrt(size);
            if (x > size - 1 || y > size - 1)
            {
                return;
            }
            if (puzzle[x][y] != 0)
            {
                if (x >= size - 1 && y >= size - 1)
                {
                    if (!listOfSolutions.Contains(puzzle))
                    {
                        listOfSolutions.Add(puzzle);
                        numberOfSolutions++;
                        print(puzzle);
                    }
                    return;
                }
                if (x >= size - 1)
                {
                    solve(puzzle, 0, y + 1);
                }
            }
            else
            {
                for (int ii = 1; ii <= size; ii++)
                {
                    if (checkIfValid(puzzle, x, y, ii))
                    {
                        puzzle[x][y] = ii;
                        if (x >= size - 1 && y >= size - 1)
                        {
                            if (!listOfSolutions.Contains(puzzle))
                            {
                                listOfSolutions.Add(puzzle);
                                numberOfSolutions++;
                                print(puzzle);
                            }
                        }
                        else if (x >= size - 1)
                        {
                            solve(puzzle, 0, y + 1);
                        }
                        else
                        {
                            solve(puzzle, x + 1, y);
                        }
                    }
                }
            }
            if (x >= size - 1)
            {
                solve(puzzle, 0, y + 1);
            }
            else
            {
                solve(puzzle, x + 1, y);
            }
        }

        private bool checkIfValid(List<List<int>> puzzle, int x, int y, int num)
        {
            int size = puzzle.Count;
            //check rows and columns
            for (int ii = 0; ii < size; ii++)
            {
                if (ii != x)
                {
                    if (num == puzzle[ii][y] || num == puzzle[x][ii])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
