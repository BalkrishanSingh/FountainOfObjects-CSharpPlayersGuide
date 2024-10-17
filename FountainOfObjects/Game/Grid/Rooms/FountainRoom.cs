namespace FountainOfObjects.Game.Grid.Rooms;

public class FountainRoom : Room
{
    public bool FountainState { get; set; }

    public FountainRoom(Coordinate coordinate) : base(coordinate)
    {
    }

    public override string RoomDescription() => FountainState
        ? "You hear water dripping in this room. The Fountain of Objects is here!"
        : "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
}