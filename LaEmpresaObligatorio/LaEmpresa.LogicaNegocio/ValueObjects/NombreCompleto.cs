using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreCompleto
    {
        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
