using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public static class Validaciones
    {
        public static bool EsNumero(string valor)
        {
            // Intentar convertir el valor a un número
            return double.TryParse(valor, out _);
        }
        public static bool ContieneNumeros(string input)
        {
            // Utiliza una expresión regular para verificar si hay al menos un número en la cadena
            Regex regex = new Regex("[0-9]");
            return regex.IsMatch(input);
        }
        public static bool EsFormatoCorreoElectronico(string input)
        {
            // Utiliza una expresión regular para verificar el formato del correo electrónico
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            return regex.IsMatch(input);
        }

    }
}
