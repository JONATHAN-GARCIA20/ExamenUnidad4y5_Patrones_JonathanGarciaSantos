using System;

namespace ProyectoFinalPatrones
{
    public class EstadoDisponible : IEstadoVehiculo
    {
        public string Nombre
        {
            get { return "Disponible"; }
        }

        public void Asignar(Vehiculo contexto)
        {
            contexto.EnUso = true;
            contexto.Estado = new EstadoEnUso();
            Console.WriteLine("✅ Vehículo " + contexto.Placa + " asignado. Estado: " + contexto.Estado.Nombre);
        }

        public void Liberar(Vehiculo contexto)
        {
            // Ya está disponible, no hace nada
            Console.WriteLine("ℹ️ El vehículo " + contexto.Placa + " ya está disponible.");
        }
    }
}
