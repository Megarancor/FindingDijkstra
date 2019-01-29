﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    public interface IDijkstraAlgorithm
    {
        Solution ShortestPath(Graph graph, Vertex source);
    }
}
