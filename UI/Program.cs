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
                fileSystemManager.PrintWorkingDirectory();

                while (true)
                {
                    var input = Console.ReadLine().Split(' ');
                    string command = input[0];
                    string name = input[1];

                    switch (command)
                    {
                        case "cd":
                            if (input.Length < 2)
                            {
                                Console.WriteLine("The entered directory is invalid, please use: cd <directory>");
                            }
                            else
                            {
                                fileSystemManager.ChangeDirectory(name);
                            }
                            break;

                        case "touch":
                            if (input.Length < 2)
                            {
                                Console.WriteLine("The entered file is invalid, please use: touch <file>");
                            }
                            else
                            {
                                fileSystemManager.CreateFile(name);
                            }
                            break;

                        case "ls":
                            fileSystemManager.ListChilds();
                            break;

                        case "mkdir":
                            if (input.Length < 2)
                            {
                                Console.WriteLine("The entered directory is invalid, please use: mkdir <directory>");
                            }
                            else
                            {
                                fileSystemManager.CreateDirectory(name);
                            }
                            break;

                        case "pwd":
                            Console.WriteLine($"The current path is '{fileSystemManager.GetCurrentPath()}'");
                            break;

                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                    fileSystemManager.PrintWorkingDirectory();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
