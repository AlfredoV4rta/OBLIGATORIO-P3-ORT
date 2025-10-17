using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Auditoria : IValidable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }
        
        [Required]
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
