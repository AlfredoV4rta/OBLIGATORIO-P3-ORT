using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.ValueObjects
{
    [Owned]
    public class EmailCompleto
    {
        public string Email { get; set; }

        public EmailCompleto(string email)
        {
            this.Email = email;
        }

        public string SiglaNombre { get; set; }
        
        public string SiglaApellido { get; set; }
    }
}
