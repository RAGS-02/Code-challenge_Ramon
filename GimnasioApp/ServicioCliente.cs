namespace GimnasioApp
{
    public class ServicioCliente
    {
        public void RegistrarCliente(string nombre, string cedula)
        {
            Logger.Instance.LogInfo($"Cliente registrado: {nombre} (Cédula {cedula})");
        }
    }
}