using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace FileUploaderUsingCurl
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            WebClient wc = new WebClient();
            /*/
            string check = wc.DownloadString("ENTER-URL-HERE"); //File to remotely shutdown application if needed
            if (check == "1")
            {
                Console.WriteLine("App Is Shutdown");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            /*/
            {
                string username = ""; //Do Not Use ROOT
                string password = ""; //You should server side this string.
                string port = "";
                string ip = ""; //Server IP of where the file shall be uploadedd to.

                long length = new FileInfo(path).Length;
                double megabytes1 = ConvertBytesToMegabytes(length);
                Console.WriteLine("Selected File = " + path);
                Console.WriteLine("File Size = " + megabytes1);
                Console.WriteLine("Press Any Key To Continue.");
                Console.ReadKey();
                if (megabytes1 > 500) //<< Checks file size to see if it reaches over a certain size.
                {
                    Console.WriteLine("File Is Larger Than 500 Megabytes!");
                    Console.WriteLine("Press Any Key To Exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Are You Sure You Would Like To Upload (y/n) - " + path + "?");
                    string input = Console.ReadLine();
                    if (input == "y")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Attempting To Upload...");
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = "curl.exe";
                        startInfo.Arguments = $"-T \"{path}\" ftp://{ip}:{port} --user {username}:{password}";
                        process.StartInfo = startInfo;
                        process.Start();
                        Console.WriteLine("File Upload Request Was Sent Check To Make Sure It Was.");
                    }
                    else if (input == "n")
                    {
                        Console.WriteLine("File Was Selected To Not Be Uploaded");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("You Inputed A Invalid Option!");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                Console.ReadLine();
            }
        }
        static double ConvertBytesToMegabytes(long bytes)
        {
            return bytes / 1024f / 1024f;
        }
    }
}
