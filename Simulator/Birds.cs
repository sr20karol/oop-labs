namespace Simulator;

using Simulator.Maps;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override string Info
        => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";

    public override char MapSymbol => CanFly ? 'B' : 'b';

    public override void Go(Direction direction)
    {
        if (map is null) return;

        Point nextPoint;

        if (CanFly)
        {
            Point first = map.Next(Position, direction);
            nextPoint = map.Next(first, direction);
        }
        else
        {
            nextPoint = map.NextDiagonal(Position, direction);
        }

        map.Move(this, Position, nextPoint);
        point = nextPoint;
    }
}
