using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class TipoDeGasto: IValidable, IEquatable<TipoDeGasto>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoDeGasto() { }

        public TipoDeGasto(string nombre, string descripcion)
        { 
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public void Validar()
        {
            this.ValidarNombre();
            this.ValidarDescripcion();
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new TipoDeGastoException("El nombre no puede ser vacio");
            }
        }

        public void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new TipoDeGastoException("La descripcion no puede ser vacia");
            }
        }

        public bool Equals(TipoDeGasto? other)
        {
            return Id.Equals(other.Id);
        }
    }
}
