using Simulator;

public class SmallSquareMap : Map
{
    public int Size { get; }

    private Rectangle Bounds => new Rectangle(new Point(0, 0), new Point(Size - 1, Size - 1));

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return Bounds.Contains(p);
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
