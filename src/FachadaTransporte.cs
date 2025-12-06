namespace ProyectoFinalPatrones
{
    public class FachadaTransporte
    {
        private readonly AdministradorRutas _rutas;
        private readonly VehiculoPool _pool;

        public FachadaTransporte()
        {
            _rutas = AdministradorRutas.ObtenerInstancia();
            _pool  = new VehiculoPool(5);
        }

        public void MostrarRuta()
        {
            _rutas.MostrarRuta();
        }

        public void MostrarEstado()
        {
            _pool.MostrarEstado();
        }

        public void AsignarVehiculo(string placa)
        {
            _pool.AsignarVehiculo(placa);
        }

        public void LiberarVehiculo(string placa)
        {
            _pool.LiberarVehiculo(placa);
        }
    }
}
