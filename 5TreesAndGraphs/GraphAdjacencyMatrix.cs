using System;
using System.Collections.Generic;
using System.Text;

namespace _5TreesAndGraphs
{
    public class GraphAdjacencyMatrix
    {
        //jagged Arrays: array of arrays
        private int[][] _adjacencyMatrix;

        public GraphAdjacencyMatrix(int numVertices)
        {
            _adjacencyMatrix = new int[numVertices][];

            for (int i = 0; i < _adjacencyMatrix.Length; i++)
            {
                _adjacencyMatrix[i] = new int[numVertices];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">Source vertex (0-based)</param>
        /// <param name="target">Target vertex (0-based)</param>
        public void AddEdge(int source, int target)
        {
            _adjacencyMatrix[source][target] = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">Source vertex (0-based)</param>
        /// <param name="target">Target vertex (0-based)</param>
        public void RemoveEdge(int source, int target)
        {
            _adjacencyMatrix[source][target] = 0;
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

                var adjacentNodes = _adjacencyMatrix[dequeued];

                for (int i =0; i< adjacentNodes.Length; i++)
                {
                    if (adjacentNodes[i] == 0 ||  visited.Contains(i)) continue;

                    visited.Add(i);
                    queue.Enqueue(i);
                }
            }

            return false;
        }

        public void Print()
        {
            for (int i = 0; i < _adjacencyMatrix.Length; i++)
            {
                Console.Write($"Node: " + i + " => ");
                for (int j = 0; j < _adjacencyMatrix[i].Length; j++)
                {
                    if (_adjacencyMatrix[i][j] == 0) continue;

                    Console.Write(j + ", ");
                }
                Console.WriteLine("");
            }
        }
    }
}
