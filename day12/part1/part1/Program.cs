using part1;

var lines = await File.ReadAllLinesAsync("test.txt");
if (lines == null)
{
    Console.WriteLine("No lines of input found.");
    return;
}
var game = new Game(new List<string>(lines));
//var bestPath = game.Run();
//Console.WriteLine("Steps: " + bestPath);