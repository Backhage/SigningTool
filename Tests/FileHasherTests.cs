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
            VerifyHash("Hash calculated using MD5.", FileHasher.Algorithm.MD5, "41286C0D6E1CB9BA6FED0BE0CEC399FE");
        }

        [TestMethod]
        public void TestSHA1Hash()
        {
            VerifyHash("Hash calculated using SHA1.", FileHasher.Algorithm.SHA1, "C561579D37ED07ABF663F5413808EAFC7EF2C4C5");
        }

        [TestMethod]
        public void TestSHA256Hash()
        {
            VerifyHash("Hash calculated using SHA256.", FileHasher.Algorithm.SHA256, "84821BCC54BF7F03711EA9185956714262C22062D4717255E031B0F424FF80C8");
        }

        private void VerifyHash(string fileContent, FileHasher.Algorithm algorithm, string expectedHash)
        {
            var tempFile = Path.GetTempFileName();
            using (var outputFile = new StreamWriter(tempFile))
            {
                outputFile.WriteLine(fileContent);
            }
            var hash = FileHasher.GetHash(tempFile, algorithm);
            File.Delete(tempFile);

            Assert.AreEqual(expectedHash, hash);
        }
    }
}
