using BolsaTrabajo.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTrabajo.COMMON.Interfaces
{
    public interface IGenericManager <T> where T : BaseDTO
    {
        T Agregar(T entidad);
        T Modificar(T entidad);
        bool Eliminar(ObjectId id);
        List<T> ListarElementos { get; set; }
        T ObtenerElementosPorId(ObjectId id);
    }
}
