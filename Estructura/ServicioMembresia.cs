public class ServicioMembresia
{
    public void VenderMembresia(string plan, string cliente, int monto)
    {
        Logger.Instance.LogInfo($"Membresía vendida: {plan} {cliente} RD${monto}");
    }
}