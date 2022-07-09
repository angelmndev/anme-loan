using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class LoginModel
    {
        private LoginRepositorio loginRepositorio;

        public LoginModel()
        {
            loginRepositorio = new LoginRepositorio();
        }

        public bool userLogin(string user, string password)
        {
            return loginRepositorio.userLogin(user, password);
        }
    }
}
