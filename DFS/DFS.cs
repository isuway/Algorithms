using System;
using System.Collections.Generic;

namespace DFS
{
    public class DFS
    {
        public HashSet<T> Execute<T>(Graph<T> graph, T start, Action<T> func = null)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(start))
            {
                return visited;
            }

            var stack = new Stack<T>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (visited.Contains(vertex))
                    continue;
                func?.Invoke(vertex);
                visited.Add(vertex);
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }

            return visited;
        }
    }
}