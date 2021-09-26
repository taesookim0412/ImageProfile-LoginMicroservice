using ImageProfile_Images.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImageProfileTests
{
    public class JwtRepositoryTests
    {
        PKFileReader pkFileReader = new PKFileReader(@"B:\repos\ImageProfile\ImageProfile-LoginMicroservice\ImageProfileTests");
        JwtRepository jwtRepository;
        public JwtRepositoryTests()
        {
            jwtRepository = new JwtRepository(pkFileReader);
        }
        [Fact]
        public void JwtReponseCanValidateItself()
        {
            string usernameForValidation = "admin12345";
            JwtResponse generatedToken = jwtRepository.CreateToken(usernameForValidation);
            Assert.True(jwtRepository.ValidateToken(generatedToken.Token, usernameForValidation) == true);
        }
        [Fact]
        public void JwtResponseInvalidatesIncorrectName()
        {
            string usernameForValidation = "admin12345";
            JwtResponse generatedToken = jwtRepository.CreateToken(usernameForValidation);
            Assert.True(jwtRepository.ValidateToken(generatedToken.Token, "admin12344") == false);
        }
    }
}
