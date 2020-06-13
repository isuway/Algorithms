using System;
using System.Collections.Generic;
using GraphCommon;

namespace BFS
{
    public class BFS
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"> starting vortex</param>
        /// <typeparam name="T"></typeparam>
        /// <returns> visited vertices </returns>
        public HashSet<T> VisitAll<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();
            if (!graph.ContainsVertex(start))
                return visited;
            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                // continue if exists or add
                if (!visited.Add(vertex))
                    continue;
                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }

            return visited;
        }

        /// <summary>
        /// Find the shortest path to the target vertex
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="from"> initial vertex </param>
        /// <param name="to"> target vertex </param>
        /// <typeparam name="T"></typeparam>
        /// <returns> vertex and path to it </returns>
        public Tuple<T, IEnumerable<T>> ShortestPath<T>(Graph<T> graph, T from, T to)
        {
            var previous = new Dictionary<T, T>();
            var queue = new Queue<T>();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    if (!previous.TryAdd(neighbor, vertex))
                        continue;
                    queue.Enqueue(neighbor);
                }
            }

            var path = new List<T>();

            var current = to;
            while (!current.Equals(from))
            {
                path.Add(current);
                current = previous[current];
            }

            path.Add(from);
            path.Reverse();
            return new Tuple<T, IEnumerable<T>>(from, path);
        }
    }
}