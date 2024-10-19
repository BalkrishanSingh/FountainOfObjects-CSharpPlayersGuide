namespace FountainOfObjects.Game.Grid.Room;

public class Room 
{
    public Coordinate Coordinate { get; }

    public Room(Coordinate coordinate)
    {
        Coordinate = coordinate;
    }

    public virtual string RoomDescription() => "There is nothing to see here...";
}