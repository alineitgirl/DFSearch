using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class GraphConnectivity : GraphAlgorithm
    {
        public bool IsConnected { get; private set; }

        public GraphConnectivity(Graph graph) : base(graph, "Graph Connectivity") { }

        public override void Execute()
        {
            Graph.ResetVisitStatus();
            var visitedCount = 0;

            void DFS(Vertex vertex)
            {
                vertex.IsVisited = true;
                visitedCount++;

                foreach (var edge in Graph.Edges)
                {
                    if (edge.From == vertex && !edge.To.IsVisited)
                    {
                        DFS(edge.To);
                    }
                }
            }

            DFS(Graph.Vertices[0]); 
            IsConnected = visitedCount == Graph.Vertices.Count;
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
