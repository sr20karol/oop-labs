namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
        Size = size;
    }


    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction direction)
    {
        Point next = p.Next(direction);
        int x = (next.X + Size) % Size;
        int y = (next.Y + Size) % Size;
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction direction)
    {
        Point next = p.NextDiagonal(direction);
        int x = (next.X + Size) % Size;
        int y = (next.Y + Size) % Size;
        return new Point(x, y);
    }
}
