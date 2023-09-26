using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entidades
{
    public class Direccion
    {
        public int idDireccion { get; set; }
        public string calle { get; set; }
        public string carrera { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public int idUbicacion { get; set; }
    }

}
