# Sudoku Text File Parser
## Input
* Takes inputs per line of 81 consecutive characters with a comma separating another 81 consecutive characters.
* The 81 characters to the left of the comma is the puzzle and can include numbers 1-9 with '.' denoting an empty cell.
* The 81 characters to the right of the comma is the associated solution.

## Output
* Returns a dictionary<string, (string, int)> where the key is the puzzle and the value is (solution, given numbers).
* Also currently returns a random sudoku from a list of ones with less than 30 given numbers.
