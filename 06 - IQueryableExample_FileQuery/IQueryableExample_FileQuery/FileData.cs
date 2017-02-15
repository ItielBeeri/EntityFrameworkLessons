using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableExample_FileQuery
{
    class FileData
    {
        public string Name { get; set; }
        public string FirstLine { get; set; }
        public string LastLine { get; set; }
        public IEnumerable<string> LinesInTheMiddle { get; set; }
    }
}
