using DFSearch.Domains;
using System.Windows.Forms;

namespace DFSearch
{
    public partial class Form1 : Form
    {
        Graph graph = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("У графа должно быть больше одной вершины!");
            }
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                graph.AddVertex(int.Parse(textBox2.Text));
                graph.AddVertex(int.Parse(textBox3.Text));
                graph.AddEdge(int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                RedrawGraph(pictureBox1);
            }
            else
            {
                MessageBox.Show("Чтобы добавить новое ребро, необходимо ввести начальную и конечную точку!");
            }
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                if (graph.Edges.Exists(e => e.From.Id == int.Parse(textBox4.Text) && e.To.Id == int.Parse(textBox5.Text)) ||
                    graph.Edges.Exists(e => e.To.Id == int.Parse(textBox4.Text) && e.From.Id == int.Parse(textBox5.Text)))
                {
                    graph.RemoveEdge(int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                    RedrawGraph(pictureBox1);
                }
                else
                {
                    MessageBox.Show("Ребра с такими вершинами в графе нет!");
                }
            }
            else
            {
                MessageBox.Show("Чтобы удалить ребро, необходимо ввести начальную и конечную вершину!");
            }
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RedrawGraph(pictureBox1);
        }
        private void RedrawGraph(PictureBox pictureBox)
        {
            // Создаем объект Graphics для рисования в PictureBox
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);

            // Очищаем PictureBox перед рисованием
            g.Clear(Color.White);

            Pen edgePen = new Pen(Color.SkyBlue, 2); // Рёбра - голубой цвет
            Brush vertexBrush = new SolidBrush(Color.LightGray); // Вершины - светло-серый цвет

            // Вычисление координат для вершин
            int radius = 100;  // Радиус круга, по которому будут расположены вершины
            int centerX = pictureBox.Width / 2;
            int centerY = pictureBox.Height / 2;

            // Рисуем рёбра
            foreach (var edge in graph.Edges)
            {
                // Расчет координат вершин
                var vertexFrom = CalculateVertexPosition(edge.From, pictureBox);
                var vertexTo = CalculateVertexPosition(edge.To, pictureBox);
                g.DrawLine(edgePen, vertexFrom.X, vertexFrom.Y, vertexTo.X, vertexTo.Y);
            }

            // Рисуем вершины
            foreach (var vertex in graph.Vertices)
            {
                // Расчет координат для каждой вершины
                var position = CalculateVertexPosition(vertex, pictureBox);
                g.FillEllipse(vertexBrush, position.X - 15, position.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Gray, position.X - 15, position.Y - 15, 30, 30); // Обводка серым цветом
                g.DrawString(vertex.Id.ToString(), this.Font, Brushes.Black, position.X - 5, position.Y - 5);
            }

            // Устанавливаем изображение в PictureBox
            pictureBox.Image = bitmap;
        }

        // Функция для вычисления координат вершины в зависимости от её позиции
        private Point CalculateVertexPosition(Vertex vertex, PictureBox pictureBox)
        {
            // Количество вершин
            int totalVertices = graph.Vertices.Count;

            // Вычисление угла для текущей вершины
            double angle = 2 * Math.PI * graph.Vertices.IndexOf(vertex) / totalVertices;

            // Центр PictureBox
            int centerX = pictureBox.Width / 2;
            int centerY = pictureBox.Height / 2;

            // Радиус окружности, по которой будут размещены вершины
            int radius = 150;

            // Вычисление координат вершины
            int x = (int)(centerX + radius * Math.Cos(angle));
            int y = (int)(centerY + radius * Math.Sin(angle));

            return new Point(x, y);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
