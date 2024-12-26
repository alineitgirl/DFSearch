using PdfSharp.Pdf;
using PdfSharp.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using System.Text;
using System.Drawing.Imaging;
using PdfSharp.Pdf.IO;

namespace DFSearch.Domains
{
    public class FileManager : IFileControl
    {
        public void SaveToFile(string fileName, string format, List<string> algorithmResults, string dateTime) 
        {
            if (File.Exists(fileName))
            {
                switch (format.ToLower())
                {
                    case "txt":
                        AppendToTextFile(fileName, algorithmResults, dateTime);
                        break;
                    case "pdf":
                        AppendToPdfFile(fileName, algorithmResults, dateTime);
                        break;
                    case "docx":
                        AppendToDocxFile(fileName, algorithmResults, dateTime);
                        break;
                    default:
                        Console.WriteLine("Unsupported format");
                        break;
                }
            }
            else
            {
                switch (format.ToLower())
                {
                    case "txt":
                        SaveToTextFile(fileName, algorithmResults, dateTime);
                        break;
                    case "pdf":
                        SaveToPdfFile(fileName, algorithmResults, dateTime);
                        break;
                    case "docx":
                        SaveToDocxFile(fileName, algorithmResults, dateTime);
                        break;
                    default:
                        Console.WriteLine("Unsupported format");
                        break;
                }
            }
        }
        private void AppendToTextFile(string fileName, List<string> algorithmResults, string dateTime)
        {
            StringBuilder content = new StringBuilder();

            content.AppendLine($"Дата и время: {dateTime}");
            content.AppendLine("\nРезультаты алгоритмов:");
            foreach (var result in algorithmResults)
            {
                content.AppendLine(result);
            }

            File.AppendAllText(fileName, content.ToString());
        }

