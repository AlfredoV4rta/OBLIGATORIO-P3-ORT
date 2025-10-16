using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Auditoria :IValidable
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion {  get; set; }

        public Auditoria(string email, string accion)
        {

            Fecha = DateTime.Now;
            Email = email;
            Accion = accion;
        }

        public Auditoria() { }

        public void Validar() 
        { 
            this.ValidarMail();
        }

        public void ValidarMail()
        {
            throw new TipoDeGastoException("Email no debe estar vacio");
        }
    }
}
