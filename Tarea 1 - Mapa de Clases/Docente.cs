namespace MapaClases
{
    public class Docente : Empleado
    {
        public Docente(string nombre) : base(nombre) { }

        public override void MostrarRol()
        {
            System.Console.WriteLine("Docente");
        }
    }
}