namespace FountainOfObjects.Game.Grid.Rooms;

public class Room : IRoomEventHandler
{
    public Coordinate Coordinate { get; }

    public Room(Coordinate coordinate)
    {
        Coordinate = coordinate;
    }

    public void RunRoomEvent()
    {
    }

    public virtual string RoomDescription() => "There is nothing to see here...";
}