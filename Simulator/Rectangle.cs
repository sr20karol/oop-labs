namespace Simulator;

public class Rectangle
{
    public readonly int X1;
    public readonly int Y1;
    public readonly int X2;
    public readonly int Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 > x2)
            (x1, x2) = (x2, x1);

        if (y1 > y2)
            (y1, y2) = (y2, y1);

        if (x1 == x2 || y1 == y2)
            throw new ArgumentException("Rectangle cannot be flat (no width or no height).");

        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }

    public Rectangle(Point p1, Point p2)
        : this(p1.X, p1.Y, p2.X, p2.Y)
    {
    }

    public bool Contains(Point p)
    {
        return p.X >= X1 && p.X <= X2 &&
               p.Y >= Y1 && p.Y <= Y2;
    }

    public override string ToString()
        => $"({X1}, {Y1}):({X2}, {Y2})";
}

