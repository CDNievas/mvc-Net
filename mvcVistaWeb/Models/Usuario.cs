using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcVistaWeb.Models
{
    public class Usuario
    {

        public int id;
        public string email;
        public string direccion;
        public int puntos;

        public Usuario(int id, string email, string direccion, int puntos)
        {
            this.id = id;
            this.email = email;
            this.direccion = direccion;
            this.puntos = puntos;
        }



    }
}
