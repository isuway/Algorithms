using System;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var vertices = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            var edges = new[]
            {
                (1, 2), (1, 3), (2, 4), (3, 5), (3, 6), (4, 7),
                (5, 7), (5, 8), (5, 6), (8, 9), (9, 10), (10, 11)
            };
            var graph = new Graph<int>(vertices, edges);
            var alg = new DFS();
            var result = alg.Execute(graph, 1);
            Console.WriteLine(string.Join(", ", alg.Execute(graph, 1)));
        }
    }
}