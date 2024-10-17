using FountainOfObjects.Game.Grid.Rooms;
using FountainOfObjects.Game.Player.Commands;

namespace FountainOfObjects.Game.Player;

public class Player
{
    public Coordinate PlayerPosition { get; set; }

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

    public string PositionString() => $"You are in the room at {PlayerPosition}";

    //TODO Handle out of index movement. For eg, moving south or west at coordinate (0,0)
    public bool Move(Direction direction)
    {
        Coordinate oldCoordinate = PlayerPosition;
        IPlayerMovable moveCommand = direction switch
        {
            Direction.East => new MoveEast(),
            Direction.North => new MoveNorth(),
            Direction.South => new MoveSouth(),
            Direction.West => new MoveWest(),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
        moveCommand.Move(this);
        if (PlayerPosition.Column < 0 || PlayerPosition.Row < 0)
        {
            PlayerPosition = oldCoordinate;
            return false;
        }

        return true;
    }
}