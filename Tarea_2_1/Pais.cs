namespace Tarea_2_1
{
    public class Pais
    {
        public string Nombre { get; set; }
        public string Bandera { get; set; }
        public string Poblacion { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public List<string> Idiomas { get; set; }
        public List<string> Monedas { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }




        public string IdiomasAsString => string.Join(", ", Idiomas);
        public string MonedasAsString => string.Join(", ", Monedas);
    }
}
