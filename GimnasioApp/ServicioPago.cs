namespace GimnasioApp
{
    public class ServicioPago
    {
        public void RegistrarPago(string cliente, int monto)
        {
            Logger.Instance.LogInfo($"Pago registrado: RD${monto} {cliente}");
        }
    }
}