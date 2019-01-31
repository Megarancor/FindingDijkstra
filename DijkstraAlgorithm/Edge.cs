namespace DijkstraAlgorithm
{
    public class Edge
    {
        public Vertex Vertex1 { get; }
        public Vertex Vertex2 { get; }
        public int Weight { get; }

        public Edge(Vertex v1, Vertex v2, int weight)
        {
            this.Vertex1 = v1;
            this.Vertex2 = v2;
            this.Weight = weight;
        }
    }
}