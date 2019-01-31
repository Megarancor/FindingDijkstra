using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DijkstraAlgorithm
{
    public class Graph
    {
        private readonly IList<Vertex> vertexes;
        public IReadOnlyCollection<Vertex> Vertexes => new ReadOnlyCollection<Vertex>(this.vertexes);

        private readonly IList<Edge> edges;
        public IReadOnlyCollection<Edge> Edges => new ReadOnlyCollection<Edge>(this.edges);

        private readonly IDijkstraAlgorithm dijkstraAlgorithm;
        public IDijkstraAlgorithm DijkstraAlgorithm => dijkstraAlgorithm;

        private readonly Dictionary<Vertex, Solution> solutions;

        public Graph(IDijkstraAlgorithm dijkstraAlgorithm, IEnumerable<Vertex> vertexes, IEnumerable<Edge> edges)
        {
            this.solutions = new Dictionary<Vertex, Solution>();
            this.dijkstraAlgorithm = dijkstraAlgorithm;
            this.vertexes = new List<Vertex>(vertexes);
            this.edges = new List<Edge>(edges);
        }

        public Path ShortestPath(Vertex from, Vertex to)
        {
            throw new NotImplementedException();
        }
    }
}