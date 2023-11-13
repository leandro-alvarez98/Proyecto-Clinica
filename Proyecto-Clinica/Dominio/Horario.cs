using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
        public int Id_Horario {  get; set; }
        public DateTime Hora { get; set; }
        public bool Disponibilidad { get; set; }
    }
}
