using System;
using System.Collections.Generic;

namespace _5TreesAndGraphs
{
    /// <summary>
    /// Directed graph represented by adjacency list
    /// </summary>
    public class GraphAdjacencyList
    {
        private Dictionary<int, List<int>> _adjacencyList = new Dictionary<int, List<int>>();

        public void AddEdge(int source, int target)
        {
            if (!_adjacencyList.ContainsKey(source))
            {
                _adjacencyList[source] = new List<int>();
            }

            if (!_adjacencyList.ContainsKey(target))
            {
                _adjacencyList[target] = new List<int>();
            }

            _adjacencyList[source].Add(target);
        }

        public void RemoveEdge(int source, int target)
        {
            _adjacencyList[source].Remove(target);
        }

        public bool BFS(int source, int key)
        {
            var queue = new Queue<int>();
            var visited = new HashSet<int>();

            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                var dequeued = queue.Dequeue();  
                if (dequeued == key) return true;
                              
                var adjacentNodes = _adjacencyList[dequeued];

                foreach (var node in adjacentNodes)
                {
                    if (visited.Contains(node)) continue;

                    visited.Add(node);
                    queue.Enqueue(node);
                }
            }

            return false;
        }

        public void Print()
        {
            foreach (var nodeList in _adjacencyList)
            {
                Console.Write($"Node: " + nodeList.Key + " => ");
                foreach (var targetNode in nodeList.Value)
                {
                    Console.Write(targetNode + ", ");
                }
                Console.WriteLine("");
            }
        }
    }
}
