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
        public void Execute(Vertex startVertex)
        {
            Graph.ResetVisitStatus();
            var visitedCount = 0;

            if (startVertex == null)
            {
                startVertex = Graph.Vertices[0];
            }

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

            DFS(startVertex);

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
        public string GetAlgorithmConplexity(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0 || dataGridView.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                return (Graph.Edges.Count + Graph.Vertices.Count).ToString();

            }
            return ((int)Math.Pow(Graph.Edges.Count, 2)).ToString();
        }
        public string GetTimeComplexity(Vertex startVertex)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100; i++)
            {
                Execute(startVertex);
            }

            stopwatch.Stop();
            double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds / 100;
            return elapsedMilliseconds.ToString("F6");

        }
    }
}
