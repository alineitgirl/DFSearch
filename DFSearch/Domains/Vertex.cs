using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class Vertex
    {
        public int Id { get; }
        public bool IsVisited { get; set; }
        public Vertex(int id) {
            Id = id;
            IsVisited = false;
        }
    }
}
