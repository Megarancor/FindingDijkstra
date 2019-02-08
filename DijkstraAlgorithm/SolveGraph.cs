using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class SolveGraph
    {
        #region Fields

        private readonly IDijkstraAlgorithm algorithm;
        private readonly Graph graph;
        private readonly Dictionary<Vertex, Solution> solutions;

        #endregion Fields

        #region Properties

        public IDijkstraAlgorithm DijkstraAlgorithm => this.algorithm;

        #endregion Properties

        #region Constructors

        public SolveGraph(IDijkstraAlgorithm algorithm, Graph graph)
        {
            this.solutions = new Dictionary<Vertex, Solution>();
            this.algorithm = algorithm;
            this.graph = graph;
        }

        #endregion Constructors

        #region Methods

        public Path ShortestPath(Vertex from, Vertex to)
        {
            if (!this.graph.Contains(from))
            {
                throw new ArgumentException($"Vertex {from.Name}|{from.Guid.ToString()} does not exist in graph", nameof(from));
            }
            if (!this.graph.Contains(to))
            {
                throw new ArgumentException($"Vertex {to.Name}|{to.Guid.ToString()} does not exist in graph", nameof(from));
            }

            if (!this.solutions.ContainsKey(from))
            {
                Solution solution = this.algorithm.ShortestPath(this.graph, from);
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

        #endregion Methods
    }
}