namespace FountainOfObjects.Game.Grid.Rooms;

public class Room 
{
    public Coordinate Coordinate { get;}

    public Room(Coordinate coordinate)
    {
       Coordinate = coordinate;
    }

    public virtual string RoomDescription() => "There is nothing to see here...";
        
    public override string ToString()
    {
        return $"You are in the room at {Coordinate}";
    }
}