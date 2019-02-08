using System.Collections.Generic;
using DijkstraAlgorithm;
using NUnit.Framework;

namespace TestDijkstraAlgorithm
{
    [TestFixture]
    public class TestAlgorithm
    {
        #region Methods

        [Test, TestCaseSource(typeof(TestAlgorithmSource), nameof(TestAlgorithmSource.BuildTestCases))]
        public void TestDijkstraAlgorithm(IDijkstraAlgorithm algorithm, Graph graph, Vertex from, Vertex to, IEnumerable<Vertex> expected)
        {
            var solveGraph = new SolveGraph(algorithm, graph);
            var calculatedPath = solveGraph.ShortestPath(from, to).GetPathToDestination();
            Assert.That(calculatedPath, Is.EqualTo(expected), $"Path from {from.Name} to {to.Name} miscalculated");
        }

        #endregion Methods
    }
}