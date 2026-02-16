namespace MapaClases
{
    public class Estudiante : MiembroDeLaComunidad
    {
        public Estudiante(string nombre) : base(nombre) { }

        public override void MostrarRol()
        {
            System.Console.WriteLine("Estudiante");
        }
    }
}