namespace FountainOfObjects.Game.Grid.Room;

public class EntranceRoom : Room
{
    public EntranceRoom(Coordinate coordinate) : base(coordinate)
    {
    }

    public override string RoomDescription() => "You see light coming from the cavern entrance.";
}