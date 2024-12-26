using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFSearch.Domains
{
    public class Graph : IDrawGraph
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
            Edges.Add(new Edge(to, from));
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
        public void DrawGraph(PictureBox pictureBox, Color colorEdge, Color colorVertices)
        {

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);

            Pen edgePen = new Pen(Color.Gray, 2);
            Brush visitedBrush = new SolidBrush(colorEdge);
            Brush unvisitedBrush = new SolidBrush(colorVertices);

            // Центр PictureBox
            int centerX = pictureBox.Width / 2;
            int centerY = pictureBox.Height / 2;
            int radius = 150;

            // Позиции вершин
            var vertexPositions = new Dictionary<Vertex, Point>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                double angle = 2 * Math.PI * i / Vertices.Count;
                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));
                vertexPositions[Vertices[i]] = new Point(x, y);
            }

            // Рисуем рёбра
            foreach (var edge in Edges)
            {
                Point from = vertexPositions[edge.From];
                Point to = vertexPositions[edge.To];
                g.DrawLine(edgePen, from, to);
            }

            // Рисуем вершины
            foreach (var vertex in Vertices)
            {
                Point position = vertexPositions[vertex];
                Brush brush = vertex.IsVisited ? visitedBrush : unvisitedBrush;

                g.FillEllipse(brush, position.X - 15, position.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
                g.DrawString(vertex.Id.ToString(), Form1.DefaultFont, Brushes.Black, position.X - 5, position.Y - 5);
            }

            pictureBox.Image = bitmap;
        }
    }
}
