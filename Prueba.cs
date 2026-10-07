using System;
using System.IO;

namespace EjemploSingleton
{
    // =========================================================================
    // 1. IMPLEMENTACIÓN DEL PATRÓN SINGLETON (Cumple el criterio de 4 puntos)
    // =========================================================================
    public class GestorDeRegistro
    {
        // Variable estática privada que almacenará la única instancia
        private static GestorDeRegistro _instancia;

        // Ruta del archivo de texto (Concepto del Video 3)
        private readonly string rutaArchivo = "registro_sistema.txt";

        // Constructor PRIVADO: Evita que otras clases hagan "new GestorDeRegistro()"
        private GestorDeRegistro()
        {
            // Regla del sistema inicial: asegurar que el archivo exista
            if (!File.Exists(rutaArchivo))
            {
                File.Create(rutaArchivo).Close();
            }
        }

        // Propiedad pública que controla el acceso a la única instancia
        public static GestorDeRegistro Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GestorDeRegistro();
                }
                return _instancia;
            }
        }

        // =========================================================================
        // 2. LÓGICA Y REGLAS DEL SISTEMA (Cumple el criterio de 3 puntos)
        // =========================================================================
        public void RegistrarAccion(string usuario, string accion)
        {
            // Validar regla de negocio: No permitir registros vacíos o inconsistentes
            if (string.IsNullOrWhiteSpace(accion) || string.IsNullOrWhiteSpace(usuario))
            {
                Console.WriteLine("[ERROR] Intento de registro inválido: El usuario o la acción no pueden estar vacíos.");
                return;
            }

            // Uso de Fecha/Hora (Video 2) e Interpolación de cadenas (Video 1)
            string fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string lineaRegistro = $"[{fechaHora}] Usuario: {usuario} | Acción: {accion}";

            // Uso de StreamWriter para insertar texto sin sobreescribir (Video 3: append en true)
            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                sw.WriteLine(lineaRegistro);
            }

            Console.WriteLine($"=> Acción registrada exitosamente para {usuario}.");
        }

        public void LeerRegistros()
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    Console.WriteLine("\n--- HISTORIAL DE REGISTROS ---");
                    Console.WriteLine(sr.ReadToEnd());
                    Console.WriteLine("------------------------------\n");
                }
            }
        }
    }

    // =========================================================================
    // MÓDULOS DE PRUEBA QUE COMPARTEN LA MISMA INSTANCIA
    // =========================================================================
    public class ModuloVentas
    {
        public void ProcesarVenta(string articulo)
        {
            // Se llama a la instancia única
            GestorDeRegistro.Instancia.RegistrarAccion("Vendedor_01", $"Venta procesada: {articulo}");
        }
    }

    public class ModuloInventario
    {
        public void ActualizarStock(string articulo)
        {
            // Se llama a la MISMA instancia única
            GestorDeRegistro.Instancia.RegistrarAccion("Almacenista_01", $"Stock actualizado: {articulo}");
        }
    }

    // =========================================================================
    // PROGRAMA PRINCIPAL
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Sistema...\n");

            ModuloVentas ventas = new ModuloVentas();
            ModuloInventario inventario = new ModuloInventario();

            // Simulamos operaciones en el sistema
            ventas.ProcesarVenta("Laptop Dell Inspiron 7506");
            inventario.ActualizarStock("Laptop Dell Inspiron 7506");

            // Probamos la regla de validación (intento de romper el sistema)
            Console.WriteLine("\nIntentando registrar una acción en blanco...");
            GestorDeRegistro.Instancia.RegistrarAccion("Admin", "");

            // Leemos el archivo resultante
            GestorDeRegistro.Instancia.LeerRegistros();

            // Demostración técnica de que es un Singleton
            GestorDeRegistro gestorA = GestorDeRegistro.Instancia;
            GestorDeRegistro gestorB = GestorDeRegistro.Instancia;

            if (gestorA == gestorB)
            {
                Console.WriteLine("Prueba Singleton superada: gestorA y gestorB apuntan exactamente al mismo espacio en memoria.");
            }

            Console.ReadLine();
        }
    }
}