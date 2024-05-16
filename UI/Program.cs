using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileSystemManager fileSystemManager = new FileSystemManager();

                while (true)
                {
                    var input = Console.ReadLine().Split(' ');
                    string command = input[0];
                    string name = input[1];

                    switch (command)
                    {
                        case "cd":
                            fileSystemManager.ChangeDirectory(name);
                            break;

                        case "touch":
                            fileSystemManager.CreateFile(name);
                            break;

                        case "ls":
                            fileSystemManager.ListFiles();
                            break;

                        case "mkdir":
                            fileSystemManager.CreateDirectory(name);
                            break;

                        case "pwd":
                            fileSystemManager.PrintWorkingDirectory();
                            break;

                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
