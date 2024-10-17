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

    /// <summary>
    /// This function returns whether a bool representing if a particular room type exist in the grid and if yes,
    /// at which location and if no, it returns a Coordinate object at (-1,-1).
    /// </summary>
    /// <param name="roomType"></param>
    /// <param name="coordinate"></param>
    public bool FindRoom(Type roomType, out Coordinate coordinate)
    {
        foreach (var room in Rooms)
        {
            if (room.GetType() == roomType)
            {
                coordinate = room.Coordinate;
                return true;
            }
        }

        coordinate = new Coordinate(-1, -1);
        return false;
    }

    /// <summary>
    /// returns all adjacent rooms around a given center room.
    /// </summary>
    /// <param name="centerRoom"></param>
    private List<Room> GetAdjacentRooms(Room centerRoom)
    {
        List<Room> adjacentRooms = new();
        for (int i = centerRoom.Coordinate.Row - 1; i <= centerRoom.Coordinate.Row + 1; i++)
        {
            for (int j = centerRoom.Coordinate.Column - 1; j <= centerRoom.Coordinate.Column + 1; j++)
            {
                if (!(i < 0 || j < 0))
                {
                    adjacentRooms.Add(Rooms[i, j]);
                }
            }
        }

        return adjacentRooms;
    }

    /// <summary>
    /// returns all adjacent rooms with Events around a given center room.
    /// </summary>
    /// <param name="centerRoom"></param>
    public List<Room> GetAdjacentEventRooms(Room centerRoom)
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