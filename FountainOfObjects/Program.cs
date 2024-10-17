using FountainOfObjects.Game;
using FountainOfObjects.Game.Grid.Generator;

Console.WriteLine("Hello, World!");
IGridGenerator gridGenerator = ChooseGridSettings();
Game game = new Game(gridGenerator);
game.Run();

IGridGenerator ChooseGridSettings()
{
    return new SmallGridGenerator();
}