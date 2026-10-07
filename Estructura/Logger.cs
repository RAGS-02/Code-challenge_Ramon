using System;
using System.IO;


public class Logger
{
    // 1. Instancia única estática privada
    private static Logger _instance;

    // Ruta del archivo de texto
    private readonly string logFile = "logs.txt";

    // 2. Constructor privado (nadie puede usar "new Logger()")
    private Logger() { }

    // 3. Acceso global estático a la instancia única
    public static Logger Instance
    {
        get
        {
            // Si la instancia no existe, se crea. Si ya existe, se devuelve la misma.
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }
    }

    // Método privado para evitar repetir la lógica de escritura
    private void EscribirLog(string nivel, string mensaje)
    {
        // Formato requerido: [yyyy-MM-dd HH:mm:ss] [NIVEL] mensaje
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string linea = $"[{timestamp}] [{nivel}] {mensaje}";

        // Imprimir en consola
        Console.WriteLine(linea);

        // Escribir en el archivo (añadiendo al final sin borrar lo anterior)
        File.AppendAllText(logFile, linea + Environment.NewLine);
    }

    // Métodos públicos para los distintos niveles de log
    public void LogInfo(string mensaje)
    {
        EscribirLog("INFO", mensaje);
    }

    public void LogWarning(string mensaje)
    {
        EscribirLog("WARNING", mensaje);
    }

    public void LogError(string mensaje)
    {
        EscribirLog("ERROR", mensaje);
    }
}