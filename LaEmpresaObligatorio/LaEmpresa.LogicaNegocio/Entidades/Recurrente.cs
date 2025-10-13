using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Recurrente : Pago
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public Recurrente() { }

        public override double CalcularSaldoPendiente(double monto)
        {
            int cantMeses = MesesDeDiferencia(FechaDesde, FechaHasta);

            return monto * cantMeses;
        }

        public int MesesDeDiferencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            int anios = (fechaHasta.Year - fechaDesde.Year) * 12;
            int totalDiferencia = anios + (fechaHasta.Month - fechaDesde.Month);

            //Le agrego uno para incluir el primer mes
            return totalDiferencia + 1;
        }

        public override DateTime ObtenerFechaHasta()
        {
            return this.FechaHasta;
        }

        public override DateTime ObtenerFechaDesde()
        {
            return this.FechaDesde;
        }

        public override DateTime ObtenerFechaDePago()
        {
            return DateTime.MinValue;
        }

        public override string ObtenerNroRecibo()
        {
            return "";
        }
    }
}
