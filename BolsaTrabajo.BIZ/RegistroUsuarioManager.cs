using BolsaTrabajo.COMMON.Entidades;
using BolsaTrabajo.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolsaTrabajo.BIZ
{
    public class RegistroUsuarioManager : IRegistroUsuario
    {

        IRepository<RegistroUsuario> repository;

        public RegistroUsuarioManager(IRepository<RegistroUsuario> repo)
        {
            repository = repo;
        }

        public List<RegistroUsuario> ListarElementos
        {
            get => repository.Read;
            set { }
        }

        public RegistroUsuario Agregar(RegistroUsuario entidad)
        {
            return repository.Create(entidad);
        }

        public bool Eliminar(ObjectId id)
        {
            return repository.Delete(id);
        }

        public RegistroUsuario Modificar(RegistroUsuario entidad)
        {
            return repository.Update(entidad);
        }

        public RegistroUsuario ObtenerElementosPorId(ObjectId id)
        {
            return repository.SearchById(id);
        }

        public RegistroUsuario Registro(string nombre, string edad, string ubicacion, string email, string telefono, string escolaridad, DateTime fecharegistro)
        {
            if (repository.Read.Count(e => e.Nombre == nombre) == 0)
            {
                return repository.Create(new RegistroUsuario()
                {
                    Nombre = nombre,
                    Edad = edad,
                    Ubicacion = ubicacion,
                    CorreoElectronico = email,
                    Telefono = telefono,
                    FechaRegistro = fecharegistro
                });
            }
            else
            {
                return null;
            }
        }
    }
}
