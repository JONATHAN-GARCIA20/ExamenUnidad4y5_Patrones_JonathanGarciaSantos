namespace ProyectoFinalPatrones
{
    public interface IEstadoVehiculo
    {
        string Nombre { get; }

        void Asignar(Vehiculo contexto);
        void Liberar(Vehiculo contexto);
    }
}
