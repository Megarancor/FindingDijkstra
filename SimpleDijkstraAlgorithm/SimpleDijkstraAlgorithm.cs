using DijkstraAlgorithm;
using System.Collections.Generic;
using System.Linq;

namespace SimpleDijkstraAlgorithm
{
    public class SimpleDijkstraAlgorithm : IDijkstraAlgorithm
    {
        #region Methods

        public Solution ShortestPaths(Graph graph, Vertex source)
        {
            (List<Vertex> vertexesToStudy,
             Dictionary<Vertex, int> distanceFromSource,
             Dictionary<Vertex, Path> pathsToVertexes) =
                Initialize(graph);

            distanceFromSource[source] = 0;

            while (vertexesToStudy.Any())
            {
                Vertex vertexToStudy = VertexWithMinDistanceFromSource(vertexesToStudy, distanceFromSource);

                vertexesToStudy.Remove(vertexToStudy);

                int distanceToStudiedVertex = distanceFromSource[vertexToStudy];

                foreach (var neighbor in graph.GetNeighborsOf(vertexToStudy))
                {
                    int tentativeDistanceToNeighbor =
                        distanceToStudiedVertex + graph.WeightBetween(vertexToStudy, neighbor);
                    if (tentativeDistanceToNeighbor < distanceFromSource[neighbor])
                    {
                        distanceFromSource[neighbor] = tentativeDistanceToNeighbor;
                        pathsToVertexes[neighbor].RebaseOn(pathsToVertexes[vertexToStudy]);
                    }
                }
            }

            return new Solution(source, pathsToVertexes);
        }

        public override string ToString()
        {
            return "Simple Dijkstra algorithm";
        }

        private static (List<Vertex>, Dictionary<Vertex, int>, Dictionary<Vertex, Path>) Initialize(Graph graph)
        {
            var vertexesToStudy = new List<Vertex>();
            var distanceFromSource = new Dictionary<Vertex, int>();
            var pathToVertexes = new Dictionary<Vertex, Path>();

            foreach (Vertex vertex in graph.Vertexes)
            {
                distanceFromSource.Add(vertex, int.MaxValue);
                pathToVertexes.Add(vertex, new Path(vertex));
                vertexesToStudy.Add(vertex);
            }

            return (vertexesToStudy, distanceFromSource, pathToVertexes);
        }

        private static Vertex VertexWithMinDistanceFromSource(IEnumerable<Vertex> vertexesToStudy, IReadOnlyDictionary<Vertex, int> distanceFromSource)
        {
            return vertexesToStudy.Aggregate((currentMinVertex, v) =>
                                             {
                                                 if (currentMinVertex == null)
                                                 {
                                                     return v;
                                                 }

                                                 if (distanceFromSource[v] < distanceFromSource[currentMinVertex])
                                                 {
                                                     return v;
                                                 }
                                                 return currentMinVertex;
                                             });
        }

        #endregion Methods
    }
}