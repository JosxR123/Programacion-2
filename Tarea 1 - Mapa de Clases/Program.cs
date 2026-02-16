using System;

namespace MapaClases
{
    class Program
    {
        static void Main(string[] args)
        {
            MiembroDeLaComunidad estudiante = new Estudiante("Juan");
            MiembroDeLaComunidad maestro = new Maestro("Pedro");
            MiembroDeLaComunidad administrador = new Administrador("Ana");

            estudiante.MostrarRol();
            maestro.MostrarRol();
            administrador.MostrarRol();
        }
    }
}