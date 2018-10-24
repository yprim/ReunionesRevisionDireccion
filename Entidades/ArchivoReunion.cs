using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /*
     * Priscilla Mena Monge
     * 24/10/2018
     * Clase para administrar la entidad de ArchivoReunion
     */
    public class ArchivoReunion
    {
        public int idArchivoReunion{ get; set; }
        public Reunion reunion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public String creadoPor { get; set; }
        public String nombreArchivo { get; set; }
        public String rutaArchivo { get; set; }
    }
}
