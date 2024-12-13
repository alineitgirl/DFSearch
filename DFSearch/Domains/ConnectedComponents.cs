using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFSearch.Domains
{
    public class ConnectedComponents : GraphAlgorithm
    {
        public List<List<Vertex>> Components { get; private set; } = new();

        public ConnectedComponents(Graph graph) : base(graph, "Connected Components") { }

        // Метод для поиска всех компонент связности
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

        // Метод для поиска компонент с определённой стартовой вершины
        public void Execute(Vertex startVertex)
        {
            if (startVertex == null)
                throw new ArgumentNullException(nameof(startVertex), "Start vertex cannot be null.");

            Graph.ResetVisitStatus();
            Components = new List<List<Vertex>>();

            var component = new List<Vertex>();
            Explore(startVertex, component);
            Components.Add(component);
        }

        // Обход в глубину для поиска компоненты связности
        private void Explore(Vertex vertex, List<Vertex> component)
        {
            vertex.IsVisited = true;
            component.Add(vertex);

            foreach (var edge in Graph.Edges)
            {
                if (edge.From == vertex && !edge.To.IsVisited)
                {
                    Explore(edge.To, component);
                }
                else if (edge.To == vertex && !edge.From.IsVisited)
                {
                    Explore(edge.From, component);
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
            double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds / 100;
            return elapsedMilliseconds.ToString("F6");
        }

        // Метод для рисования графа с компонентами связности
        public void RedrawGraph(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);

            Pen edgePen = new Pen(Color.Blue, 2);  // Рёбра будут синими
            Brush visitedBrush = new SolidBrush(Color.Lavender);  // Вершины будут лавандовыми
            Brush unvisitedBrush = new SolidBrush(Color.LightGray);  // Невизитированные вершины

            // Центр PictureBox
            int centerX = pictureBox.Width / 2;
            int centerY = pictureBox.Height / 2;
            int radius = 150;

            // Позиции вершин
            var vertexPositions = new Dictionary<Vertex, Point>();
            for (int i = 0; i < Graph.Vertices.Count; i++)
            {
                double angle = 2 * Math.PI * i / Graph.Vertices.Count;
                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));
                vertexPositions[Graph.Vertices[i]] = new Point(x, y);
            }

            // Рисуем рёбра
            foreach (var edge in Graph.Edges)
            {
                Point from = vertexPositions[edge.From];
                Point to = vertexPositions[edge.To];

                // Рисуем ребра синими
                g.DrawLine(edgePen, from, to);
            }

            // Рисуем вершины
            foreach (var vertex in Graph.Vertices)
            {
                Point position = vertexPositions[vertex];

                // Рисуем вершины лавандовыми
                Brush brush = vertex.IsVisited ? visitedBrush : unvisitedBrush;

                g.FillEllipse(brush, position.X - 15, position.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
                g.DrawString(vertex.Id.ToString(), Form1.DefaultFont, Brushes.Black, position.X - 5, position.Y - 5);
            }

            pictureBox.Image = bitmap;
        }

        public string GetComponentsAsString()
        {
            // Если нет компонентов
            if (Components.Count == 0)
            {
                return "No connected components.";
            }

            // Создаём StringBuilder для хранения результата
            StringBuilder result = new StringBuilder();

            // Для каждой компоненты
            foreach (var component in Components)
            {
                // Преобразуем список вершин компоненты в строку с разделителем " -> "
                result.Append(string.Join(" -> ", component.Select(v => v.Id.ToString())));

                // Добавляем перенос строки после каждой компоненты
                result.AppendLine();
            }

            return result.ToString();
        }

    }
}
