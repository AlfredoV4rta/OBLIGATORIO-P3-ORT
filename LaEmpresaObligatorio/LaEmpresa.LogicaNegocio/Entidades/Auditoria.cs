using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion {  get; set; }

        public Auditoria(string id, string email, string accion)
        {
            Id = id;
            Email = email;
            Accion = accion;
        }

        public Auditoria() { }
    }
}
