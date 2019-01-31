using System;

namespace DijkstraAlgorithm
{
    public class Vertex
    {
        public Guid Guid { get; }
        public string Name { get; set; }

        public Vertex()
        {
            this.Guid = Guid.NewGuid();
        }

        public Vertex(string name) : this()
        {
            this.Name = name;
        }
    }
}