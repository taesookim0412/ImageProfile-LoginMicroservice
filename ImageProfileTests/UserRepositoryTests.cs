using ImageProfile_Login.Repositories;
using System;
using System.Linq;
using Xunit;

namespace ImageProfileTests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void XCsrfTokenIsLogicalLength()
        {
            UserRepository userRepository = new UserRepository(null, null, null, null);
            int numberOfRepeats = 4;
            string combinedString = string.Join("", Enumerable.Repeat("!\"#$%&\\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{|}~", numberOfRepeats));
            int targetLength = combinedString.Length;

            string testGeneratedToken = userRepository.GenerateXCsrfToken().Result;

            Assert.True(testGeneratedToken.Length == targetLength);
        }
    }
}
