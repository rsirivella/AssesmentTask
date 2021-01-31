using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTask.Models
{
    public class LoginRepository
    {
        public List<LoginData> _loginData;
        public LoginRepository()
        {
            _loginData = new List<LoginData>
            {
                new LoginData() { UserName="Rajesh", Password="sirivella"},
                new LoginData() { UserName="Siva", Password="sageit"}
            };
        }
    }
}
