namespace FountainOfObjects.Game.Grid.Rooms;

public class FountainRoom : Room
{
    /// <summary> An enabled fountain is represented by true while false represents a disabled fountain
    /// </summary>
    public bool FountainState { get; set; } = false;

    public FountainRoom(Coordinate coordinate) : base(coordinate)
    {
    }

    public override string RoomDescription() => FountainState
        ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
        : "You hear water dripping in this room. The Fountain of Objects is here!";
}
