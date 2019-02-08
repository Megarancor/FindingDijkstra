using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    public interface IDijkstraAlgorithm
    {
        Solution ShortestPaths(Graph graph, Vertex source);
    }
}
