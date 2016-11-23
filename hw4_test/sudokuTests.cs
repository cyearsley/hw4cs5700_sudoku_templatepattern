using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw4_sudoku;
using file_handler;
using sudoku_algorithms;
using System.Text.RegularExpressions;

namespace hw4_test
{
    [TestClass]
    public class sudokuTests
    {
        [TestMethod]
        public void testFileHandler_getFileName_valid()
        {
            fileHandler fh = new file_handler.fileHandler();
            Assert.IsTrue(fh.getFileName("4x4.txt"));

        }
        [TestMethod]
        public void testFileHandler_getFileName_invalid()
        {
            fileHandler fh = new file_handler.fileHandler();
            Assert.IsFalse(fh.getFileName("fileThatDoesNotExist.txt"));
        }

        [TestMethod]
        public void testFileHandler_readFileAsString_valid()
        {
            String expectedString = "4 2 - 1\n- - -2\n3 - 2 -\n- 4 - 3";
            fileHandler fh = new file_handler.fileHandler();
            fh.getFileName("4x4.txt");
            Assert.AreEqual(Regex.Replace(expectedString, @"[\u000A\u000B\u000C\u000D\u2028\u2029\u0085 ]+", String.Empty), Regex.Replace(fh.readFileAsString(), @"[\u000A\u000B\u000C\u000D\u2028\u2029\u0085 ]+", String.Empty));
        }
        [TestMethod]
        public void testFileHandler_readFileAsString_invalid()
        {
            String expectedString = "empty";
            fileHandler fh = new file_handler.fileHandler();
            Assert.AreEqual(expectedString, fh.readFileAsString());
        }

        [TestMethod]
        public void testFileHandler_readFileAsArray_valid()
        {
            fileHandler fh = new file_handler.fileHandler();
            fh.getFileName("4x4.txt");
            Assert.AreEqual("4 2 - 1", fh.readFileAsArray()[0]);
            Assert.AreEqual("- - - 2", fh.readFileAsArray()[1]);
            Assert.AreEqual("3 - 2 -", fh.readFileAsArray()[2]);
            Assert.AreEqual("- 4 - 3", fh.readFileAsArray()[3]);
        }
        [TestMethod]
        public void testFileHandler_readFileAsArray_invalid()
        {
            fileHandler fh = new file_handler.fileHandler();
            Assert.AreSame(new String[] { }.GetType(), fh.readFileAsArray().GetType());
        }

        [TestMethod]
        public void testRescursiveAlgorithm_solvePuzzle_valid()
        {
            sudokuAlgorithm algorithmMethod = new sudokuRecursiveAlgorithm();
            Assert.IsTrue(algorithmMethod.solvePuzzle("4x4.txt"));
        }
        [TestMethod]
        public void testRescursiveAlgorithm_solvePuzzle_invalid()
        {
            sudokuAlgorithm algorithmMethod = new sudokuRecursiveAlgorithm();
            Assert.IsFalse(algorithmMethod.solvePuzzle("puzzleWithBadFormat.txt"));
        }

        [TestMethod]
        public void testNaiveDLAlgorithm_solvePuzzle_valid()
        {
            sudokuAlgorithm algorithmMethod = new sudokuNaiveDancingLinksAlgorithm();
            Assert.IsTrue(algorithmMethod.solvePuzzle("4x4.txt"));
        }
        [TestMethod]
        public void testNaiveDLAlgorithm_solvePuzzle_invalid()
        {
            sudokuAlgorithm algorithmMethod = new sudokuNaiveDancingLinksAlgorithm();
            Assert.IsFalse(algorithmMethod.solvePuzzle("puzzleWithBadFormat.txt"));
        }

        [TestMethod]
        public void testDLAlgorithm_solvePuzzle_valid()
        {
            sudokuAlgorithm algorithmMethod = new sudokuDancingLinksAlgorithm();
            Assert.IsTrue(algorithmMethod.solvePuzzle("4x4.txt"));
        }
        [TestMethod]
        public void testDLAlgorithm_solvePuzzle_invalid()
        {
            sudokuAlgorithm algorithmMethod = new sudokuDancingLinksAlgorithm();
            Assert.IsFalse(algorithmMethod.solvePuzzle("puzzleWithBadFormat.txt"));
        }
    }
}
