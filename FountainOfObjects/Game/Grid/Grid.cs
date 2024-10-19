using FountainOfObjects.Game.Grid.Room;

namespace FountainOfObjects.Game.Grid;

public class Grid
{
    private Room.Room[,] Rooms { get; }
    public Dictionary<Type, Coordinate> RoomsCoordinates { get; private set; } = new Dictionary<Type, Coordinate>();

    public Grid(Room.Room[,] rooms)
    {
        Rooms = rooms;
    }


    public Room.Room this[Coordinate coordinate]
    {
        get => Rooms[coordinate.Row, coordinate.Column];
    }

    public Room.Room this[Type roomType]
    {
        get
        {
            if (RoomsCoordinates.TryGetValue(roomType, out var coordinate))
            {
                return this[coordinate];
            }

        
            if ( TryFindRoomCoordinate(roomType, out var roomCoordinate))
            {
                RoomsCoordinates.Add(roomType, roomCoordinate!); 
                return this[roomCoordinate!];
            }
            
            throw new KeyNotFoundException($"Room type {roomType.Name} not found");
        }
}

    /// <summary>
    /// This function returns whether a bool representing if a particular room type exist in the grid and if yes,
    /// the coordinate of the first one located and if no, null.
    /// </summary>
    /// <param name="roomType"></param>
    /// <param name="coordinate"></param>
    public bool TryFindRoomCoordinate(Type roomType,out Coordinate? coordinate)
    {
        foreach (var room in Rooms)
        {
            if (room.GetType() == roomType)
            {
                 coordinate = room.Coordinate;
                 return true;

            }
        }
        coordinate = null;
        return false;

    }

    /// <summary>
    /// returns all adjacent rooms around a given center room.
    /// </summary>
    /// <param name="centerRoom"></param>
    private List<Room.Room> GetAdjacentRooms(Room.Room centerRoom)
    {
        List<Room.Room> adjacentRooms = new();
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
    public List<Room.Room> GetAdjacentEventRooms(Room.Room centerRoom)
    {
        List<Room.Room> nonEmptyAdjacentRooms = new();
        foreach (Room.Room room in GetAdjacentRooms(centerRoom))
        {
            if (room.GetType() != typeof(Room.Room))
            {
                nonEmptyAdjacentRooms.Add(room);
            }
        }

        return nonEmptyAdjacentRooms;
    }
}