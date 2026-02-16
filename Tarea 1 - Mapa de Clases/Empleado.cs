namespace MapaClases
{
    public class Empleado : MiembroDeLaComunidad
    {
        public Empleado(string nombre) : base(nombre) { }

        public override void MostrarRol()
        {
            System.Console.WriteLine("Empleado");
        }
    }
}