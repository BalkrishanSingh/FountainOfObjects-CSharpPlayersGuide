using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Player;

public class Player
{
    public Coordinate PlayerPosition { get; private set; }

    public Player(Grid.Grid grid)
    {
        if (grid.FindRoom(typeof(EntranceRoom), out Coordinate coordinate))
        {
            PlayerPosition = coordinate;
        }
        else
        {
            throw new Exception("Entrance room hasn't been made.");
        }
    }
}