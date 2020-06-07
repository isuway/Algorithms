using System.Collections.Generic;

namespace DFS
{
    public class Graph<T>
    {
        public Graph()
        {
        }

        public Graph(IEnumerable<T> vertices, IEnumerable<(T, T)> edges)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        /// <summary>
        /// key represents a vertex and value - its set of neighbors
        /// </summary>
        public Dictionary<T, HashSet<T>> AdjecencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            AdjecencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge((T, T) edge)
        {
            if (AdjecencyList.ContainsKey(edge.Item1) && AdjecencyList.ContainsKey(edge.Item2))
            {
                AdjecencyList[edge.Item1].Add(edge.Item2);
                AdjecencyList[edge.Item2].Add(edge.Item1);
            }
        }

    }
}