namespace FountainOfObjects.Game.Grid.Rooms;

public record struct Coordinate(int Row, int Column)
{
    public bool CheckAdjacency(Coordinate coordinate) => CheckDiagonalAdjacency(coordinate) || CheckOrthogonalAdjacency(coordinate);
    private bool CheckOrthogonalAdjacency(Coordinate coordinate) => Math.Abs(Row - coordinate.Row) + Math.Abs(Column - coordinate.Column) == 1;
    private bool CheckDiagonalAdjacency(Coordinate coordinate) => Math.Abs(Row - coordinate.Row) == 1 && Math.Abs(Column - coordinate.Column) == 1;
}

