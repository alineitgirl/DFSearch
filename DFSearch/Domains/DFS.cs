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
        public List<Vertex> _dfsOrder = new();
        public DFS(Graph graph) : base(graph, "Depth First Search") { }

        public override void Execute()
        {
            //Graph.ResetVisitStatus();
            foreach(var vertex in Graph.Vertices)
            {
                if (!vertex.IsVisited)
                {
                    Visit(vertex);
                }
            }
        }
        public void Execute(Vertex startVertex)
        {
            if (startVertex == null)
            {
                throw new ArgumentNullException(nameof(startVertex), "Start vertex cannot be null.");
            }

            Graph.ResetVisitStatus();
            _dfsOrder.Clear();

            Visit(startVertex);
        }
        private void Visit(Vertex vertex)
        {
            if (vertex.IsVisited) 
                return;

            vertex.IsVisited = true;       
            _dfsOrder.Add(vertex);         

            foreach (var edge in Graph.Edges)
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
        public string GetTimeComplexity(Vertex startVertex)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100; i++) 
            {
                Execute(startVertex);
            }

            stopwatch.Stop();
            double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds ;
            return elapsedMilliseconds.ToString("F6");

        }

        public string GetTraversalOrder()
        {
            return string.Join("->", _dfsOrder.Select(vertex => vertex.Id.ToString()));
        }
    }
}
