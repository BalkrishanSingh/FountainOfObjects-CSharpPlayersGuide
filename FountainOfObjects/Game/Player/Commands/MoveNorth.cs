using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Player.Commands;

public class MoveNorth : IPlayerMovable
{
    public void Move(Player player)
    {
        player.PlayerPosition += new Coordinate(1, 0);
    }
}