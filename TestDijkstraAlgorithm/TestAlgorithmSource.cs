using System.Collections.Generic;
using DijkstraAlgorithm;
using NUnit.Framework;

namespace TestDijkstraAlgorithm
{
    public class TestAlgorithmSource
    {
        #region Properties

        private static IEnumerable<IDijkstraAlgorithm> DijkstraAlgorithms => new[]
        {
            new SimpleDijkstraAlgorithm.SimpleDijkstraAlgorithm(),
        };

        #endregion Properties

        #region Methods

        private static (Vertex[] vertexes, Edge[] edges) BuildGraph()
        {
            var vertexes = new[]
            {
                new Vertex("A"),
                new Vertex("B"),
                new Vertex("C"),
                new Vertex("D"),
                new Vertex("E"),
            };
            var edges = new[]
            {
                new Edge(vertexes[0], vertexes[1], 1),
                new Edge(vertexes[0], vertexes[2], 3),
                new Edge(vertexes[1], vertexes[2], 7),
                new Edge(vertexes[1], vertexes[4], 1),
                new Edge(vertexes[1], vertexes[3], 2),
                new Edge(vertexes[2], vertexes[3], 5),
                new Edge(vertexes[3], vertexes[4], 3),
            };
            return (vertexes, edges);
        }

        public static IEnumerable<TestCaseData> BuildTestCases()
        {
            (var vertexes, var edges) = BuildGraph();
            foreach (var algorithm in DijkstraAlgorithms)
            {
                var graph = new Graph(algorithm, vertexes, edges);
                yield return new TestCaseData(algorithm, graph, vertexes[2], vertexes[0], new[] { vertexes[2], vertexes[0] }).SetName($"{algorithm}: {vertexes[2]} to {vertexes[0]}");
                yield return new TestCaseData(algorithm, graph, vertexes[2], vertexes[4], new[] { vertexes[2], vertexes[0], vertexes[1], vertexes[4] }).SetName($"{algorithm}: {vertexes[2]} to {vertexes[4]}");
            }
        }

        #endregion Methods
    }
}