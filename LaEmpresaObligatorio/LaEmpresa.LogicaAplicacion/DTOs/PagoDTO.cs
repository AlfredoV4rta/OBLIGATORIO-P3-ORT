using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.DTOs
{
    public class PagoDTO
    {
        public int Id { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public int IdTipoDeGasto { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public DateTime FechaDePago { get; set; }
        public string NroRecibo { get; set; }
    }
}
