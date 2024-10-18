using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Player.Commands;

public class MoveCommand(Player player, Direction direction) : IPlayerCommand
{


    public bool Execute()
    {
        Coordinate oldCoordinate = player.PlayerPosition;
        switch (direction)
        {
               
            case Direction.East:
                player.PlayerPosition += new Coordinate(0, 1);
                break;
            case Direction.West:
                player.PlayerPosition += new Coordinate(0, -1);
                break;
            case Direction.North:
                player.PlayerPosition += new Coordinate(1, 0);
                break;
            case Direction.South:
                player.PlayerPosition += new Coordinate(-1, 0);
                break;

        }
        if (player.PlayerPosition.Column < 0 || player.PlayerPosition.Row < 0)
        {
            player.PlayerPosition = oldCoordinate;
            return true;
        }

        return false;
    }
}