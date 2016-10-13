using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigningTool;

namespace Tests
{
    [TestClass]
    public class FileHasherTests
    {
        [TestMethod]
        public void TestMD5Hash()
        {
            var tempFile = Path.GetTempFileName();
            using (var outputFile = new StreamWriter(tempFile))
            {
                outputFile.WriteLine("Hash calculated using MD5.");
            }
            var fileHasher = new FileHasher(FileHasher.Algorithms.MD5);
            var hash = fileHasher.GetHash(tempFile);
            const string expectedHash = "41286C0D6E1CB9BA6FED0BE0CEC399FE"; // Calculated using onlinemd5.com

            Assert.AreEqual(expectedHash, hash);
        }

        [TestMethod]
        public void TestSHA1Hash()
        {
            var tempFile = Path.GetTempFileName();
            using (var outputFile = new StreamWriter(tempFile))
            {
                outputFile.WriteLine("Hash calculated using SHA1.");
            }
            var fileHasher = new FileHasher(FileHasher.Algorithms.SHA1);
            var hash = fileHasher.GetHash(tempFile);
            const string expectedHash = "C561579D37ED07ABF663F5413808EAFC7EF2C4C5";

            Assert.AreEqual(expectedHash, hash);
        }
    }
}
