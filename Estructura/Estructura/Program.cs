using System;

namespace Estructura;

class Program
{
    static void Main(string[] args)
    {
        // 1. Instanciamos las clases consumidoras
        ServicioCliente servicioCliente = new ServicioCliente();
        ServicioMembresia servicioMembresia = new ServicioMembresia();
        ServicioPago servicioPago = new ServicioPago();

        // 2. Simulamos el flujo requerido por el gimnasio
        servicioCliente.RegistrarCliente("Juan Pérez", "001-1234567-8");
        servicioCliente.RegistrarCliente("María Gómez", "002-7654321-9");

        servicioMembresia.VenderMembresia("Plan Mensual", "Juan Pérez", 1500);

        servicioPago.RegistrarPago("Juan Pérez", 1500);

        // Simular un error accediendo directamente al Logger
        Logger.Instance.LogError("Fallo al conectar con la pasarela de pagos externa");

        // 3. Verificación de la unicidad del Singleton (Object.ReferenceEquals)
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;
        Logger logger3 = Logger.Instance;

        bool sonLaMismaReferencia = Object.ReferenceEquals(logger1, logger2) &&
                                    Object.ReferenceEquals(logger2, logger3);

        Console.WriteLine($"Verificación de Singleton: ¿Las 3 instancias son la misma referencia? {sonLaMismaReferencia}");

        Console.ReadLine();
    }
}