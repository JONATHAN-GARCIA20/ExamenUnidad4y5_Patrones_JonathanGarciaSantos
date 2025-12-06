using System;

namespace ProyectoFinalPatrones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Reserva y Seguimiento de Transportes - Patrones";

            FachadaTransporte sistema = new FachadaTransporte();

            Console.WriteLine("\n=== SISTEMA DE RESERVA Y SEGUIMIENTO DE TRANSPORTES ===");
            sistema.MostrarRuta();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n========== MENÚ PRINCIPAL ==========");
                Console.WriteLine("1. Asignar un vehículo por placa");
                Console.WriteLine("2. Liberar un vehículo por placa");
                Console.WriteLine("3. Ver estado de la flota");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        sistema.MostrarEstado();
                        Console.Write("\nIngresa la placa del vehículo a asignar (ej. T001): ");
                        string placaAsignar = Console.ReadLine();
                        sistema.AsignarVehiculo(placaAsignar);
                        break;

                    case "2":
                        sistema.MostrarEstado();
                        Console.Write("\nIngresa la placa del vehículo a liberar (ej. T001): ");
                        string placaLiberar = Console.ReadLine();
                        sistema.LiberarVehiculo(placaLiberar);
                        break;

                    case "3":
                        sistema.MostrarEstado();
                        break;

                    case "4":
                        salir = true;
                        Console.WriteLine("\n Saliendo del sistema... ¡Gracias!");
                        break;

                    default:
                        Console.WriteLine("\n Opción no válida, intenta de nuevo.");
                        break;
                }
            }
        }
    }
}
