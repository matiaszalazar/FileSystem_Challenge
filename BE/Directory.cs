using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Directory
    {
        public Directory() { }

        public Directory(string name)
        {
            Name = name;
            Files = new List<File>();
            Childs = new List<Directory>();
        }

        public string Name { get; }
        public Directory Parent { get; set; }
        public List<File> Files { get; }
        public List<Directory> Childs { get; }
    }
}
