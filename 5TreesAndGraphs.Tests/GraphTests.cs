using NUnit.Framework;

namespace _5TreesAndGraphs.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void TestBFSGraphAdjacencyList()
        {
            var graph = new GraphAdjacencyList();
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(0, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            Assert.IsTrue(graph.BFS(2, 1));
            Assert.IsTrue(graph.BFS(2, 0));
            Assert.IsTrue(graph.BFS(2, 3));
            Assert.IsFalse(graph.BFS(3, 0));
            Assert.IsFalse(graph.BFS(2, 5));
        }

        [Test]
        public void TestBFSGraphAdjacencyMatrix()
        {
            var graph = new GraphAdjacencyMatrix(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(0, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            Assert.IsTrue(graph.BFS(2, 1));
            Assert.IsTrue(graph.BFS(2, 0));
            Assert.IsTrue(graph.BFS(2, 3));
            Assert.IsFalse(graph.BFS(3, 0));
            Assert.IsFalse(graph.BFS(2, 5));
        }
    }
}
