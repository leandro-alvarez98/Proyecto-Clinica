using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_Clinica
{
    public static class Seguridad
    {
        public static bool SesionActiva(object user) // Valida si tiene una sesion activa
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Id != -1)
                return true;
            else 
                return false;
        }
    }
}
