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
                FileHasher.Algorithm algorithm;
                try
                {
                    algorithm = (FileHasher.Algorithm)Enum.Parse(typeof(FileHasher.Algorithm), options.algorithm);
                    Console.WriteLine(FileHasher.GetHash(options.filename, algorithm));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Invalid algorithm '{options.algorithm}'");
                    Environment.Exit(1);
                }
            }
        }
    }
}
