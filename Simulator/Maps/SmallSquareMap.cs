using Simulator;

public class SmallSquareMap : Map
{
    public int Size { get; }

    public SmallSquareMap(int size) : base(size, size)
    {
        if (size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be below 20");

        Size = size;
    }

    public override Point Next(Point p, Direction direction)
    {
        return p.Next(direction);
    }

    public override Point NextDiagonal(Point p, Direction direction)
    {
        return p.NextDiagonal(direction);
    }
}
