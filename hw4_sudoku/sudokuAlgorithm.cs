using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sudoku_algorithms
{
    public abstract class sudokuAlgorithm
    {
        protected int numberOfSolutions;
        protected List<List<int>> solvedPuzzle;
        protected List<List<int>> rawPuzzle;
        protected String puzzleFile;
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
            string fileContentsString = System.IO.File.ReadAllText(@puzzleFile);
            Regex regexp = new Regex(@"[^1-9\-\s]*", RegexOptions.Singleline);
            MatchCollection matches = regexp.Matches(fileContentsString);
            List<String> errorList = new List<String>();
            for (int ii = 0; ii < matches.Count; ii++)
            {
                if (matches[ii].ToString() != "" && matches[ii].ToString() != null)
                {
                    errorList.Add("Invalid Syntax: " + matches[ii].ToString());
                }
            }

            int[] acceptedSizes = { 4, 9, 16, 25, 36 };
            string[] fileContentsArray = System.IO.File.ReadAllLines(@puzzleFile);
            if (!acceptedSizes.Contains(fileContentsArray.Length))
            {
                errorList.Add("Invalid Format - Wrong number of rows!\n "+
                    "Given: " + fileContentsArray.Length + "Expected: 4, 9, 16, 25, or 36.");
            }

            for (int ii = 0; ii < fileContentsArray.Length; ii++)
            {
                int columnCount = fileContentsArray[ii].Split(' ').Length;
                if (!acceptedSizes.Contains(columnCount))
                {
                    errorList.Add("Invalid Format - Wrong number of columns!\n " +
                        "Given: " + columnCount + ". Expected: 4, 9, 16, 25, or 36.");
                }
                if (columnCount != fileContentsArray.Length)
                {
                    errorList.Add("The number of columns do not match the number of rows!\n" +
                        "Given: " + columnCount + ". Expected: " + fileContentsArray.Length);
                }
            }

            if (errorList.Count > 0)
            {
                Console.WriteLine("\nThere was a problem reading your puzzle, here are the errors found:");
                for (int ii = 0; ii < errorList.Count; ii++)
                {
                    Console.WriteLine(ii + 1 + ") " + errorList[ii] + "\n");
                }
                return false;
            }

            Console.WriteLine("Solving the following puzzle: ");

            rawPuzzle = new List<List<int>>();
            List<List<String>> puzzleTableString = new List<List<String>>();
            for (int ii = 0; ii < fileContentsArray.Length; ii++)
            {
                puzzleTableString.Add(fileContentsArray[ii].Split(' ').ToList());
            }

            for (int ii = 0; ii < puzzleTableString.Count; ii++)
            {
                rawPuzzle.Add(new List<int>());
                for (int jj = 0; jj < puzzleTableString.Count; jj++)
                {
                    if (puzzleTableString[ii][jj] == "-")
                    {
                        rawPuzzle[ii].Add(0);
                    }
                    else
                    {
                        rawPuzzle[ii].Add(Int32.Parse(puzzleTableString[ii][jj]));
                    }
                }
            }
            Console.WriteLine("The count of List[0] is: " + puzzleTableString[0].Count);
            for (int ii = 0; ii < rawPuzzle[0].Count; ii++)
            {
                for (int jj = 0; jj < rawPuzzle[0].Count; jj++)
                {
                    Console.Write(rawPuzzle[ii][jj] + " ");
                }
                Console.WriteLine("\n");
            }
            return true;
        }

        private void read()
        {
            // TODO: from the puzzleFile, read the contents and build the puzzle.
            this.rawPuzzle = new List<List<int>>();
        }

        protected void print()
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
            Console.WriteLine("Enter the file name that contains the sudoku puzzle.");
            Console.Write("Enter: ");
            String userInput = Console.ReadLine();

            try
            {
                string[] fileContents = System.IO.File.ReadAllLines(@"../../" + userInput);
            }
            catch(Exception exp)
            {
                return false;
            }

            this.puzzleFile = "../../" + userInput;
            return true;
        }
    }
}
