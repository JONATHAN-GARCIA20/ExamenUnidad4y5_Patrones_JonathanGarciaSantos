using System;

namespace ProyectoFinalPatrones
{
    public class EstadoMantenimiento : IEstadoVehiculo
    {
        public string Nombre => "Mantenimiento";

        public void Asignar(Vehiculo contexto)
        {
            Console.WriteLine($" El vehículo {contexto.Placa} está en mantenimiento y NO puede asignarse.");
        }

        public void Liberar(Vehiculo contexto)
        {
            Console.WriteLine($" ℹEl vehículo {contexto.Placa} ya está en mantenimiento.");
        }
    }
}
