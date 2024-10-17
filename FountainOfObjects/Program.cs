using FountainOfObjects.Game;
using FountainOfObjects.Game.Grid.Generator;

IGridGenerator gridGenerator = ChooseGridSettings();
Game game = new Game(gridGenerator);
game.Run();

IGridGenerator ChooseGridSettings()
{
    return new SmallGridGenerator();
}