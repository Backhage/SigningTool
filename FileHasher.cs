using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace SigningTool
{
    public class FileHasher
    {
        public enum Algorithm
        {
            MD5,
            SHA1,
            SHA256
        }
        
        public static string GetHash(string path, Algorithm algorithm)
        {
            byte[] hash;
            // Wrapping the file stream in a buffered stream improves performance for large files.
            using (var input = new BufferedStream(File.OpenRead(path), 1200000))
            {
                hash = HashAlgorithm.Create(algorithm.ToString()).ComputeHash(input);
            }
            var sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
