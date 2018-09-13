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
    /// clase para administrar la entidad de Reunion
    /// </summary>
    public class Reunion
    {
      public int idReunion { get; set; }
      public int anno { get; set; }
      public String mes { get; set; }
      public int consecutivo { get; set; }
      public Tipo tipo { get; set; }
    


    }
}
