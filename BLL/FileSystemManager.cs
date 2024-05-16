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
        private Directory _rootDirectory;
        private Directory _currentDirectory;

        public FileSystemManager()
        {
            _rootDirectory.Parent = null;
            _rootDirectory = new Directory("root");
            _currentDirectory = _rootDirectory;
        }

        public void ChangeDirectory(string directoryName)
        {
            if (directoryName.Equals(".."))
            {
                if (_currentDirectory != _rootDirectory)
                {
                    _currentDirectory = _currentDirectory.Parent;
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
                }
                else
                {
                    Console.WriteLine($"Directory {directoryName} not found");
                }
            }
        }

        public void CreateFile(string fileName)
        {
            File newFile = new File(fileName);
            _currentDirectory.Files.Add(newFile);
        }

        public void ListFiles()
        {
            List<string> directoryChilds = new List<string>();
            directoryChilds = _currentDirectory.Childs.Select(c => c.Name).Union(_currentDirectory.Files.Select(f => f.Name)).ToList();
            Console.WriteLine(string.Join("\t", directoryChilds));
        }

        public void CreateDirectory(string directoryName)
        {
            Directory newDirectory = new Directory(directoryName);
            _currentDirectory.Childs.Add(newDirectory);
        }

        public void PrintWorkingDirectory()
        {
            Console.WriteLine($"{_currentDirectory.Name}");
        }
    }
}
