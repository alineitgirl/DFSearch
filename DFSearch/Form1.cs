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
                MessageBox.Show("� ����� ������ ���� ������ ����� �������!");
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
                MessageBox.Show("����� �������� ����� �����, ���������� ������ ��������� � �������� �����!");
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
                    MessageBox.Show("����� � ������ ��������� � ����� ���!");
                }
            }
            else
            {
                MessageBox.Show("����� ������� �����, ���������� ������ ��������� � �������� �������!");
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
            // ������� ������ Graphics ��� ��������� � PictureBox
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);

            // ������� PictureBox ����� ����������
            g.Clear(Color.White);

            Pen edgePen = new Pen(Color.SkyBlue, 2); // и��� - ������� ����
            Brush vertexBrush = new SolidBrush(Color.LightGray); // ������� - ������-����� ����

            // ���������� ��������� ��� ������
            int radius = 100;  // ������ �����, �� �������� ����� ����������� �������
            int centerX = pictureBox.Width / 2;
            int centerY = pictureBox.Height / 2;

            // ������ ����
            foreach (var edge in graph.Edges)
            {
                // ������ ��������� ������
                var vertexFrom = CalculateVertexPosition(edge.From, pictureBox);
                var vertexTo = CalculateVertexPosition(edge.To, pictureBox);
                g.DrawLine(edgePen, vertexFrom.X, vertexFrom.Y, vertexTo.X, vertexTo.Y);
            }

            // ������ �������
            foreach (var vertex in graph.Vertices)
            {
                // ������ ��������� ��� ������ �������
                var position = CalculateVertexPosition(vertex, pictureBox);
                g.FillEllipse(vertexBrush, position.X - 15, position.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Gray, position.X - 15, position.Y - 15, 30, 30); // ������� ����� ������
                g.DrawString(vertex.Id.ToString(), this.Font, Brushes.Black, position.X - 5, position.Y - 5);
            }

            // ������������� ����������� � PictureBox
            pictureBox.Image = bitmap;
        }

        // ������� ��� ���������� ��������� ������� � ����������� �� � �������
        private Point CalculateVertexPosition(Vertex vertex, PictureBox pictureBox)
        {
            // ���������� ������
            int totalVertices = graph.Vertices.Count;

            // ���������� ���� ��� ������� �������
            double angle = 2 * Math.PI * graph.Vertices.IndexOf(vertex) / totalVertices;

            // ����� PictureBox
            int centerX = pictureBox.Width / 2;
            int centerY = pictureBox.Height / 2;

            // ������ ����������, �� ������� ����� ��������� �������
            int radius = 150;

            // ���������� ��������� �������
            int x = (int)(centerX + radius * Math.Cos(angle));
            int y = (int)(centerY + radius * Math.Sin(angle));

            return new Point(x, y);
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
