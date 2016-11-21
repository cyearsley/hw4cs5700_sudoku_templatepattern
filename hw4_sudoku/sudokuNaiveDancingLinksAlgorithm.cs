using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_algorithms
{
    class sudokuNaiveDancingLinksAlgorithm : sudokuAlgorithm
    {
        protected override void executeSudokuAlgorithm(List<List<int>> sudoku)
        {
            solve(sudoku, 0);
        }

        // Start Reference: https://rafal.io/posts/solving-sudoku-with-dancing-links.html
        // ============================================================================== //
        private void solve(List<List<int>> sudoku, int idx)
        {
            int size = sudoku[0].Count;
            if (idx == size * size)
            {
                if (isSolution(sudoku))
                {
                    Console.WriteLine("Found a solution via very naive algorithm: ");
                    //print(sudoku);
                    print();
                    Console.WriteLine("\n");
                }
            }
            else
            {
                int row = idx / size;
                int col = idx % size;
                if (sudoku[row][col] != 0)
                { // the square is already filled in, don't do anything 
                    solve(sudoku, idx + 1);
                }
                else
                {
                    for (int i = 1; i <= size; i++)
                    {
                        sudoku[row][col] = i;
                        solve(sudoku, idx + 1); // continue with the next square
                        sudoku[row][col] = 0; // unmake move
                    }
                }
            }
        }
        
        // Returns true if and only if sudoku is a valid solved sudoku board
        private bool isSolution(List<List<int>> sudoku)
        {
            int N = rawPuzzle[0].Count;
            int side = (int)Math.Floor(Math.Sqrt(rawPuzzle[0].Count));
            bool[] mask = new bool[N + 1];

            // Check rows
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int num = sudoku[i][j];
                    if (mask[num]) return false;
                    mask[num] = true;
                }
                for (int ii = 0; ii < mask.Count(); ii++)
                {
                    mask[ii] = false;
                }
            }

            // Check columns
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int num = sudoku[j][i];
                    if (mask[num]) return false;
                    mask[num] = true;
                }
                for (int ii = 0; ii < mask.Count(); ii++)
                {
                    mask[ii] = false;
                }
            }

            // Check subsquares

            for (int i = 0; i < N; i += side)
            {
                for (int j = 0; j < N; j += side)
                {
                    for (int ii = 0; ii < mask.Count(); ii++)
                    {
                        mask[ii] = false;
                    }
                    for (int di = 0; di < side; di++)
                    {
                        for (int dj = 0; dj < side; dj++)
                        {
                            int num = sudoku[i + di][j + dj];
                            if (mask[num]) return false;
                        }
                    }
                }
            }

            return true; // Everything validated!
        }
        // ============================================================================== //
        // End Reference
    }
}
