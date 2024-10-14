using System.Diagnostics.CodeAnalysis;

namespace FountainOfObjects.Game.Grid.Rooms;

public struct Coordinate
{
    public int Row{get;}
    public int Column{get;}

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }
    public bool CheckAdjacency(Coordinate coordinate) => CheckDiagonalAdjacency(coordinate) || CheckOrthogonalAdjacency(coordinate);
    private bool CheckOrthogonalAdjacency(Coordinate coordinate) => Math.Abs(Row - coordinate.Row) + Math.Abs(Column - coordinate.Column) == 1;
    private bool CheckDiagonalAdjacency(Coordinate coordinate) => Math.Abs(Row - coordinate.Row) == 1 && Math.Abs(Column - coordinate.Column) == 1;
}

