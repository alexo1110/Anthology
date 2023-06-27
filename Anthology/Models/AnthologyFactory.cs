using System.Security.Cryptography;

namespace Anthology.Models
{
    public static class AnthologyFactory
    {
        public static HashSet<Agent> GenerateAgents(uint n, int gridSize)
        {
            HashSet<Agent> agents = new();
            Random r = new();

            for (uint i = 0; i < n; i++)
            {
                Agent a = new()
                {
                    Name = "a_" + i,
                    Motives =
                    {
                        { "m1", r.Next(4) + 1 },
                        { "m2", r.Next(4) + 1 },
                        { "m3", r.Next(4) + 1 },
                        { "m4", r.Next(4) + 1 },
                        { "m5", r.Next(4) + 1 }
                    },
                    XLocation = r.Next(gridSize),
                    YLocation = r.Next(gridSize),
                };
                agents.Add(a);
            }
            return agents;
        }

        public static HashSet<SimLocation> GenerateSimLocations(uint n, int gridSize)
        {
            HashSet<SimLocation> simLocations = new();
            Random r = new();
            for (uint i = 0; i < n; i++)
            {
                SimLocation sl = new()
                {
                    Name = "l_" + i,
                    X = r.Next(gridSize),
                    Y = r.Next(gridSize),
                    Tags =
                    {
                        "t_" + (i % 3),
                        "t_" + ((i % 7) + 3)
                    }
                };
                simLocations.Add(sl);
            }
            return simLocations;
        }

        public static HashSet<PrimaryAction> GeneratePrimaryActions(uint n)
        {
            HashSet<PrimaryAction> actions = new();
            Random r = new();

            for (uint i = 0; i < n; i++)
            {
                int rltype = r.Next(2);
                RLocation rl = new();
                switch (rltype)
                {
                    case 0:
                        rl.HasAllOf.Add("t_" + r.Next(9));
                        break;
                    case 1:
                        rl.HasNoneOf.Add("t_" + r.Next(9));
                        break;
                    case 2:
                        rl.HasOneOrMoreOf.Add("t_" + r.Next(0));
                        break;
                }

                PrimaryAction a = new()
                {
                    Name = "action_" + i,
                    Effects =
                    {
                        { "m1", r.Next(2) },
                        { "m2", r.Next(2) },
                        { "m3", r.Next(2) },
                        { "m4", r.Next(2) },
                        { "m5", r.Next(2) }
                    },
                    MinTime = r.Next(285) + 15,
                    Requirements =
                    {
                        Locations = new() { rl }
                    }
                };
                actions.Add(a);
            }
            return actions;
        }
    }
}
