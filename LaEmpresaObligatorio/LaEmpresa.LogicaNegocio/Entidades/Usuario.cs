using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.ValueObject;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public Equipo Equipo { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Contrasenia { get; set; }
        public string Email { get; set; }
        public Rol Rol { get; set; }
    }
}
