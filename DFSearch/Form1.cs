using DFSearch.Domains;
using DocumentFormat.OpenXml.Drawing;
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
        SessionHistory sessionHistory = new SessionHistory();

        private System.Drawing.Point _graphPosition = new System.Drawing.Point(50, 50); 
        private bool _isDragging = false;
        private System.Drawing.Point _lastMousePos;
        public Form1()
        {
            InitializeComponent();
            sessionHistory.LoadSessionHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("У графа должно быть больше одной вершины!");
                textBox1.Clear();
            }
            if (int.TryParse(textBox1.Text, out int vertexCount) && vertexCount > 0)
            {

                graph = new Graph();


                for (int i = 0; i < vertexCount; i++)
                {
                    graph.AddVertex(i);
                }


                graph.DrawGraph(pictureBox1, Color.DeepSkyBlue, Color.LightGreen);


                MessageBox.Show($"Количество вершин задано: {vertexCount}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Введите корректное количество вершин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                graph.AddVertex(int.Parse(textBox2.Text));
                graph.AddVertex(int.Parse(textBox3.Text));
                graph.AddEdge(int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                graph.DrawGraph(pictureBox1, Color.DeepSkyBlue, Color.LightGreen);
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
                if (graph.Edges.Exists(e => e.From.Id == int.Parse(textBox5.Text) && e.To.Id == int.Parse(textBox4.Text)) ||
                    graph.Edges.Exists(e => e.To.Id == int.Parse(textBox5.Text) && e.From.Id == int.Parse(textBox4.Text)))
                {
                    graph.RemoveEdge(int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                    graph.RemoveEdge(int.Parse(textBox5.Text), int.Parse(textBox4.Text));
                    graph.DrawGraph(pictureBox1, Color.DeepSkyBlue, Color.LightGreen);
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
            if (graph.Vertices.Count == 0 && graph.Edges.Count == 0)
            {
                MessageBox.Show($"Ошибка: Граф не загружен в систему!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                graph.DrawGraph(pictureBox1, Color.DeepSkyBlue, Color.LightGreen);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Не выбран алгоритм для графа!", "Ошибка");
            }
            else
            {
                pictureBox2.Image = null;
                label3.Text = "Сложность алгоритма по времени: ";
                label5.Text = "Порядок обхода вершин: ";
                foreach (var vertex in graph.Vertices)
                    vertex.IsVisited = false;
                switch (comboBox1.Text)
                {
                    case "Поиск в глубину":
                        _dfs = new DFS(graph);
                        _dfs._dfsOrder.Clear();
                        _dfs.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        label3.Text += _dfs.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "мс";
                        label4.Text += _dfs.GetAlgorithmConplexity(dataGridView1);
                        _dfs.Execute();
                        graph.DrawGraph(pictureBox2, Color.Aquamarine, Color.Azure);
                        label5.Text += $"{_dfs.GetTraversalOrder()}";
                        break;
                    case "Определение связности графа":
                        _connectivity = new GraphConnectivity(graph);
                        _connectivity.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        graph.DrawGraph(pictureBox2, Color.Aquamarine, Color.Azure);
                        label3.Text += _connectivity.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "мс";
                        label4.Text += _connectivity.GetAlgorithmConplexity(dataGridView1);
                        label5.Text = _connectivity.IsConnected ? "Данный граф связный." : "Данный граф НЕсвязный.";
                        break;
                    case "Поиск циклов":
                        _cycleDetection = new CycleDetection(graph);
                        _cycleDetection.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        label3.Text += _cycleDetection.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "мс";
                        label4.Text += _cycleDetection.GetAlgorithmConplexity(dataGridView1);
                        _cycleDetection.Execute();
                        _cycleDetection.RedrawGraph(pictureBox2);
                        label5.Text = _cycleDetection._hasCycle ? $"Данный граф содержит цикл: {_cycleDetection.GetCyclePath()}." : "Данный граф НЕ содержит циклов.";
                        break;
                    case "Компоненты связности":
                        _connectedComponents = new ConnectedComponents(graph);
                        _connectedComponents.Execute(graph.Vertices[(int)numericUpDown1.Value - 1]);
                        label3.Text += _connectedComponents.GetTimeComplexity(graph.Vertices[(int)numericUpDown1.Value - 1]) + "мс";
                        label4.Text += _connectedComponents.GetAlgorithmConplexity(dataGridView1);
                        _connectedComponents.Execute();
                        _connectedComponents.RedrawGraph(pictureBox2);
                        label5.Text += _connectedComponents.GetComponentsAsString();
                        break;
                    default:
                        MessageBox.Show("Данный алгоритм нельзя выбрать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
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
            dataGridView1.Rows.Clear();
            label3.Text = "Время выполнения программы: ";
            label4.Text = "Сложность алгоритма по времени: ";
            label5.Text = "Порядок обхода вершин: ";
            graph = new Graph();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileManager = new FileManager();


            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|PDF Files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx";
                saveFileDialog.DefaultExt = "txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string fileName = saveFileDialog.FileName;

                    string selectedFormat = System.IO.Path.GetExtension(fileName)?.TrimStart('.').ToLower();

                    if (selectedFormat != "txt" && selectedFormat != "pdf" && selectedFormat != "docx")
                    {
                        MessageBox.Show("Выбран неподдерживаемый формат файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    List<string> algorithmResults = new List<string>
            {
                        $"Название алгоритма: {comboBox1.Text}",
                        label3.Text,
                        label5.Text
            };

                    string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    try
                    {
                        fileManager.SaveToFile(fileName, selectedFormat, algorithmResults, dateTime);
                        MessageBox.Show($"Файл успешно сохранен: {fileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void изображениеToolStripMenuItem_Click(object sender, EventArgs e)
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

                        string format = System.IO.Path.GetExtension(dialog.FileName).TrimStart('.').ToLower();

                        Bitmap graphImage = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                        using (Graphics g = Graphics.FromImage(graphImage))
                        {
                            pictureBox2.DrawToBitmap(graphImage, new System.Drawing.Rectangle(0, 0, graphImage.Width, graphImage.Height));
                        }


                        FileManager fileManager = new FileManager();
                        fileManager.SaveGraphAsImage(dialog.FileName, format, graphImage);
                        MessageBox.Show($"Граф успешно сохранен: {dialog.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении графа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
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
                        fileManager.LoadGraphFromFile(filePath, graph, dataGridView1);


                        graph.DrawGraph(pictureBox1, Color.Aquamarine, Color.Azure);

                        MessageBox.Show("Граф успешно загружен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void просмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formHelp = new FormHelp();
            formHelp.ShowDialog();
        }

        private void техническаяПоддержкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSupport = new FormSupport();
            formSupport.ShowDialog();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutTextFromControls(this.Controls);
        }
        private void CutTextFromControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox && textBox.SelectedText.Length > 0)
                {
                    Clipboard.SetText(textBox.SelectedText);
                    textBox.SelectedText = string.Empty; 
                    return; 
                }
                else if (control is RichTextBox richTextBox && richTextBox.SelectedText.Length > 0)
                {
                    Clipboard.SetText(richTextBox.SelectedText); 
                    richTextBox.SelectedText = string.Empty; 
                    return;
                }
                
                if (control.HasChildren)
                {
                    CutTextFromControls(control.Controls);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                int dx = e.X - _lastMousePos.X;
                int dy = e.Y - _lastMousePos.Y;
                _graphPosition.X += dx;
                _graphPosition.Y += dy;
                _lastMousePos = e.Location;

                graph.DrawGraph(pictureBox1, Color.DeepSkyBlue, Color.LightGreen);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePos = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sessionHistory.StartNewSession("User1");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sessionHistory.EndCurrentSession();
            sessionHistory.SaveSessionHistory();
        }

        private void историяСессийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var historyForm = new HistoryForm(sessionHistory.sessionHistory); 
            historyForm.ShowDialog();
        }
    }
}
