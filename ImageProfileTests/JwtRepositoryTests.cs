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
        //Hard coded paths. Set the parameter string to be the directory that holds a keys directory with privatekey.pem and publickey.pem
        PKFileReader pkFileReader = new PKFileReader(@"B:\repos\ImageProfile\ImageProfile-LoginMicroservice\ImageProfileTests");
        PKFileReader secondaryPkFileReader = new PKFileReader(@"B:\repos\ImageProfile\ImageProfile-LoginMicroservice\ImageProfileTests\keys\BadKeys");
        JwtRepository jwtRepository;
        JwtRepository jwtRepository2;
        public JwtRepositoryTests()
        {
            jwtRepository = new JwtRepository(pkFileReader);
            jwtRepository2 = new JwtRepository(secondaryPkFileReader);
        }
        [Fact]
        public void JwtReponseCanValidateItself()
        {
            string usernameForValidation = "admin12345";
            JwtResponse generatedToken = jwtRepository.CreateToken(usernameForValidation).Result;
            Assert.True(jwtRepository.ValidateToken(generatedToken.Token, usernameForValidation).Result == true);
        }
        [Fact]
        public void JwtResponseCanInvalidateIncorrectPublicKey()
        {
            string usernameForValidation = "admin12345";
            JwtResponse generatedToken = jwtRepository.CreateToken(usernameForValidation).Result;
            Assert.True(jwtRepository2.ValidateToken(generatedToken.Token, usernameForValidation).Result == false);
        }
        [Fact]
        public void JwtResponseInvalidatesIncorrectName()
        {
            string usernameForValidation = "admin12345";
            JwtResponse generatedToken = jwtRepository.CreateToken(usernameForValidation).Result;
            Assert.True(jwtRepository.ValidateToken(generatedToken.Token, "admin12344").Result == false);
        }
    }
}
