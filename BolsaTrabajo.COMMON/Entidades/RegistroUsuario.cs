using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTrabajo.COMMON.Entidades
{
    public class RegistroUsuario : BaseDTO
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Ubicacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Escolaridad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
