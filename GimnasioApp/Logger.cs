using System;
using System.IO;

namespace GimnasioApp
{
    public class Logger
    {
        private static Logger _instance;
        private readonly string logFile = "logs.txt";

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        private void EscribirLog(string nivel, string mensaje)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string linea = $"[{timestamp}] [{nivel}] {mensaje}";

            Console.WriteLine(linea);
            File.AppendAllText(logFile, linea + Environment.NewLine);
        }

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
}