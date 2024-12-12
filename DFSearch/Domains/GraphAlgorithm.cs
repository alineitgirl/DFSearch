using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public abstract class GraphAlgorithm
    {
        public Graph Graph { get; }
        public string AlgorithmName { get; protected set; }

        protected GraphAlgorithm(Graph graph, string algorithmName)
        {
            Graph = graph;
            AlgorithmName = algorithmName;
        }

        public abstract void Execute();
        public abstract string GetTimeComplexity();
    }
}
