using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Grid;

public class Grid
{
    private Room[,] Rooms { get; }


    public Grid(Room[,] rooms)
    {
        Rooms = rooms;
    }

    public Room this[Coordinate coordinate]
    {
        get => Rooms[coordinate.Row, coordinate.Column];
    }

    public List<Room> GetAdjacentRooms(Room room)
    {
        List<Room> adjacentRooms = new();
        for (int i = room.Coordinate.Row - 1; i <= room.Coordinate.Row + 1; i++)
        {
            for (int j = room.Coordinate.Column - 1; j <= room.Coordinate.Column + 1; j++)
            {
                if (!(i < 0 || j < 0))
                {
                    adjacentRooms.Add(Rooms[i, j]);
                }
            }
        }

        return adjacentRooms;
    }

    public List<Room> GetNonEmptyAdjacentRooms(Room centerRoom)
    {

        List<Room> nonEmptyAdjacentRooms = new();
        foreach (Room room in GetAdjacentRooms(centerRoom))
        {
            if (room.GetType() != typeof(Room))
            {
                nonEmptyAdjacentRooms.Add(room);
            }
        }

        return nonEmptyAdjacentRooms;
    }
}