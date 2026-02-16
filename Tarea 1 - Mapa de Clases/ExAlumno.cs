namespace MapaClases
{
    public class ExAlumno : MiembroDeLaComunidad
    {
        public ExAlumno(string nombre) : base(nombre) { }

        public override void MostrarRol()
        {
            System.Console.WriteLine("ExAlumno");
        }
    }
}