using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProfile_Images.Constants
{
    public class UserConstants
    {
        public readonly Random random = new Random();
        public readonly IEnumerable<string> repeatedAllAsciiChars = Enumerable.Repeat("!\"#$%&\\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{|}~", 4);
        public UserConstants() { }
    }
}
