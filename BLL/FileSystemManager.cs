using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FileSystemManager
    {
        private Stack<string> _path;
        private Directory _rootDirectory;
        private Directory _currentDirectory;

        public FileSystemManager()
        {
            _path = new Stack<string>();
            _rootDirectory = new Directory("root");
            _rootDirectory.Parent = null;
            _currentDirectory = _rootDirectory;
            _path.Push(_rootDirectory.Name);
        }

        public void ChangeDirectory(string directoryName)
        {
            if (directoryName.Equals(".."))
            {
                if (_currentDirectory != _rootDirectory)
                {
                    _currentDirectory = _currentDirectory.Parent;
                    _path.Pop();
                }
                else
                {
                    Console.WriteLine("You are already in the root directory");
                }
            }
            else
            {
                Directory newDirectory = _currentDirectory.Childs.FirstOrDefault(child => child.Name.Equals(directoryName));
                if (newDirectory != null)
                {
                    _currentDirectory = newDirectory;
                    _path.Push($"\\{_currentDirectory.Name}");
                }
                else
                {
                    Console.WriteLine($"Directory {directoryName} not found");
                }
            }
        }

        public void CreateFile(string fileName)
        {
            if (_currentDirectory.GetType() == typeof(Directory))
            {
                _currentDirectory.Files.Add(new File(fileName));
            }
            else
            {
                Console.WriteLine($"Files can't be created in files");
            }
        }

        public void ListChilds()
        {
            List<string> directoryChilds = new List<string>();
            directoryChilds = _currentDirectory.Childs.Select(c => c.Name).Union(_currentDirectory.Files.Select(f => f.Name)).ToList();
            Console.WriteLine(string.Join("\t", directoryChilds));
        }

        public void CreateDirectory(string directoryName)
        {
            if (_currentDirectory.GetType() == typeof(Directory))
            {
                Directory newDirectory = new Directory(directoryName);
                _currentDirectory.Childs.Add(newDirectory);
            }
            else
            {
                Console.WriteLine($"Directories can't be created in files");
            }
        }

        public void PrintWorkingDirectory()
        {
            Console.Write($"{string.Join("", _path.Reverse())}> ");
        }

        public string GetCurrentPath()
        {
            string currentPath = string.Join("", _path.Reverse());
            return currentPath;
        }
    }
}
