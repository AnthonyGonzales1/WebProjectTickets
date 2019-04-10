using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public UsuarioRepositorio() : base()
        {

        }


        public bool Verificar(string usuario, string clave)
        {
            bool paso = false;

            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Expression<Func<Usuario, bool>> filtrar = x => true;

            filtrar = t => t.Email.Equals(usuario) && t.Clave.Equals(clave);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                paso = true;
            }

            return paso;
        }
    }
}
