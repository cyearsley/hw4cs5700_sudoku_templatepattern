Name: Caleb Yearsley

AD HOC methods:
	The main method of ADHOC testing that I utilized was Monkey Testing. When testing the system (especially when
	a bug is found where a unit test didn't catch an error), I would randomly test bits and pieces of the system
	until I found what was causing the bug.  I use a type of divide and conquer strategy, and test the pieces of
	the system that are directly affiliated with the bug. Also, using the unit tests are always an effective
	way of testing an application.  I often documented the bugs using Git when commiting.

Usage:
	1) Using puzzle files.
		NOTE: I have supplied invalid files, a 4x4.txt that has one solution, and a 16x16.txt that has no solutions for you convenience.
		i) In order to be able to use .txt files as puzzle files, they must be located in the root directory
		of the project (it should be in the same location as the solution.txt and hw4_sudoku.sln files).
		During step 3 (when you are selecting the algorithm), you will have to specify
		this puzzle file (eg. superAwesomeSudokuPuzzle.txt).

	2) Using the program.
		i) When you start up the program you will be prompted to use 1 of 3 algorithms.
			Simply enter a, b, or c to use the respective algorithm.
			Alternatively you can enter 'x' to close the program.

	3) What algorithms to use?
		This is heavily dependent on the size of the puzzle. Although the dancingLinks algorithms aren't terrible,
		when it comes to problem sizes larger than 9x9 it does take quite some time.  That being said, when the
		problem size is larger than 9x9 I would highly suggest using the recursiveAlgorithm... written by
		yours truly.

	4) Getting puzzle results
		Once you have completed steps 1, 2, and 3. One of several things will happen:
			i) You will get a message saying the format of the puzzle is wrong (eg. 4x3, 5x5)
			ii) You will get a message saying the syntax is wrong (ie. having anything other than integers, dashes, and spaces)
			iii) You will get a message saying there were no possible solutions.
			iv) You will get a message saying there was more than one solution.
			v) You will get a message saying there was one unique solution.

		In the case that you get message like (v), you can view your solution in 'solution.txt'
		'solution.txt' is located in the same directory as the hw4_sudoku.sln file.