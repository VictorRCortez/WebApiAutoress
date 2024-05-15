namespace WebApiAutores.Entidades
{
    public class Autor
    {
        //crear las propiedades
        //prop es un sniper para crear de una manera rapidamente una propiedad
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; } 


    }
}
