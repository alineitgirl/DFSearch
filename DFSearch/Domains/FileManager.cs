using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class FileManager
    {
        public void SaveToFile(string algorithmName, string result)
        {
            var fileName = $"Result_{algorithmName}_{DateTime.Now:yyyyMMddHHmmss}.txt";
            File.WriteAllText(fileName, $"Algorithm: {algorithmName}\nResult: {result}\nDate: {DateTime.Now}");
        }

        public void OpenFile(string filePath)
        {

        }
    }
}
