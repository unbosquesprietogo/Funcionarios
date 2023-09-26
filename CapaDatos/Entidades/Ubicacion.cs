using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entidades
{
    public class Ubicacion
    {
        public int idUbicacion { get; set; }
        public string ciudad { get; set; }
        public string pais { get; set; }
        public int idFuncionario { get; set; }
    }

}
