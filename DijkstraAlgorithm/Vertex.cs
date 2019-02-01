using System;

namespace DijkstraAlgorithm
{
    public class Vertex
    {
        #region Properties

        public Guid Guid { get; }
        public string Name { get; set; }

        #endregion Properties

        #region Constructors

        public Vertex()
        {
            this.Guid = Guid.NewGuid();
        }

        public Vertex(string name) : this()
        {
            this.Name = name;
        }

        #endregion Constructors
    }
}