using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class Graph
    {
        public List<Vertex> Vertices { get; } = new();
        public List<Edge> Edges { get; } = new();

        public void AddVertex(int id)
        {
            if (Vertices.Exists(v => v.Id == id)) return;
            Vertices.Add(new Vertex(id));
        }

        public void AddEdge(int fromId, int toId)
        {
            var from = Vertices.Find(v => v.Id == fromId);
            var to = Vertices.Find(v => v.Id == toId);

            if (from == null || to == null) throw new Exception("Должны быть 2 вершины для существования!");
            Edges.Add(new Edge(from, to));
        }

        public void RemoveVertex(int id)
        {
            var vertex = Vertices.Find(v => v.Id == id);
            if (vertex != null)
            {
                Vertices.Remove(vertex);
                Edges.RemoveAll(e => e.From == vertex || e.To == vertex);
            } 
        }

        public void RemoveEdge(int fromId, int toId)
        {
            Edges.RemoveAll(e => e.From.Id == fromId && e.To.Id == toId);
        }
        public void ResetVisitStatus()
        {
            foreach (var v in Vertices)
            {
                v.IsVisited = false;
            }
        }
    }
}
