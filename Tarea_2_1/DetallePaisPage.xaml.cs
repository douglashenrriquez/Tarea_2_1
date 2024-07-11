using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace Tarea_2_1
{
    public partial class DetallePaisPage : ContentPage
    {
        public DetallePaisPage(Pais pais)
        {
            InitializeComponent();
            BindingContext = pais;

            
            if (pais.Latitude != 0 && pais.Longitude != 0)
            {
                var pin = new Pin
                {
                    Label = !string.IsNullOrEmpty(pais.Nombre) ? pais.Nombre : "Sin nombre",
                    Location = new Location(pais.Latitude, pais.Longitude)
                };

                PaisMap.Pins.Add(pin);
                PaisMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(pais.Latitude, pais.Longitude), Distance.FromMiles(100)));
            }
            else
            {
                DisplayAlert("Error", "Las coordenadas del país no son válidas.", "OK");
            }
        }
    }
}
