namespace MapaClases
{
    public class Maestro : Docente
    {
        public Maestro(string nombre) : base(nombre) { }

        public override void MostrarRol()
        {
            System.Console.WriteLine("Maestro");
        }
    }
}