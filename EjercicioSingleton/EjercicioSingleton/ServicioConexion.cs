using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioSingleton
{
    internal class ServicioConexion
    {
        public void ConectarBD()
        {
            string conexionBD = ConfigurationManager.Instancia.Get("ConnectionString");
            Console.WriteLine($"Intentando conectar a la base de datos con: {conexionBD}");
        }
    }
}
