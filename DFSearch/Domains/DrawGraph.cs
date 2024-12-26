using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public interface IDrawGraph
    {
        void DrawGraph(PictureBox pictureBox, Color colorEdge, Color colorVertices);
    }
}
