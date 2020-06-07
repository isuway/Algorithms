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
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        /// <summary>
        /// check if the graph contains a vertex
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool ContainsVertex(T vertex)
        {
            return AdjacencyList.ContainsKey(vertex);
        }
        
        /// <summary>
        /// get neighbors by vertex
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public HashSet<T> GetNeighbors(T vertex)
        {
            return AdjacencyList[vertex];
        }

        /// <summary>
        /// add new vertex
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        /// <summary>
        /// edge binds two vertices
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge((T, T) edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

    }
}