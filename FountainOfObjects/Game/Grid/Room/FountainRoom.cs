namespace FountainOfObjects.Game.Grid.Room;

public class FountainRoom : Room
{
    public FountainState FountainState { get; set; } = FountainState.Off;

    public FountainRoom(Coordinate coordinate) : base(coordinate)
    {
    }

    public override string RoomDescription() => FountainState == FountainState.On
        ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
        : "You hear water dripping in this room. The Fountain of Objects is here!";
}
