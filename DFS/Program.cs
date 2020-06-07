using System;
using System.Collections.Generic;

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
            var dfs = new DFS();

            // to maintain order of results
            var orderedResult = new List<int>();
            
            var result = dfs.Execute(graph, 1, z => orderedResult.Add(z));
            
            Console.WriteLine(string.Join(", ", orderedResult));
            
            // result must be:  1, 3, 6, 5, 8, 9, 10, 11, 7, 4, 2
        }
    }
}