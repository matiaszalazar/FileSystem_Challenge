using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class File
    {
        public File() { }

        public File(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
