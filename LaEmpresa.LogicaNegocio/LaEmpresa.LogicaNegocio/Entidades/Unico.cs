using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Unico : Pago
    {
        public DateTime FechaDePago { get; set; }
        public string NroRecibo { get; set; }
    }
}
