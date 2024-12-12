using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class CycleDetection : GraphAlgorithm
    {
        private bool _hasCycle;

        public CycleDetection(Graph graph) : base(graph, "Cycle Detection") { }

        public override void Execute()
        {
            Graph.ResetVisitStatus();
            _hasCycle = false;

            foreach (var vertex in Graph.Vertices)
            {
                if (!vertex.IsVisited)
                {
                    DetectCycle(vertex, null);
                }
            }
        }

        private void DetectCycle(Vertex vertex, Vertex? parent)
        {
            vertex.IsVisited = true;

            foreach (var edge in Graph.Edges)
            {
                if (edge.From == vertex)
                {
                    if (!edge.To.IsVisited)
                    {
                        DetectCycle(edge.To, vertex);
                    }
                    else if (edge.To != parent)
                    {
                        _hasCycle = true;
                    }
                }
            }
        }

        public override string GetTimeComplexity()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Execute();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds.ToString();
        }
    }
}
