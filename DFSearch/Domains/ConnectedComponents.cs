using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class ConnectedComponents : GraphAlgorithm
    {
        public List<List<Vertex>> Components { get; private set; } = new();

        public ConnectedComponents(Graph graph) : base(graph, "Connected Components") { }

        public override void Execute()
        {
            Graph.ResetVisitStatus();
            Components = new List<List<Vertex>>();

            foreach (var vertex in Graph.Vertices)
            {
                if (!vertex.IsVisited)
                {
                    var component = new List<Vertex>();
                    Explore(vertex, component);
                    Components.Add(component);
                }
            }
        }

        private void Explore(Vertex vertex, List<Vertex> component)
        {
            vertex.IsVisited = true;
            component.Add(vertex);

            foreach(var edge in Graph.Edges)
            {
                if (edge.From == vertex && !edge.To.IsVisited)
                {
                    Explore(edge.To, component);
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
