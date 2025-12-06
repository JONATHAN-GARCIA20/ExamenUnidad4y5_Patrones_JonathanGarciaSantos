using System;

namespace ProyectoFinalPatrones
{
    public class AdministradorRutas
    {
        private static AdministradorRutas instancia;
        private static readonly object bloqueo = new object();

        public string RutaPrincipal { get; private set; }

        private AdministradorRutas()
        {
            RutaPrincipal = "Ruta Central - Tijuana";
            Console.WriteLine("Administrador de Rutas inicializado correctamente.");
        }

        public static AdministradorRutas ObtenerInstancia()
        {
            if (instancia == null)
            {
                lock (bloqueo)
                {
                    if (instancia == null)
                    {
                        instancia = new AdministradorRutas();
                    }
                }
            }
            return instancia;
        }

        public void MostrarRuta()
        {
            Console.WriteLine("\nRuta Principal del Sistema: " + RutaPrincipal);
        }
    }
}
