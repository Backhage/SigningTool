using CommandLine;
using CommandLine.Text;

namespace SigningTool
{
    class CommandLineOptions
    {
        [Option('a', "algorithm", Required = true, HelpText = "Algorithm to use, MD5, SHA1, or SHA256.")]
        public string algorithm { get; set; }

        [Option('f', "file", Required = true, HelpText = "File to calculate hash on.")]
        public string filename { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
