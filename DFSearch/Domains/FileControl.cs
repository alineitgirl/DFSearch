using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public interface IFileControl
    {
        void SaveToFile(string fileName, string format, List<string> algorithmResults, string dateTime);
        void LoadGraphFromFile(string filePath, Graph graph, DataGridView dataGridView);
    }
}
