using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tarea_2_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RegionComboBox.SelectedIndexChanged += OnRegionSelected;
        }

        private async void OnRegionSelected(object sender, EventArgs e)
        {
            string regionSeleccionada = RegionComboBox.SelectedItem.ToString();
            var paises = await ObtenerPaisesPorRegion(regionSeleccionada);
            PaisesListView.ItemsSource = paises;
        }

        private async void OnPaisTapped(object sender, ItemTappedEventArgs e)
        {
            var paisSeleccionado = (Pais)e.Item;
            await Navigation.PushAsync(new DetallePaisPage(paisSeleccionado));
        }

        public async Task<List<Pais>> ObtenerPaisesPorRegion(string region)
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    var respuesta = await cliente.GetStringAsync($"https://restcountries.com/v3.1/region/{region}");
                    var paisesApi = JsonConvert.DeserializeObject<List<RestCountry>>(respuesta);

                    var paises = new List<Pais>();

                    foreach (var paisApi in paisesApi)
                    {
                        var pais = new Pais
                        {
                            Nombre = paisApi.name?.common,
                            Bandera = paisApi.flags?.svg,
                            Poblacion = paisApi.population.ToString(),
                            Region = paisApi.region,
                            Subregion = paisApi.subregion,
                            Idiomas = paisApi.languages != null ? paisApi.languages.Values.ToList() : new List<string>(),
                            Monedas = paisApi.currencies != null ? paisApi.currencies.Keys.ToList() : new List<string>(),
                            Latitude = paisApi.latlng != null && paisApi.latlng.Count > 1 ? paisApi.latlng[0] : 0,
                            Longitude = paisApi.latlng != null && paisApi.latlng.Count > 1 ? paisApi.latlng[1] : 0
                        };

                        System.Diagnostics.Debug.WriteLine($"Nombre: {pais.Nombre}, Bandera: {pais.Bandera}");
                        paises.Add(pais);
                    }

                    return paises;
                   
                        
                    
                }

            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al obtener los países: {ex.Message}");
                return new List<Pais>();
            }
        }
    }
}