        private void AppendToPdfFile(string fileName, List<string> algorithmResults, string dateTime)
        {
            PdfDocument pdf;
            if (File.Exists(fileName))
            {
                pdf = PdfReader.Open(fileName, PdfDocumentOpenMode.Modify);
            }
            else
            {
                pdf = new PdfDocument();
            }

            
            PdfPage page = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

           
            XFont font = new XFont("Verdana", 12, XFontStyleEx.Regular);
            XFont boldFont = new XFont("Verdana", 12, XFontStyleEx.Bold);


            double x = 40;
            double y = 40;

          
            gfx.DrawString($"Дата и время: {dateTime}", boldFont, XBrushes.Black, new XPoint(x, y));
            y += 20; 

           
            gfx.DrawString("Результаты алгоритмов:", boldFont, XBrushes.Black, new XPoint(x, y));
            y += 20;


            foreach (var result in algorithmResults)
            {
                gfx.DrawString(result, font, XBrushes.Black, new XPoint(x, y));
                y += 20;
            }

            pdf.Save(fileName);
        }
        private void AppendToDocxFile(string fileName, List<string> algorithmResults, string dateTime)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fileName, true))
            {
                Body body = wordDoc.MainDocumentPart.Document.Body;

                body.AppendChild(new Paragraph(new Run(new
                    Text($"Дата и время: {dateTime}"))));
                foreach (var result in algorithmResults)
                {
                    body.AppendChild(new Paragraph(new Run(new
                        Text(result))));
                }

                wordDoc.MainDocumentPart.Document.Save();
            }
        }


        private void SaveToTextFile(string fileName, List<string> algorithmResults, string dateTime)
        {
            StringBuilder content = new StringBuilder();

            content.AppendLine($"Дата и время: {dateTime}");

            content.AppendLine("\nРезультаты алгоритмов:");
            foreach (var result in algorithmResults)
            {
                content.AppendLine(result);
            }

            File.WriteAllText(fileName, content.ToString());
        }
        public void SaveToPdfFile(string fileName, List<string> algorithmResults, string dateTime)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Результаты алгоритмов";

            
            PdfPage page = document.AddPage();

            
            XGraphics gfx = XGraphics.FromPdfPage(page);

            
            XFont font = new XFont("Verdana", 12, XFontStyleEx.Regular);
            XFont boldFont = new XFont("Verdana", 12, XFontStyleEx.Bold);

            
            double x = 50;
            double y = 50;

           
            gfx.DrawString($"Дата и время: {dateTime}", boldFont, XBrushes.Black, new XRect(x, y, page.Width - 100, 20), XStringFormats.TopLeft);
            y += 30;

            
            gfx.DrawString("Результаты алгоритмов:", boldFont, XBrushes.Black, new XRect(x, y, page.Width - 100, 20), XStringFormats.TopLeft);
            y += 20;

            
            foreach (var result in algorithmResults)
            {
                gfx.DrawString(result, font, XBrushes.Black, new XRect(x, y, page.Width - 100, 20), XStringFormats.TopLeft);
                y += 20;

                
                if (y > page.Height - 50)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = 50;
                }
            }

            
            document.Save(fileName);
        }

        private void SaveToDocxFile(string fileName, List<string> algorithmResults, string dateTime)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(fileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());

                var body = mainPart.Document.Body;
                body.AppendChild(new Paragraph(new Run
                    (new Text($"Дата и время: {dateTime}"))));
                foreach (var result in algorithmResults)
                {
                    body.AppendChild(new Paragraph(new Run(
                        new Text(result))));
                }
            }
        }

        public void SaveGraphAsImage(string fileName, string format, Bitmap graphImage)
        {
            ImageFormat imageFormat = format.ToLower() switch
            {
                "jpg" => ImageFormat.Jpeg,
                "bmp" => ImageFormat.Bmp,
                "png" => ImageFormat.Png,
                _ => throw new ArgumentException("Unsupported image format", nameof(format))
            };

            try
            {
                graphImage.Save(fileName, imageFormat);
                Console.WriteLine($"Graph saved as {format} to {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
            }
        }

        public void LoadGraphFromFile(string filePath, Graph graph, DataGridView dataGridView)
        {
            try
            {
                // Читаем все строки из файла
                var lines = File.ReadAllLines(filePath);

                // Очищаем граф перед загрузкой
                graph.Vertices.Clear();
                graph.Edges.Clear();

                int vertexCount = lines.Length; // Количество строк определяет количество вершин

                // Создаём матрицу смежности
                int[,] adjacencyMatrix = new int[vertexCount, vertexCount];

                // Добавляем вершины в граф
                for (int i = 0; i < vertexCount; i++)
                {
                    graph.AddVertex(i);
                }

                // Заполняем граф рёбрами на основе матрицы смежности
                for (int i = 0; i < vertexCount; i++)
                {
                    var row = lines[i].Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                    if (row.Length != vertexCount)
                    {
                        throw new Exception("Матрица смежности некорректна: количество элементов в строке не соответствует количеству вершин.");
                    }

                    for (int j = 0; j < vertexCount; j++)
                    {
                        adjacencyMatrix[i, j] = row[j]; // Заполняем матрицу смежности

                        if (row[j] == 1) // Если существует ребро
                        {
                            graph.AddEdge(i, j);
                        }
                    }
                }

                // Загружаем матрицу смежности в DataGridView
                LoadMatrixToDataGridView(dataGridView, adjacencyMatrix);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке графа из файла: {ex.Message}");
            }
        }

        public void LoadMatrixToDataGridView(DataGridView dataGridView, int[,] matrix)
        {
            // Очистка DataGridView
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            int size = matrix.GetLength(0);

            // Добавляем колонки в DataGridView
            for (int i = 0; i < size; i++)
            {
                dataGridView.Columns.Add($"Col{i}", $"V{i + 1}");
            }

            // Добавляем строки в DataGridView
            for (int i = 0; i < size; i++)
            {
                var row = new DataGridViewRow();
                for (int j = 0; j < size; j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = matrix[i, j] });
                }
                dataGridView.Rows.Add(row);
            }

            // Устанавливаем названия строк (индексы вершин)
            for (int i = 0; i < size; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = $"V{i + 1}";
            }

            // Настройка стилей
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }


    }
}

