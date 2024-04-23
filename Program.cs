using System.Text.Json;

SudokuGivenCalc sudokuGivenCalc = new SudokuGivenCalc();

List<SudokuData> sudokuDataList = sudokuGivenCalc.SudokuParser("ValidSudokus.txt");

// Serialize the list to JSON
string jsonString = JsonSerializer.Serialize(sudokuDataList);

// Write the JSON string to a file
File.WriteAllText("ValidSudokus.json", jsonString);

class SudokuData{
    public int Id { get; set; }
    public string Puzzle { get; set; }
    public string Solution { get; set; }
    public int Count { get; set; }
}

class SudokuGivenCalc{
    public List<SudokuData> SudokuParser(string filename){
        string[] list = File.ReadAllLines(filename);
        List<SudokuData> output = new List<SudokuData>();

        int id = 0;
        foreach (var line in list){
            string[] parts = line.Split(',');

            string puzzle = parts[0];
            string solution = parts[1];

            int count = CountFilledCells(puzzle);

            output.Add(new SudokuData { Id = id, Puzzle = puzzle, Solution = solution, Count = count });

            id++;
        }
        return output;
    }

    private int CountFilledCells(string puzzle)
{
        int count = 0;
        foreach (char c in puzzle){
            if (c != '.'){
                count++;
            }
        }
        return count;
    }
}