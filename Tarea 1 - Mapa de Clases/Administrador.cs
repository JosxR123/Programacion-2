namespace MapaClases
{
    public class Administrador : Docente
    {
        public Administrador(string nombre) : base(nombre) { }

        public override void MostrarRol()
        {
            System.Console.WriteLine("Administrador");
        }
    }
}