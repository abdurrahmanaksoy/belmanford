using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelmanFordRouting
{
    public class Path
    {
        public string From;
        public string To;
        public int Cost;

        public Path(string from, string to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }
    }
    public class Program
    {
        public static string[] vertices = { "S", "A", "B", "C", "D", "E" };

        public static List<Path> graph = new List<Path>()
        {
            new Path("S", "A", 1),
            new Path("S", "E", 2),
            new Path("A", "C", 3),
            new Path("B", "A", 2),
            new Path("C", "B", 1),
            new Path("D", "C", 3),
            new Path("D", "A", 1),
            new Path("E", "D", 2)
        };

        public static Dictionary<string, int> memo = new Dictionary<string, int>()
        {
            { "S", 0 },
            { "A", int.MaxValue },
            { "B", int.MaxValue },
            { "C", int.MaxValue },
            { "D", int.MaxValue },
            { "E", int.MaxValue }
        };

        public static bool Iterate()
        {
            bool doItAgain = false;

            foreach (var fromVertex in vertices)
            {
                Path[] edges = graph.Where(x => x.From == fromVertex).ToArray();
                foreach (var edge in edges)
                {
                    int potentialCost = memo[edge.From] == int.MaxValue ? int.MaxValue : memo[edge.From] + edge.Cost;
                    if (potentialCost < memo[edge.To])
                    {
                        memo[edge.To] = potentialCost;
                        doItAgain = true;
                    }
                }
            }
            return doItAgain;
        }

        static void Main()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                if (!Iterate())
                    break;
            }

            foreach (var keyValue in memo)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
            Console.ReadLine();
        }
    }
}
