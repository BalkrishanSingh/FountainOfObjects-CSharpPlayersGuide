using FountainOfObjects.Game.Grid.Room;

namespace FountainOfObjects.Game.Player;

public class Player
{
    public Coordinate PlayerPosition { get; set; }

    public Player(Grid.Grid grid)
    {
       
        if ( grid.TryFindRoomCoordinate(typeof(EntranceRoom), out var roomCoordinate ) )
        {
            PlayerPosition = roomCoordinate!;
        }
        else
        {
            throw new Exception("Entrance room hasn't been made.");
        }
    }

    public string PositionString() => $"You are in the room at {PlayerPosition}";
    

}