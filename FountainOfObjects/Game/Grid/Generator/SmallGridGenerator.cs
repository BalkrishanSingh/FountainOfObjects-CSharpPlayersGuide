using FountainOfObjects.Game.Grid.Room;

namespace FountainOfObjects.Game.Grid.Generator;

public class SmallGridGenerator : IGridGenerator
{
    public int Rows { get; } = 4;
    public int Columns { get; } = 4;

    public Grid GenerateGrid()
    {
        Room.Room?[,] rooms = new Room.Room[Rows, Columns];

        //Setting fixed locations for the entrance and fountain rooms.
        rooms[0, 0] = new EntranceRoom(new Coordinate(0, 0));
        rooms[0, 2] = new FountainRoom(new Coordinate(0, 2));


        // Filling the rest with base Room objects.

        for (int row = 0; row < rooms.GetLength(0); row++)
        {
            for (int column = 0; column < rooms.GetLength(1); column++)
            {
                {
                    if (rooms[row, column] == null)
                    {
                        rooms[row, column] = new Room.Room(new Coordinate(row, column));
                    }
                }
            }
        }

        return new Grid(rooms!);// There should be no null elements in array after the above loop.
    }
}