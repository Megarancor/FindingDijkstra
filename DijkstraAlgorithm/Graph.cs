using System;

namespace DijkstraAlgorithm
{
    public class Graph
    {
        private readonly IDijkstraAlgorithm dijkstraAlgorithm;

        public Graph(IDijkstraAlgorithm dijkstraAlgorithm)
        {
            this.dijkstraAlgorithm = dijkstraAlgorithm;
        }

        public Path ShortestPath(Vertex from, Vertex to)
        {
            throw new NotImplementedException();
        }
    }
}