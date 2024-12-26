using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class Session
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string UserName { get; set; }
        public string Actions { get; set; }
    }
}
