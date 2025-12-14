using Simulator;
using Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{

    public readonly int SizeX;
    public readonly int SizeY;
    private readonly Rectangle area;
    private readonly Dictionary<Point, List<Imappable>> creatures = new();
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Size must be greater than 5");
        if (sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Size must be greater than 5");

        SizeX = sizeX;
        SizeY = sizeY;
        area = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return area.Contains(p);
    }

    public void Add(Imappable mappable, Point p)
    {
        if (!creatures.TryGetValue(p, out var list))
        {
            list = new List<Imappable>();
            creatures[p] = list;
        }
        list.Add(mappable);
    }

    public void Remove(Imappable mappable, Point p)
    {
        if (creatures.TryGetValue(p, out var list))
        {
            list.Remove(mappable);
            if (list.Count == 0)
                creatures.Remove(p);
        }
    }

    public void Move(Imappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public IEnumerable<Imappable> At(Point p)
    {
        if (creatures.TryGetValue(p, out var list))
            return list;
        return Array.Empty<Imappable>();
    }

    public IEnumerable<Imappable> At(int x, int y)
    => At(new Point(x, y));



    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}