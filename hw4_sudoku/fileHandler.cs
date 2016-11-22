using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_handler
{
    class fileHandler
    {
        private String puzzleFile;

        public String getPuzzleFile()
        {
            return this.puzzleFile;
        }

        public bool getFileName()
        {
            Console.WriteLine("Enter the file name that contains the sudoku puzzle.");
            Console.Write("Enter: ");
            String userInput = Console.ReadLine();

            try
            {
                string[] fileContents = System.IO.File.ReadAllLines(@"../../" + userInput);
            }
            catch (Exception exp)
            {
                return false;
            }

            this.puzzleFile = "../../" + userInput;
            return true;
        }

        public String readFileAsString()
        {
            return System.IO.File.ReadAllText(@puzzleFile);
        }

        public String[] readFileAsArray()
        {
            return System.IO.File.ReadAllLines(@puzzleFile);
        }
    }
}
