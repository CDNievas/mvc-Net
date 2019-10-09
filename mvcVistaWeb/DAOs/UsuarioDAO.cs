using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using mvcVistaWeb.Models;

namespace mvcVistaWeb.DAOs
{
    public class UsuarioDAO
    {

        public static UsuarioDAO instancia = null;
        public List<Usuario> usuarios = new List<Usuario>();

        private UsuarioDAO() { }

        public static UsuarioDAO getInstancia() { 
        
            if(instancia == null){
                instancia = new UsuarioDAO();
            }

            return instancia;

        }

        public UsuarioDAO add(Usuario user)
        {
            usuarios.Add(user);
            return this;

        }

        public Usuario getUsuarioById(int id)
        {
            return usuarios.Find(x => x.id == id);
        }

    }


}
