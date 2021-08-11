using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public Decimal Estatura { get; set; }
        public string Nacionalidad { get; set; }
    }
}
