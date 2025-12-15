using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;
public class SimulationModel : PageModel
{
    public SimulationLog Log { get; private set; }
    public int CurrentTurn { get; private set; }

    public void OnGet(int? turn)
    {
        Log = CreateSimulationLog();

        CurrentTurn = turn ?? 0;
        CurrentTurn = Math.Clamp(CurrentTurn, 0, Log.TurnLogs.Count - 1);
    }

    private SimulationLog CreateSimulationLog()
    {
        SmallTorusMap map = new SmallTorusMap(8, 8);

        List<Imappable> creatures = new()
        {
        new Elf("Elandor"),
        new Orc("Gorbag"),

        new Animals { Description = "Krolik" },

        new Birds { Description = "Orzel", CanFly = true },

        new Birds { Description = "Strus", CanFly = false },
        };

        List<Point> points = new()
        {
        new Point(1,3),  // Elf
        new Point(2,2),  // Orc
        new Point(5,5),  // Krolik1
        new Point(3,7),  // Orzel1
        new Point(4,0),  // Strus1
        };

        string moves = "dlrludluddlrulr";

        var simulation = new Simulation(map, creatures, points, moves);

        return new SimulationLog(simulation);
    }
}
