using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProfile_Images.Interfaces
{
    public class CreationStatus
    {
        public static int UsernameExists = 0;
        public static int UnknownError = 1;
        public static int Success = 2;
        public int state;
        public string token;
        public CreationStatus(int status, string token = null)
        {
            this.state = status;
            this.token = token;
        }
    }
}
