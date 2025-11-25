namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int singCounter = 0;

    public int Agility
    {
        get => agility;
        init
        {
            if (value < 0) agility = 0;
            else if (value > 10) agility = 10;
            else agility = value;
        }
    }

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCounter++;

        if (singCounter % 3 == 0 && agility < 10)
        {
            agility++;
            Console.WriteLine($"{Name}'s agility increased to {agility}!");
        }
    }

    public override int Power => 8 * Level + 2 * Agility;

    public Elf(string name, int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
    }

    public Elf() : base("Unknown", 1)
    {
        Agility = 1;
    }

    public override void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
}