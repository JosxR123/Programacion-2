namespace MapaClases
{
    public class MiembroDeLaComunidad
    {
        public string Nombre { get; set; }

        public MiembroDeLaComunidad(string nombre)
        {
            Nombre = nombre;
        }

        public virtual void MostrarRol()
        {
            System.Console.WriteLine("Miembro de la comunidad");
        }
    }
}