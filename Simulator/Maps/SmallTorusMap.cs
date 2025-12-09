namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Size must be below 20");
        if (sizeY > 20)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Size must be below 20");

    }

    public override Point Next(Point p, Direction direction)
    {
        Point next = p.Next(direction);
        int x = (next.X + SizeX) % SizeX;
        int y = (next.Y + SizeY) % SizeY;
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction direction)
    {
        Point next = p.NextDiagonal(direction);
        int x = (next.X + SizeX) % SizeX;
        int y = (next.Y + SizeY) % SizeY;
        return new Point(x, y);
    }
}
