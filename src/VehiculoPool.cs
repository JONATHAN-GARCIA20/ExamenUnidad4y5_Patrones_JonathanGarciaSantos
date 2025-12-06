using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalPatrones
{
    public class VehiculoPool
    {
        private readonly List<Vehiculo> vehiculosDisponibles;
        private readonly List<Vehiculo> vehiculosEnUso;
        private readonly object candado = new object(); // Bloqueo

        public VehiculoPool(int cantidad)
        {
            vehiculosDisponibles = new List<Vehiculo>();
            vehiculosEnUso       = new List<Vehiculo>();

            for (int i = 1; i <= cantidad; i++)
            {
                string tipo = (i % 2 == 0) ? "Bus" : "Camioneta";
                vehiculosDisponibles.Add(new Vehiculo($"T{i:000}", tipo));
            }
        }

        private void ActualizarMantenimientos()
        {
            List<Vehiculo> todos = new List<Vehiculo>();
            todos.AddRange(vehiculosDisponibles);
            todos.AddRange(vehiculosEnUso);

            foreach (Vehiculo v in todos)
            {
                v.ActualizarMantenimiento();
            }
        }

        public void MostrarEstado()
        {
            ActualizarMantenimientos();

            Console.WriteLine("\n=== Estado actual de los vehículos ===");
            Console.WriteLine("{0,-8}{1,-15}{2,-15}", "PLACA", "TIPO", "ESTADO");
            Console.WriteLine(new string('-', 40));

            List<Vehiculo> todos = new List<Vehiculo>();
            todos.AddRange(vehiculosDisponibles);
            todos.AddRange(vehiculosEnUso);

            foreach (Vehiculo v in todos)
            {
                Console.WriteLine("{0,-8}{1,-15}{2,-15}",
                    v.Placa,
                    v.Tipo,
                    v.Estado.Nombre);
            }
        }

        public void AsignarVehiculo(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("\n Placa inválida.");
                return;
            }

            lock (candado)
            {
                ActualizarMantenimientos();

                Vehiculo vEnUso = vehiculosEnUso.FirstOrDefault(x => x.Placa == placa);
                if (vEnUso != null)
                {
                    Console.WriteLine("\n El vehículo " + placa + " ya está en uso. No se puede asignar de nuevo.");
                    return;
                }

                Vehiculo vDisponible = vehiculosDisponibles
                    .FirstOrDefault(x => x.Placa == placa);

                if (vDisponible == null)
                {
                    Console.WriteLine("\n No se encontró el vehículo.");
                    return;
                }

                if (vDisponible.Estado is EstadoMantenimiento)
                {
                    Console.WriteLine($"\n El vehículo {placa} está en mantenimiento. Espera a que termine el minuto.");
                    return;
                }

                vDisponible.Asignar();
                vehiculosDisponibles.Remove(vDisponible);
                vehiculosEnUso.Add(vDisponible);

                Console.WriteLine("\n Vehículo " + placa + " bloqueado para uso.");
                MostrarEstado();
            }
        }

        public void LiberarVehiculo(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("\n Placa inválida.");
                return;
            }

            lock (candado)
            {
                Vehiculo v = vehiculosEnUso.FirstOrDefault(x => x.Placa == placa);
                if (v != null)
                {
                    v.Liberar(); 

                    vehiculosEnUso.Remove(v);
                    vehiculosDisponibles.Add(v);

                    Console.WriteLine("\n Vehículo " + placa + " liberado. Entró en mantenimiento 1 minuto.");
                    MostrarEstado();
                }
                else
                {
                    Console.WriteLine("\n No se puede liberar el vehículo " + placa + " porque no está en uso.");
                }
            }
        }
    }
}
