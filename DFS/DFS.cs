using System;
using System.Collections.Generic;

namespace DFS
{
    public class DFS
    {
        /// <summary>
        /// depth-first search
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="starting vortex"> starting </param>
        /// <param name="func"> func executes while visiting a vortex </param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public HashSet<T> Execute<T>(Graph<T> graph, T start, Action<T> func = null)
        {
            // there'll be the result
            var visited = new HashSet<T>();

            // the result is empty
            if (!graph.ContainsVertex(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                // continue if exists or add
                if (!visited.Add(vertex))
                    continue;

                func?.Invoke(vertex);

                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }

            return visited;
        }
    }
}