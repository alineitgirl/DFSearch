using PdfSharp.Pdf;
using PdfSharp.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using System.Text;
using System.Drawing.Imaging;
using PdfSharp.Pdf.IO;

namespace DFSearch.Domains
{
    public class FileManager
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

        public void LoadGraphFromFile(string filePath, Graph graph)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);

                graph.Vertices.Clear();
                graph.Edges.Clear();

                bool isVerticesSection = true;

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (line.StartsWith("#"))
                    {
                        isVerticesSection = line.Trim() == "#Vertices";
                        continue;
                    }

                    if (isVerticesSection)
                    {
                        var vertexIds = line.Split(',').Select(int.Parse);
                        foreach (var id in vertexIds)
                        {
                            graph.AddVertex(id);
                        }
                    }
                    else
                    {
                        var edgeData = line.Split(',').Select(int.Parse).ToArray();
                        int fromId = edgeData[0];
                        int toId = edgeData[1];

                        Vertex from = graph.Vertices.First(v => v.Id == fromId);
                        Vertex to = graph.Vertices.First(v => v.Id == toId);

                        graph.AddEdge(from.Id, to.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке графа из файла: {ex.Message}");
            }
        }

    }
}

