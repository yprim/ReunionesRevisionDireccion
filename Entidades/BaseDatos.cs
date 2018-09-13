using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class BaseDatos
    {
        public String baseLogin { get; set; }
        public String servidorLogin { get; set; }
        public String usuarioLogin { get; set; }
        public String contrasenaLogin { get; set; }

        public String baseRRD { get; set; }
        public String servidorRRD { get; set; }
        public String usuarioRRD { get; set; }
        public String contrasenaRRD { get; set; }
    }
}
