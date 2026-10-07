using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioSingleton
{
    internal class ServicioEmail
    {
        public void EnviarEmail(string destinatario, string mensaje)
        {
           string correoAdmin = ConfigurationManager.Instancia.Get("AdminEmail");
            Console.WriteLine($"Enviando correo desde {correoAdmin} hacia {destinatario}: {mensaje}");

        }

    }
}
