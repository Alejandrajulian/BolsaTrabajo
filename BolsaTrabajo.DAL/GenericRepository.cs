﻿using BolsaTrabajo.COMMON.Entidades;
using BolsaTrabajo.COMMON.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTrabajo.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : BaseDTO
    {
        private MongoClient client;
        private IMongoDatabase db;

        public GenericRepository()
        {
            client = new MongoClient(new MongoUrl(@"mongodb://Admin:admin123@ds016068.mlab.com:16068/bolsatrabajo"));
            db = client.GetDatabase("bolsatrabajo");
        }

        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Read => Collection().AsQueryable().ToList();

        public T Create(T entidad)
        {
            entidad.Id = ObjectId.GenerateNewId();
            entidad.FechaHora = DateTime.Now;
            try
            {
                Collection().InsertOne(entidad);
                return entidad;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Delete(ObjectId id)
        {
            try
            {
                return Collection().DeleteOne(m => m.Id == id).DeletedCount == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T SearchById(ObjectId id)
        {
            try
            {
                return Collection().Find(e => e.Id == id).SingleOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public T Update(T entidad)
        {
            try
            {
                entidad.FechaHora = DateTime.Now;
                return Collection().ReplaceOne(e => entidad.Id == entidad.Id, entidad).ModifiedCount == 1 ? entidad : null;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
