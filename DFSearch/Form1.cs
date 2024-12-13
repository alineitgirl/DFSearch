using DFSearch.Domains;
using System.Windows.Forms;

namespace DFSearch
{
    public partial class Form1 : Form
    {
        Graph graph = new Graph();
        DFS _dfs;
        GraphConnectivity _connectivity;
        CycleDetection _cycleDetection;
        ConnectedComponents _connectedComponents;
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
                if (graph.Edges.Exists(e => e.From.Id == int.Parse(textBox5.Text) && e.To.Id == int.Parse(textBox4.Text)) ||
                    graph.Edges.Exists(e => e.To.Id == int.Parse(textBox5.Text) && e.From.Id == int.Parse(textBox4.Text)))
                {
                    graph.RemoveEdge(int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                    graph.RemoveEdge(int.Parse(textBox5.Text), int.Parse(textBox4.Text));
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("�� ������ �������� ��� �����!", "������");
            }
            else
            {
                pictureBox2.Image = null;
                label3.Text = "��������� ��������� �� �������: ";
                label5.Text = "������� ������ ������: ";
                foreach (var vertex in graph.Vertices)
                    vertex.IsVisited = false;
                switch (comboBox1.Text)
                {
                    case "����� � �������":
                        _dfs = new DFS(graph);
                        _dfs._dfsOrder.Clear();
                        _dfs.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        label3.Text += _dfs.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "��";
                        _dfs.Execute();
                        graph.RedrawGraph(pictureBox2);
                        label5.Text += $"{_dfs.GetTraversalOrder()}";
                        break;
                    case "����������� ��������� �����":
                        _connectivity = new GraphConnectivity(graph);
                        _connectivity.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        graph.RedrawGraph(pictureBox2);
                        label3.Text += _connectivity.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "��";
                        label5.Text = _connectivity.IsConnected ? "������ ���� �������." : "������ ���� ���������.";
                        break;
                    case "����� ������":
                        _cycleDetection = new CycleDetection(graph);
                        _cycleDetection.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        label3.Text += _cycleDetection.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "��";
                        _cycleDetection.Execute();
                        _cycleDetection.RedrawGraph(pictureBox2);
                        label5.Text = _cycleDetection._hasCycle ? $"������ ���� �������� ����: {_cycleDetection.GetCyclePath()}." : "������ ���� �� �������� ������.";
                        break;
                    case "���������� ���������":
                        _connectedComponents = new ConnectedComponents(graph);
                        _connectedComponents.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        label3.Text += _connectedComponents.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "��";
                        _connectedComponents.Execute();
                        _connectedComponents.RedrawGraph(pictureBox2);
                        label5.Text += _connectedComponents.GetComponentsAsString();
                        break;
                }
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            comboBox1.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            numericUpDown1.Value = 1;
            label3.Text = "��������� ��������� �� �������: ";
            label5.Text = "������� ������ ������: ";
            graph = new Graph();
        }

        private void �����ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileManager = new FileManager();


            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|PDF Files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx";
                saveFileDialog.DefaultExt = "txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string fileName = saveFileDialog.FileName;

                    string selectedFormat = Path.GetExtension(fileName)?.TrimStart('.').ToLower();

                    if (selectedFormat != "txt" && selectedFormat != "pdf" && selectedFormat != "docx")
                    {
                        MessageBox.Show("������ ���������������� ������ �����!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    List<string> algorithmResults = new List<string>
            {
                        $"�������� ���������: {comboBox1.Text}",
                        label3.Text,
                        label5.Text
            };

                    string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    try
                    {
                        fileManager.SaveToFile(fileName, selectedFormat, algorithmResults, dateTime);
                        MessageBox.Show($"���� ������� ��������: {fileName}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� ���������� �����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                    dialog.Title = "Save Graph as Image";
                    dialog.DefaultExt = "png";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {

                        string format = Path.GetExtension(dialog.FileName).TrimStart('.').ToLower();

                        Bitmap graphImage = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                        using (Graphics g = Graphics.FromImage(graphImage))
                        {
                            pictureBox2.DrawToBitmap(graphImage, new Rectangle(0, 0, graphImage.Width, graphImage.Height));
                        }


                        FileManager fileManager = new FileManager();
                        fileManager.SaveGraphAsImage(dialog.FileName, format, graphImage);
                        MessageBox.Show($"���� ������� ��������: {dialog.FileName}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� �����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Text Files|*.txt";
                    dialog.Title = "Load Graph from File";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = dialog.FileName;


                        graph = new Graph();
                        FileManager fileManager = new FileManager();
                        fileManager.LoadGraphFromFile(filePath, graph);


                        graph.RedrawGraph(pictureBox1);

                        MessageBox.Show("���� ������� ��������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formHelp = new FormHelp();
            formHelp.ShowDialog();
        }

        private void ��������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSupport = new FormSupport();
            formSupport.ShowDialog();
        }
    }
}
