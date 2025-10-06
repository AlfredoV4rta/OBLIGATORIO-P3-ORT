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
    public class EmailCompleto: IValidable
    {
        public string Email { get; set; }

        public EmailCompleto(string email)
        {
            this.Email = email;
        }

        public string SiglaNombre { get; set; }
        
        public string SiglaApellido { get; set; }

        public void Validar()
        {
            this.ValidarSiglaNombre();
            this.ValidarSiglaApellido();
            this.ValidarEmailCompleto();
        }

        public void ValidarSiglaNombre()
        {
            if (string.IsNullOrEmpty(SiglaNombre))
            {
                throw new UsuarioException("El mail no debe ser vacio");
            }
        }

        public void ValidarSiglaApellido()
        {
            if (string.IsNullOrEmpty(SiglaApellido))
            {
                throw new UsuarioException("El mail no debe ser vacio");
            }
        }

        public void ValidarEmailCompleto()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new UsuarioException("El mail no debe ser vacio");
            }
        }
    }
}
