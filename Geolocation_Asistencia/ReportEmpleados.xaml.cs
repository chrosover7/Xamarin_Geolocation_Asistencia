using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LocalDatabaseSample.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Essentials;


namespace LocalDatabaseSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportEmpleados : ContentPage
    {
        public ReportEmpleados()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ContactListView.ItemsSource = await App.Database.GetPeopleAsync();
        }

       
        public  async void Btn_mapa_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}