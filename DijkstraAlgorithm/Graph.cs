using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DijkstraAlgorithm
{
    public class Graph
    {
        #region Fields

        private readonly IDijkstraAlgorithm dijkstraAlgorithm;
        private readonly IList<Edge> edges;
        private readonly Dictionary<Vertex, Solution> solutions;
        private readonly IList<Vertex> vertexes;

        #endregion Fields

        #region Properties

        public IDijkstraAlgorithm DijkstraAlgorithm => this.dijkstraAlgorithm;
        public IReadOnlyCollection<Edge> Edges => new ReadOnlyCollection<Edge>(this.edges);
        public IReadOnlyCollection<Vertex> Vertexes => new ReadOnlyCollection<Vertex>(this.vertexes);

        #endregion Properties

        #region Constructors

        public Graph(IDijkstraAlgorithm dijkstraAlgorithm, IEnumerable<Vertex> vertexes, IEnumerable<Edge> edges)
        {
            this.solutions = new Dictionary<Vertex, Solution>();
            this.dijkstraAlgorithm = dijkstraAlgorithm;
            this.vertexes = new List<Vertex>(vertexes);
            this.edges = new List<Edge>(edges);
            if (!this.CheckValidData())
            {
                throw new ArgumentException("Vertexes and edges provided as graph do not match");
            }
        }

        #endregion Constructors

        #region Methods

        public Path ShortestPath(Vertex from, Vertex to)
        {
            if (!this.vertexes.Contains(from))
            {
                throw new ArgumentException($"Vertex {from.Name}|{from.Guid.ToString()} does not exist in graph", nameof(from));
            }
            if (!this.vertexes.Contains(to))
            {
                throw new ArgumentException($"Vertex {to.Name}|{to.Guid.ToString()} does not exist in graph", nameof(from));
            }

            if (!this.solutions.ContainsKey(from))
            {
                Solution solution = this.dijkstraAlgorithm.ShortestPath(this, from);
                if (solution != null)
                {
                    this.solutions.Add(from, solution);
                }
                else
                {
                    throw new InvalidOperationException($"Solution to this graph with source vertex {from.Name} could not be calculated");
                }
            }

            if (this.solutions[from].Paths.TryGetValue(to, out Path path))
            {
                return path;
            }
            throw new InvalidOperationException($"No solution going from vertex {from.Name} to vertex {to.Name} was successfully calculated");
        }

        private bool CheckValidData()
        {
            return this.edges.All(edge => this.vertexes.Contains(edge.Vertex1) &&
                                          this.vertexes.Contains(edge.Vertex2));
        }

        #endregion Methods
    }
}