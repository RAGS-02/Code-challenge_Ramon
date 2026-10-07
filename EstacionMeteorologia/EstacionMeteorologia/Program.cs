using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionMeteorologia
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool salir = false;

            while (!salir)
            {

                try
                {
                    

                    Console.WriteLine("1. Limpieza de sensor");
                    Console.WriteLine("2. Calibración");
                    Console.WriteLine("3. Reemplazo de sensor");
                    Console.WriteLine("4. Revisión general");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("Elige una de las opciones");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    string tipoManteniemiento = "";
                    string nota = "";

                    switch (opcion)
                    {
                        case 1:
                            tipoManteniemiento = "Limpieza de sensor";
                            Console.WriteLine("Ingrese nota: ");
                            nota = Console.ReadLine();
                            Logger.Instance.RegistrarMantenimiento(tipoManteniemiento, nota);
                            break;

                        case 2:
                            tipoManteniemiento = "Calibración";
                            Console.WriteLine("Ingrese nota: ");
                            nota = Console.ReadLine();
                            Logger.Instance.RegistrarMantenimiento(tipoManteniemiento, nota);
                            break;

                        case 3:
                            tipoManteniemiento = "Reemplazo de sensor";
                            Console.WriteLine("Ingrese nota: ");
                            nota = Console.ReadLine();
                            Logger.Instance.RegistrarMantenimiento(tipoManteniemiento, nota);
                            break;
                        case 4:
                            tipoManteniemiento = "Revisión general";
                            Console.WriteLine("Ingrese nota: ");
                            nota = Console.ReadLine();
                            Logger.Instance.RegistrarMantenimiento(tipoManteniemiento, nota);
                            break;

                        case 5:
                            Console.WriteLine("Saliendo del sistema");
                            salir = true;
                            break;
                            
                        default:
                            Console.WriteLine("\n[Error] Opción no válida. Seleccione nuevamente el mantenimiento que se realizará");
                            break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese un número válido de mantenimiento.");
                }
            }

            
        }
    }
}

//PD: Se me complicó el unir los archivos por no usar las variables que se declararon aqui, en el logger, y que mi computadora estaba teniendo fallas en el curso.
// Pero ya todo resuelto.