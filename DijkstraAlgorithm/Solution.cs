using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DijkstraAlgorithm
{
    public class Solution
    {
        #region Properties

        public IReadOnlyDictionary<Vertex, Path> Paths { get; }
        public Vertex Source { get; }

        #endregion Properties

        #region Constructors

        public Solution(Vertex source, IDictionary<Vertex, Path> paths)
        {
            this.Source = source;
            Paths = new ReadOnlyDictionary<Vertex, Path>(paths);
        }

        #endregion Constructors
    }
}