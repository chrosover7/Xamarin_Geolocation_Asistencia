using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDatabaseSample.Models;
using Xamarin.Forms;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Essentials;

namespace LocalDatabaseSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        double lati;
        double longi;
        public MainPage()
        {
            InitializeComponent();
            Localizar();
        }


        private async void Localizar()
        {
            var locator = CrossGeolocator.Current; //Acceso a la API
            locator.DesiredAccuracy = 50; //precisión en (Metros)


            if (locator.IsGeolocationAvailable) // servicio existente en el directorio
            {
                if (locator.IsGeolocationEnabled) //GPS esta activado
                {
                    if (!locator.IsListening) //Comprueba si el dispositivo escucha al servicio
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5); //Inicio de la escucha
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        //Estos valores luego hay que guardarlos en una base de datos.
                        var loc = args.Position;
                        lon.Text = loc.Longitude.ToString();
                        longi = double.Parse(lon.Text);
                        lat.Text = loc.Latitude.ToString();
                        lati = double.Parse(lat.Text);

                    };
                }
            }

        }

        string position;

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if ((lati < -13.26 && lati > -14.16666) && (longi < -75.3 && longi > -76.239722))
            {
                position = "Ica";
            }

            DateTime hyf = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && !string.IsNullOrWhiteSpace(Telephone.Text))
            {
                await App.Database.SavePersonAsync(new Contact
                {
                    Name = Name.Text,
                    LastName = LastName.Text,
                    DNI = Telephone.Text,
                    hora_fecha = hyf,
                    tipo = "Entrada",
                    latitud = lati.ToString(),
                    longitud = longi.ToString(),
                    ubicacion = position,


                }); 

                Name.Text = LastName.Text = Telephone.Text = string.Empty;

                await DisplayAlert("Asistencia", "Se registro entrada correctamente", "Ok");
            }
        }

        async void btnsalida_Clicked(object sender, EventArgs e)
        {
            if ((lati < -13.26 && lati > -14.16666) && (longi < -75.3 && longi > -76.239722))
            {
                position = "Ica";
            }



            DateTime hyf = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && !string.IsNullOrWhiteSpace(Telephone.Text))
            {
                await App.Database.SavePersonAsync(new Contact
                {
                    Name = Name.Text,
                    LastName = LastName.Text,
                    DNI = Telephone.Text,
                    hora_fecha = hyf,
                    tipo = "Salida",
                    latitud = lati.ToString(),
                    longitud = longi.ToString(),
                    ubicacion = position,

                }); ; ; ;

                Name.Text = LastName.Text = Telephone.Text = string.Empty;

                await DisplayAlert("Asistencia", "Se registro salida correctamente", "Ok");
            }
        }

        private async void btnmapa_Clicked(object sender, EventArgs e)
        {
            MapLaunchOptions options = new MapLaunchOptions { Name = "Mi posicion Actual" };
            await Map.OpenAsync(lati, longi, options);
        }
    }
}
