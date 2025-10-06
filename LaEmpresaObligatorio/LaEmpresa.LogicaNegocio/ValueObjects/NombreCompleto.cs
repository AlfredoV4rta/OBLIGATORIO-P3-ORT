using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreCompleto : IValidable
    {
        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public void Validar()
        {
            this.ValidarNombre();
            this.ValidarApellido();
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new UsuarioException("El nombre no puede ser vacio");
            }
        }

        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new UsuarioException("El apellido no puede ser vacio");
            }
        }


    }
}
