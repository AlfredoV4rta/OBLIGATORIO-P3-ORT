using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EF.RepositoriosEF
{
    public class RepositorioUsuarioEF : IUsuarioRepositorio
    {
        private LaEmpresaContext _context;

        public RepositorioUsuarioEF(LaEmpresaContext context)
        {
            _context = context;
        }

        public void Add(Usuario obj)
        {
            obj.Validar();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios.OrderBy(user => user.NombreCompleto.Nombre);
        }

        public Usuario FindbyEmail(string email)
        {
            return _context.Usuarios.Where(user => user.Email.Email == email)
                .FirstOrDefault();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string contrasenia)
        {
            Usuario usuarioLogueado = _context.Usuarios.Where(
                    user => user.Email.Email == email &&
                    user.Contrasenia == contrasenia).FirstOrDefault();
            
            if(usuarioLogueado == null)
            {
                throw new UsuarioException("Credenciales invalidas");
            }

            return usuarioLogueado;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
