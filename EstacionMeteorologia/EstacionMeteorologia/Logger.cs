using System;
using System.IO;

namespace EstacionMeteorologia {

	public sealed class Logger
	{
		private static Logger _instance;

		private readonly string archivoLog = "mantenimiento.txt";

		private Logger() { }

		public static Logger Instance
		{
			get {
				if (_instance == null)

				{

					_instance = new Logger();
				}

				return _instance;
			}

		}

		public void RegistrarMantenimiento(string tipoMantenimiento, string nota)
		{
			string timestamp = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");


		string linea = $"{timestamp,-22} | {tipoMantenimiento,-22} | {nota}";

			Console.WriteLine("\nRegistro guardado: " + linea + "\n");

			File.AppendAllText(archivoLog, linea + Environment.NewLine);
		}

	}

}
