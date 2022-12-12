using part1;

var lines = await File.ReadAllLinesAsync("input.txt");
if(lines == null)
{
    Console.WriteLine("No lines of input found.");
    return;
}
var game = new Game(new List<string>(lines));
var tailVisited = game.Run();
Console.WriteLine("Tail visited: " + tailVisited);