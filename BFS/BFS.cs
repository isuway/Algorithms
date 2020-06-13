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
        public HashSet<T> Execute<T>(Graph<T> graph, T start)
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
    }
}