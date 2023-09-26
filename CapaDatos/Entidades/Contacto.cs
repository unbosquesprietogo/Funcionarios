using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entidades
{
    public class Contacto
    {
        public int idContacto { get; set; }
        public string correoElectronico { get; set; }
        public string telefono { get; set; }
        public string fax { get; set; }
        public int idFuncionario { get; set; }
    }

}
