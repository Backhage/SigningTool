using System;
using System.IO;
namespace SigningTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (!File.Exists(options.filename))
                {
                    Console.WriteLine($"File not found '{options.filename}'");
                    Environment.Exit(1);
                }
                var hash = "";
                if (options.algorithm.Equals("MD5"))
                {
                    hash = FileHasher.GetHash(options.filename, FileHasher.Algorithm.MD5);
                }
                else if (options.algorithm.Equals("SHA1"))
                {
                    hash = FileHasher.GetHash(options.filename, FileHasher.Algorithm.SHA1);
                }
                else
                {
                    Console.WriteLine(options.GetUsage());
                    Environment.Exit(1);
                }
                Console.WriteLine(hash);
            }
        }
    }
}
