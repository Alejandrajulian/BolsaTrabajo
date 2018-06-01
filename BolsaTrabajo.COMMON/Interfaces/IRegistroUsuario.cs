using BolsaTrabajo.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTrabajo.COMMON.Interfaces
{
    public interface IRegistroUsuario : IGenericManager<RegistroUsuario>
    {
        RegistroUsuario Registro(string nombre, string edad, string ubicacion, string email, string telefono, string escolaridad, DateTime fecharegistro);
    }
}
