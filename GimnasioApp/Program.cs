using System;

namespace GimnasioApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioCliente servicioCliente = new ServicioCliente();
            ServicioMembresia servicioMembresia = new ServicioMembresia();
            ServicioPago servicioPago = new ServicioPago();

            servicioCliente.RegistrarCliente("Juan Pérez", "001-1234567-8");
            servicioCliente.RegistrarCliente("María Gómez", "002-7654321-9");

            servicioMembresia.VenderMembresia("Plan Mensual", "Juan Pérez", 1500);

            servicioPago.RegistrarPago("Juan Pérez", 1500);

            Logger.Instance.LogError("Fallo al conectar con la pasarela de pagos externa");

            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;
            Logger logger3 = Logger.Instance;

            bool sonLaMismaReferencia = Object.ReferenceEquals(logger1, logger2) &&
                                        Object.ReferenceEquals(logger2, logger3);

            Console.WriteLine($"Verificación de Singleton: ¿Las 3 instancias son la misma referencia? {sonLaMismaReferencia}");

            Console.ReadLine();
        }
    }
}