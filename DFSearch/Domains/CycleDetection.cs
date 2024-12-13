using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace DFSearch.Domains
{
    public class CycleDetection : GraphAlgorithm
    {
        public bool _hasCycle;
        private List<Vertex> _cycleVertices;
        private Stack<Vertex> _cycleStack;

        public CycleDetection(Graph graph) : base(graph, "Cycle Detection")
        {
            _cycleVertices = new List<Vertex>();
            _cycleStack = new Stack<Vertex>();  // Для отслеживания пути в поиске цикла
        }

        public override void Execute()
        {
            Graph.ResetVisitStatus();
            _hasCycle = false;
            _cycleVertices.Clear();

            foreach (var vertex in Graph.Vertices)
            {
                if (!vertex.IsVisited)
                {
                    if (DetectCycle(vertex, null))
                    {
                        break;  // Прерываем поиск, когда цикл найден
                    }
                }
            }
        }

        public void Execute(Vertex startVertex)
        {
            if (startVertex == null)
            {
                throw new ArgumentNullException(nameof(startVertex), "Start vertex cannot be null.");
            }

            Graph.ResetVisitStatus();  // Сброс статуса посещения вершин
            _hasCycle = false;
            _cycleVertices.Clear();  // Очищаем список вершин цикла

            if (DetectCycle(startVertex, null))
            {
                // Если цикл найден, завершаем выполнение
                return;
            }
        }
        private bool DetectCycle(Vertex vertex, Vertex? parent)
        {
            vertex.IsVisited = true;
            _cycleStack.Push(vertex);  // Добавляем вершину в стек для отслеживания пути

            foreach (var edge in Graph.Edges)
            {
                if (edge.From == vertex)
                {
                    if (!edge.To.IsVisited)
                    {
                        if (DetectCycle(edge.To, vertex))
                        {
                            return true;  // Цикл найден, продолжаем
                        }
                    }
                    else if (edge.To != parent)  // Находим цикл
                    {
                        _hasCycle = true;
                        // Строим цикл из вершин в стеке
                        while (_cycleStack.Peek() != edge.To)
                        {
                            _cycleVertices.Add(_cycleStack.Pop());
                        }
                        _cycleVertices.Add(edge.To);  // Добавляем конечную вершину цикла
                        return true;
                    }
                }
            }

            _cycleStack.Pop();  // Убираем вершину из стека, если она не является частью цикла
            return false;
        }

        public string GetCyclePath()
        {
            if (!_hasCycle)
            {
                return "No cycle detected.";
            }

            StringBuilder cyclePath = new StringBuilder();
            foreach (var vertex in _cycleVertices)
            {
                cyclePath.Append(vertex.Id).Append(" -> ");
            }

            cyclePath.Remove(cyclePath.Length - 4, 4);  // Убираем лишнюю стрелку в конце
            return cyclePath.ToString();
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

        public void RedrawGraph(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);

            Pen edgePen = new Pen(Color.Gray, 2);  // Цвет для обычных рёбер
            Brush visitedBrush = new SolidBrush(Color.LightBlue);
            Brush unvisitedBrush = new SolidBrush(Color.LightGray);

            Pen cycleEdgePen = new Pen(Color.Purple, 2);  // Цвет для рёбер цикла
            Brush cycleVertexBrush = new SolidBrush(Color.PowderBlue);  // Цвет для вершин цикла

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

                Pen currentEdgePen = _cycleVertices.Contains(edge.From) && _cycleVertices.Contains(edge.To) ? cycleEdgePen : edgePen;

                g.DrawLine(currentEdgePen, from, to);
            }

            // Рисуем вершины
            foreach (var vertex in Graph.Vertices)
            {
                Point position = vertexPositions[vertex];

                // Если вершина является частью цикла, рисуем её желтым
                Brush brush = _cycleVertices.Contains(vertex) ? cycleVertexBrush : (vertex.IsVisited ? visitedBrush : unvisitedBrush);

                g.FillEllipse(brush, position.X - 15, position.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, position.X - 15, position.Y - 15, 30, 30);
                g.DrawString(vertex.Id.ToString(), Form1.DefaultFont, Brushes.Black, position.X - 5, position.Y - 5);
            }

            pictureBox.Image = bitmap;
        }
    }

}
