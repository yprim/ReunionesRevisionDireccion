using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Priscilla Mena
    /// 07/09/2018
    /// clase para administrar la entidad de Hallazgo
    /// </summary>
    public class Hallazgo
    {
        public int idHallazgo { get; set; }
        public DateTime fechaMaximaImplementacion { get; set; }
        public String codigoAccion { get; set;}
        public String observaciones { get; set; }
        public Estado estado { get; set; }
        public Usuario usuario { get; set; }

        /// <summary>
        /// Leonardo Carrion    
        /// 30/ene/2019
        /// se utiliza para mostrar los elementos en la pantalla de administrar hallazgos
        /// </summary>
        public ElementoRevisar elementoRevisar { get; set; }


    }
}
