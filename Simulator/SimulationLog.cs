using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator
{
    public class SimulationLog
    {
        private Simulation _simulation { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public List<TurnLog> TurnLogs { get; } = new();

        public SimulationLog(Simulation simulation)
        {
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;
            Run();
        }

        private void Run()
        {
            TurnLogs.Add(new TurnLog
            {
                Mappable = "START",
                Move = "-",
                Symbols = CreateMapSymbols()
            });

            while (!_simulation.Finished)
            {
                var obj = _simulation.CurrentCreature;
                string move = _simulation.CurrentMoveName;

                _simulation.Turn();

                TurnLogs.Add(new TurnLog
                {
                    Mappable = obj.ToString(),
                    Move = move,
                    Symbols = CreateMapSymbols()
                });
            }
        }

        private Dictionary<Point, char> CreateMapSymbols()
        {
            var symbols = new Dictionary<Point, char>();

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    foreach (var mappable in _simulation.Map.At(x, y))
                    {
                        Point p = mappable.Position;
                        if (symbols.ContainsKey(p))
                            symbols[p] = 'X';
                        else
                            symbols[p] = mappable.MapSymbol;
                    }
                }
            }

            return symbols;
        }

        /// <summary>
        /// Zwraca zapis mapy w danej turze.
        /// </summary>
        public Dictionary<Point, char> GetMapAtTurn(int turnNumber)
        {
            if (turnNumber < 0 || turnNumber >= TurnLogs.Count)
                throw new ArgumentOutOfRangeException(nameof(turnNumber));

            return TurnLogs[turnNumber].Symbols;
        }
    }
}
