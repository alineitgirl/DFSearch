using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class DFS : GraphAlgorithm
    {
        public DFS(Graph graph) : base(graph, "Depth First Search") { }

        public override void Execute()
        {
            Graph.ResetVisitStatus();
            foreach(var vertex in Graph.Vertices)
            {
                if (!vertex.IsVisited)
                {
                    Visit(vertex);
                }
            }
        }
        
        private void Visit(Vertex vertex)
        {
            vertex.IsVisited = true;
            foreach(var edge in Graph.Edges)
            {
                if (edge.From == vertex && !edge.To.IsVisited)
                {
                    Visit(edge.To);
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
