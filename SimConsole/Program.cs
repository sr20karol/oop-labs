using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimConsole;

class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Choose simulation:");
        Console.WriteLine("1 - Creatures only");
        Console.WriteLine("2 - Creatures + Animals");
        Console.WriteLine("3 - LogVisualizer");
        Console.Write("Your choice: ");

        string? choice = Console.ReadLine();
        Console.Clear();

        switch (choice)
        {
            case "1":
                Sim1();
                break;
            case "2":
                Sim2();
                break;
            case "3":
                Sim3();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
    static void Sim1()
    {

        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new SmallSquareMap(5);

        List<Imappable> creatures = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };

        List<Point> points = new()
        {
            new Point(2, 2),
            new Point(3, 1)
        };

        string moves = "dlrludl";

        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer visualizer = new MapVisualizer(simulation.Map);

        Console.WriteLine("Sim1 - creatures only:");
        visualizer.Draw();

        while (!simulation.Finished)
        {
            simulation.Turn();
            Console.WriteLine();
            visualizer.Draw();
            System.Threading.Thread.Sleep(500);
        }

        Console.WriteLine("Simulation finished.");
    }

    static void Sim2()
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new SmallTorusMap(8, 6);

        List<Imappable> creatures = new()
        {
        new Elf("Elandor"),
        new Orc("Gorbag"),

        new Animals { Description = "Krolik1" },
        new Animals { Description = "Krolik2" },
        new Animals { Description = "Krolik3" },

        new Birds { Description = "Orzel1", CanFly = true },
        new Birds { Description = "Orzel2", CanFly = true },

        new Birds { Description = "Strus1", CanFly = false },
        new Birds { Description = "Strus2", CanFly = false },
        };

        List<Point> points = new()
        {
        new Point(1,1),  // Elf
        new Point(2,1),  // Orc
        new Point(3,0),  // Krolik1
        new Point(3,1),  // Krolik2
        new Point(3,2),  // Krolik3
        new Point(0,5),  // Orzel1
        new Point(1,5),  // Orzel2
        new Point(7,0),  // Strus1
        new Point(6,0),  // Strus2
        };

        string moves = "dlrudldrudldrudldrld";

        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer visualizer = new MapVisualizer(simulation.Map);

        Console.WriteLine("Sim2 - creatures + animals:");
        visualizer.Draw();

        while (!simulation.Finished)
        {
            simulation.Turn();
            Console.WriteLine();
            visualizer.Draw();
            System.Threading.Thread.Sleep(1000);
        }

        Console.WriteLine("Simulation finished.");
    }

    static void Sim3()
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new SmallTorusMap(8, 6);

        List<Imappable> objects = new()
    {
        new Elf("Elandor"),
        new Orc("Gorbag"),

        new Animals { Description = "Krolik1" },
        new Animals { Description = "Krolik2" },
        new Animals { Description = "Krolik3" },

        new Birds { Description = "Orzel1", CanFly = true },
        new Birds { Description = "Orzel2", CanFly = true },

        new Birds { Description = "Strus1", CanFly = false },
        new Birds { Description = "Strus2", CanFly = false },
    };

        List<Point> points = new()
    {
        new Point(1,1),  // Elf
        new Point(2,1),  // Orc
        new Point(3,0),  // Krolik1
        new Point(3,1),  // Krolik2
        new Point(3,2),  // Krolik3
        new Point(0,5),  // Orzel1
        new Point(1,5),  // Orzel2
        new Point(7,0),  // Strus1
        new Point(6,0),  // Strus2
    };

        string moves = "dlrudldrudldrudldrld";

        Simulation simulation = new Simulation(map, objects, points, moves);

        SimulationLog log = new SimulationLog(simulation);

        LogVisualizer visualizer = new LogVisualizer(log);

        int[] selectedTurns = { 5, 10, 15, 20 };

        foreach (int t in selectedTurns)
        {
            int logIndex = t;
            if (logIndex < log.TurnLogs.Count)
            {
                Console.WriteLine($"--- Turn {t} ---");
                visualizer.Draw(logIndex);
                Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey(true);
            }
        }
    }
}
