using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageProfile_Images.Repositories
{
    public class PKFileReader
    {
        public byte[] privateKey = new byte[] { };
        public byte[] publicKey = new byte[] { };
        public PKFileReader(string startingDirectory = "")
        {
            if (startingDirectory == "") startingDirectory = Directory.GetCurrentDirectory();
            //dev mode
            privateKey = readFileAsByteArray(Path.Join(startingDirectory, "keys", "privatekey.pem"));
            publicKey = readFileAsByteArray(Path.Join(startingDirectory, "keys", "publickey.pem"));
        }
        //public byte[] readFileAsByteArray(string fullPath)
        //{
        //    byte[] fileData = null;
        //    using (FileStream fs = File.OpenRead(fullPath))
        //    {
        //        using (BinaryReader binaryReader = new BinaryReader(fs))
        //        {
        //            fileData = binaryReader.ReadBytes((int)fs.Length);
        //        }
        //    }
        //    return fileData;
        //}
        private static byte[] readFileAsByteArray(string keyFile)
        {
            // remove these lines
            // -----BEGIN RSA PRIVATE KEY-----
            // -----END RSA PRIVATE KEY-----
            var pemFileData = File.ReadAllLines(keyFile).Where(x => !x.StartsWith("-"));

            // Join it all together, convert from base64
            var binaryEncoding = Convert.FromBase64String(string.Join(null, pemFileData));

            // this is the private key byte data
            return binaryEncoding;
        }
    }
}
