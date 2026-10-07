
using EjercicioSingleton;

Console.WriteLine(ConfigurationManager.Instancia.Get("AdminEmail"));

ConfigurationManager.Instancia.Set("Ambiente", "Producción");
Console.WriteLine(ConfigurationManager.Instancia.Get("Ambiente"));

var c1 = ConfigurationManager.Instancia;
var c2 = ConfigurationManager.Instancia;
Console.WriteLine($"¿Misma instancia? {Object.ReferenceEquals(c1, c2)}");


ServicioEmail miEmail = new ServicioEmail();
miEmail.EnviarEmail("Ray@smartfit.com", "Bienvenido Ray");

ServicioConexion miConexion = new ServicioConexion();
miConexion.ConectarBD();