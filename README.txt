Name: Caleb Yearsley

Usage:
	1) Using puzzle files.
		i) In order to be able to use .txt files as puzzle files, they must be located in the root directory
		of the project (it should be in the same location as the solution.txt and hw4_sudoku.sln files).

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