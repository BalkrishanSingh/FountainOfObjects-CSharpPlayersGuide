using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Player.Commands;

public class MoveEast : IPlayerMovable
{
    public void Move(Player player)
    {
        player.PlayerPosition += new Coordinate(0, 1);
    }
}