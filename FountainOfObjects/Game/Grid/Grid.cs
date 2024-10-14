using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Grid;

public class Grid 
{
    private Room[,] Rooms { get; }

    public Grid(Room[,] rooms)
    {
        Rooms = rooms;
    }

    public Room GetRoomAtCoordinate(Coordinate coordinate)
    {
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            for (int column = 0; column < Rooms.GetLength(1); column++)
            {
                if (Rooms[row, column].Coordinate == coordinate)
                {
                    return Rooms[row, column] ;
                }
            }
        }
    }
    public List<Room> GetNonEmptyAdjacentRooms(Room room)
    {
        
        
        List<Room> nonEmptyAdjacentRooms = new();
        foreach (Room possibleAdjacentRoom in Rooms)
        {
            if (room.Coordinate.CheckAdjacency(possibleAdjacentRoom.Coordinate) && room is not EmptyRoom)
            {
                nonEmptyAdjacentRooms.Add(possibleAdjacentRoom);
            }
        }
        
        
        //
        // for (int i = room.Coordinate.Row - 1; i <= room.Coordinate.Row + 1 ; i++)
        // {
        //     for (int j = room.Coordinate.Column - 1; j <= room.Coordinate.Column + 1 ; j++)
        //     {
        //         if (!(i < 0 || j < 0) && room is not EmptyRoom)
        //         {
        //             nonEmptyAdjacentRooms.Add(Rooms[i, j]);
        //         }
        //     }
        // }
        //
        return nonEmptyAdjacentRooms;
    }
}