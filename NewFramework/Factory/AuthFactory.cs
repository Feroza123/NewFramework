using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFramework.Interfaces;

namespace NewFramework.Factory
{
    public class AuthFactory : IAuthentication
    {
        public string GetAuthHeader()
        {
            return "";
        }
    }
}
