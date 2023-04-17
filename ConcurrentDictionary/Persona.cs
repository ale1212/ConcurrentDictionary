using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentDictionary
{
    public class Persona
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }

        public bool IsActivo { get; set; } = false;
    }
}
