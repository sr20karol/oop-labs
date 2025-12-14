namespace Simulator;

using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Imappable> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored.
    /// First move is for first creature, second for second, etc.
    /// When all creatures make moves, next move is again for first creature.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int moveIndex = 0;

    /// <summary>
    /// Creature which will be moving this turn.
    /// </summary>
    public Imappable CurrentCreature => Creatures[moveIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            if (Finished) return string.Empty;
            char c = Moves[moveIndex % Moves.Length];
            return c.ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throws exceptions if:
    /// - creatures list is empty,
    /// - number of creatures differs from number of positions.
    /// </summary>
    public Simulation(Map map, List<Imappable> creatures, List<Point> positions, string moves)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures ?? throw new ArgumentNullException(nameof(creatures));
        Positions = positions ?? throw new ArgumentNullException(nameof(positions));
        Moves = moves ?? string.Empty;

        if (Creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");
        if (Creatures.Count != Positions.Count)
            throw new ArgumentException("Number of creatures must match number of starting positions.");

        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throws exception if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        char moveChar = Moves[moveIndex % Moves.Length];
        var directions = DirectionParser.Parse(moveChar.ToString());

        if (directions.Count > 0)
        {
            CurrentCreature.Go(directions[0]);
        }

        moveIndex++;

        if (moveIndex >= Moves.Length)
            Finished = true;
    }
}
