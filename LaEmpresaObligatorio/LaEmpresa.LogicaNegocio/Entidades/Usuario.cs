using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using LaEmpresa.LogicaNegocio.ValueObjects;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        [ForeignKey(nameof(EquipoUsuario))]public int IdEquipo { get; set; }
        public Equipo EquipoUsuario { get; set; } 
        public NombreCompleto NombreCompleto { get; set; }
        public string Contrasenia { get; set; }
        public EmailCompleto Email { get; set; }
        public Rol Rol { get; set; }

        public Usuario() {}

        public Usuario(int id, int idEquipo, NombreCompleto nombreCompleto, string contrasenia, Rol rol)
        {
            Id = id;
            IdEquipo = idEquipo;
            NombreCompleto = nombreCompleto;
            Contrasenia = contrasenia;
            Email = new EmailCompleto(nombreCompleto);
            Rol = rol;
        }

        public void Validar()
        {
            this.ValidarRol();
            this.ValidarIdEquipo();
            this.ValidarContrasenia();
            this.ValidarNombreCompleto();
            this.ValidarEmailCompleto();
        }

        public void ValidarIdEquipo()
        {
            if(this.IdEquipo < 0)
            {
                throw new UsuarioException("Id de equipo mal ingresado");
            }
        }
        public void ValidarNombreCompleto()
        {
            NombreCompleto.Validar();
        }
        public void ValidarEmailCompleto()
        {
            Email.Validar();
        }

        public void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(Contrasenia) || Contrasenia.Length < 8)
            {
                throw new UsuarioException("Contrasenia vacia o muy corta. Minimo 8 caracteres");
            }
        }

        public void ValidarRol()
        {
            if (Rol == null)
            {
                throw new UsuarioException("El usuario debe tener rol");
            }
        }
    }
}
