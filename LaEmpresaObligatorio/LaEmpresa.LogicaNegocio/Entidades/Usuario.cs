using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Interfaces;
using LaEmpresa.LogicaNegocio.ValueObjects;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Usuario : IValidable
    {
        public Usuario()
        {
        }

        public int Id { get; set; }
        public Equipo Equipo { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Contrasenia { get; set; }
        public EmailCompleto Email { get; set; }
        public Rol Rol { get; set; }
    }
}
