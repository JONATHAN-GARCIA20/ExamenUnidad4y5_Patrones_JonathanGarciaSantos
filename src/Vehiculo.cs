using System;

namespace ProyectoFinalPatrones
{
    public class Vehiculo : IVehiculoInfo
    {
        public string Placa { get; set; }
        public string Tipo  { get; set; }
        public bool EnUso   { get; set; }

        public IEstadoVehiculo Estado { get; set; }

        public DateTime? HoraMantenimiento { get; private set; }

        public Vehiculo(string placa, string tipo)
        {
            Placa  = placa;
            Tipo   = tipo;
            EnUso  = false;
            Estado = new EstadoDisponible();
            HoraMantenimiento = null;
        }

        public void Asignar()
        {
            Estado.Asignar(this);
        }

        public void Liberar()
        {
            Estado.Liberar(this);
        }

        public void IniciarMantenimiento()
        {
            HoraMantenimiento = DateTime.Now;
        }

        public void ActualizarMantenimiento()
        {
            if (Estado is EstadoMantenimiento && HoraMantenimiento.HasValue)
            {
                TimeSpan tiempo = DateTime.Now - HoraMantenimiento.Value;
                if (tiempo.TotalMinutes >= 1)
                {
                    Estado = new EstadoDisponible();
                    HoraMantenimiento = null;
                    Console.WriteLine($"🔧 Vehículo {Placa} ha salido automáticamente de mantenimiento. Estado: {Estado.Nombre}");
                }
            }
        }

        public string Describir()
        {
            return $"[{Placa}] - {Tipo} - {Estado.Nombre}";
        }

        public override string ToString()
        {
            return Describir();
        }
    }
}
