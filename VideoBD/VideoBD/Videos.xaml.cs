using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBD.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoBD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Videos : ContentPage
    {
        public Videos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var lista = await App.SQLiteDB.GetVideoAsync();
            if (lista != null)
            {
                lstVideo.ItemsSource = lista;
            }
        }

        private async void lstVideo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Video)e.SelectedItem;

            var detail = new Video
            {
                nombre = obj.nombre,
                descripcion = obj.descripcion,
                path = obj.path
            };

            var detalles = new Details();
            detalles.BindingContext = detail;
            await Navigation.PushAsync(detalles);
        }
    }
}