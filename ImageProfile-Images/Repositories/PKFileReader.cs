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
        public PKFileReader()
        {
            //dev mode
            privateKey = readFileAsByteArray(Path.Join(Directory.GetCurrentDirectory(), "keys", "private.key"));
            publicKey = readFileAsByteArray(Path.Join(Directory.GetCurrentDirectory(), "keys", "public.key"));
        }
        public byte[] readFileAsByteArray(string fullPath)
        {
            byte[] fileData = null;
            using (FileStream fs = File.OpenRead(fullPath))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }
            return fileData;
        }
    }
}
