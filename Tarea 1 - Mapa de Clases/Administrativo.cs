namespace MapaClases
{
    public class Administrativo : Empleado
    {
        public Administrativo(string nombre) : base(nombre) { }

        public override void MostrarRol()
        {
            System.Console.WriteLine("Administrativo");
        }
    }
}