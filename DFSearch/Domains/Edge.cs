using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class Edge
    {
        public Vertex From { get; }
        public Vertex To { get; }
        public Edge(Vertex from, Vertex to) 
        {
            From = from;
            To = to; 
        }
    }
}
