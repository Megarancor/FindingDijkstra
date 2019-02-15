using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DijkstraAlgorithm
{
    public class Graph
    {
        #region Fields

        private readonly IList<Edge> edges;
        private readonly IList<Vertex> vertexes;

        #endregion Fields

        #region Properties

        public IReadOnlyCollection<Edge> Edges => new ReadOnlyCollection<Edge>(this.edges);

        public IReadOnlyCollection<Vertex> Vertexes => new ReadOnlyCollection<Vertex>(this.vertexes);

        #endregion Properties

        #region Constructors

        public Graph(IEnumerable<Vertex> vertexes, IEnumerable<Edge> edges)
        {
            this.vertexes = new List<Vertex>(vertexes);
            this.edges = new List<Edge>(edges);
            if (!this.CheckValidData())
            {
                throw new ArgumentException("Vertexes and edges provided as graph do not match");
            }
        }

        #endregion Constructors

        #region Methods

        private bool CheckValidData()
        {
            return this.edges.All(edge => this.vertexes.Contains(edge.Vertex1) &&
                                          this.vertexes.Contains(edge.Vertex2));
        }

        public bool Contains(Vertex vertex)
        {
            return this.vertexes.Contains(vertex);
        }

        public IEnumerable<Vertex> GetNeighborsOf(Vertex vertex)
        {
            return this.Vertexes.Where(v => this.Edges.Any(e => e.IsJoining(vertex, v)));
        }

        public int WeightBetween(Vertex vertex1, Vertex vertex2)
        {
            return this.Edges.FirstOrDefault(e => e.IsJoining(vertex1, vertex2))?.Weight ??
                   throw new
                       InvalidOperationException($"No edge connecting {vertex1.Name} and {vertex2.Name} was found");
        }

        #endregion Methods
    }
}