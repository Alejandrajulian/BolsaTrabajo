using BolsaTrabajo.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTrabajo.COMMON.Interfaces
{
    public interface IRepository <T> where T : BaseDTO
    {
        T Create(T entidad);
        List<T> Read { get; }
        T Update(T entidad);
        bool Delete(ObjectId id);
        T SearchById(ObjectId id);
    }
}
