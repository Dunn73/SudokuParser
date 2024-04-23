SudokuGivenCalc sudokuGivenCalc = new();

Dictionary<string, (string, int)> sudokuDictionary = sudokuGivenCalc.SudokuParser("ValidSudokus.txt");

var sortedDictionary = sudokuDictionary.OrderBy(x => x.Value.Item2).ToDictionary(x => x.Key, x => x.Value);

foreach (var key in sortedDictionary){
    Console.WriteLine($"{key.Key}, {key.Value}");

}

// Returns a random puzzle with less than 30 given numbers
List<string> keys = sortedDictionary.Keys.Where(key => sortedDictionary[key].Item2 < 30).ToList();
Random random = new Random();
int randomIndex = random.Next(0, keys.Count);
string randomKey = keys[randomIndex];
Console.WriteLine($"Random key: {randomKey}, {sortedDictionary[randomKey]}");

Console.ReadKey();
class SudokuGivenCalc{
    public Dictionary<string, (string, int)> SudokuParser(string filename){
        string[] list = File.ReadAllLines(filename);
        Dictionary<string, (string, int)> output = new();
        bool puzzle = true;
        string combinedPuzzle = "";
        string combinedSolution = "";
        int count = 0;
        foreach (var element in list){
            foreach (var character in element){
                if (character == ','){
                    puzzle = false;
                }
                else if (puzzle){
                    combinedPuzzle += character;
                    if (character != '.'){
                        count ++;
                    }
                }
                else {
                    combinedSolution += character;
                }

            }
            puzzle = true;
            output.Add(combinedPuzzle, (combinedSolution, count));
            combinedPuzzle = "";
            combinedSolution = "";
            count = 0;
        }
        return output;
    }
}