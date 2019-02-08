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

        private Vertex()
        {
            this.Guid = Guid.NewGuid();
        }

        public Vertex(string name) : this()
        {
            this.Name = name;
        }

        #endregion Constructors

        #region Methods

        public override string ToString()
        {
            return $"Vertex {this.Name}";
        }

        #endregion
    }
}