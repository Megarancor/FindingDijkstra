using DijkstraAlgorithm;
using NUnit.Framework;

namespace TestSimpleDijkstraAlgorithm
{
    [TestFixture]
    public class TestAlgorithm
    {
        #region Methods

        [Test]
        public void TestSimpleAlgorithm()
        {
            IDijkstraAlgorithm algorithm = new SimpleDijkstraAlgorithm.SimpleDijkstraAlgorithm();
            (Vertex[] vertexes, Edge[] edges) = BuildGraph();
            var graph = new Graph(algorithm, vertexes, edges);

            var calculatedPathCA = graph.ShortestPath(vertexes[2], vertexes[0]).GetPathToDestination();
            Assert.That(calculatedPathCA, Is.EquivalentTo(new[] { vertexes[2], vertexes[0] }));

            var calculatedPathCE = graph.ShortestPath(vertexes[2], vertexes[4]).GetPathToDestination();
            Assert.That(calculatedPathCE, Is.EquivalentTo(new[] { vertexes[2], vertexes[0], vertexes[1], vertexes[4] }));
        }

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

        #endregion Methods
    }
}