using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class Path
    {
        #region Properties

        public Vertex Destination { get; }

        private Path BasePath { get; set; }

        #endregion Properties

        #region Constructors

        public Path(Vertex destination)
        {
            Destination = destination;
        }

        #endregion Constructors

        #region Methods

        public IReadOnlyCollection<Vertex> GetPathToDestination()
        {
            var resultPath = new List<Vertex>();
            resultPath.AddRange(BasePath?.GetPathToDestination() ?? new Vertex[0]);
            resultPath.Add(this.Destination);
            return resultPath;
        }

        public void RebaseOn(Path path)
        {
            this.BasePath = path;
        }

        #endregion Methods
    }
}