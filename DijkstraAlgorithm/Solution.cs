using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class Solution
    {
        public Vertex Source { get; }

        public IDictionary<Vertex, Path> Paths { get; }

        public Solution(Vertex source)
        {
            this.Source = source;
            this.Paths = new Dictionary<Vertex, Path>();
        }
    }
}