using AccesoData.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Repositorios
{
    public class LoginRepositorio : MasterRepositorio, ILoginRepositorio
    {
        private string Login;

        public LoginRepositorio()
        {
            Login = "usuarioLogin";
        }
        public bool userLogin(string user, string password)
        {
            return UserLogin(user, password, Login);
        }
    }
}
