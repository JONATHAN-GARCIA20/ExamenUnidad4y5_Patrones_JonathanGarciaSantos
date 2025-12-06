using System;

namespace ProyectoFinalPatrones
{
    public class EstadoEnUso : IEstadoVehiculo
    {
        public string Nombre
        {
            get { return "En uso"; }
        }

        public void Asignar(Vehiculo contexto)
        {
            Console.WriteLine(" El vehículo " + contexto.Placa + " ya está en uso.");
        }

        public void Liberar(Vehiculo contexto)
        {
            contexto.EnUso = false;
            contexto.Estado = new EstadoMantenimiento();
            contexto.IniciarMantenimiento(); 
            Console.WriteLine($" Vehículo {contexto.Placa} liberado. Ahora está en mantenimiento por 1 minuto.");
        }
    }
}
