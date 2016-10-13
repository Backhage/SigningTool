using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace SigningTool
{
    public class FileHasher
    {
        private readonly string AlgorithmIdentifier;
        public enum Algorithms
        {
            MD5,
            SHA1
        }
        
        public FileHasher(Algorithms algorithm)
        {
            switch (algorithm)
            {
                case Algorithms.MD5:
                    AlgorithmIdentifier = "MD5";
                    break;
                case Algorithms.SHA1:
                    AlgorithmIdentifier = "SHA1";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetHash(string path)
        {
            byte[] hash;
            // Wrapping the file stream in a buffered stream improves performance for large files.
            using (var input = new BufferedStream(File.OpenRead(path), 1200000))
            {
                hash = HashAlgorithm.Create(AlgorithmIdentifier).ComputeHash(input);
            }
            var sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.AppendFormat("{0:X2}", b);
            }

            return sb.ToString();
        }
    }
}
