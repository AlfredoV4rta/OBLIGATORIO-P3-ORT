
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.WebApp.DTOs
{
    public class PagoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un método de pago")]
        public int MetodoPago { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de gasto")]
        public int IdTipoDeGasto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha desde es obligatoria")]
        public DateTime FechaDesde { get; set; }

        [Required(ErrorMessage = "La fecha hasta es obligatoria")]
        public DateTime FechaHasta { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria")]
        public DateTime FechaDePago { get; set; }

        [Required(ErrorMessage = "El numero de recibo es obligatorio")]
        [StringLength(30, ErrorMessage = "El número de recibo no puede superar los 30 caracteres")]
        public string NroRecibo { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0")]
        public double Monto { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El saldo pendiente no puede ser negativo")]
        public double SaldoPendiente { get; set; }
        public TipoDeGastoDTO? TipoGasto { get; set; }
        public UsuarioDTO? Usuario { get; set; }
    }
}
