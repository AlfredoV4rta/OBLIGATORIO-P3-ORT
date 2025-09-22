using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public int IdEquipo { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Rol Rol { get; set; }
    }
}
