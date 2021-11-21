using MediaManager;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBD.Model;
using Xamarin.Forms;

namespace VideoBD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TakeVideo_Clicked(object sender, EventArgs e)
        {
            var cameraOptions = new StoreVideoOptions();
            cameraOptions.PhotoSize = PhotoSize.Full;
            cameraOptions.Name = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "mp4";
            cameraOptions.Directory = "DefaultVideos";

            var mediaFile = await Plugin.Media.CrossMedia.Current.TakeVideoAsync(cameraOptions);

            if (mediaFile != null)
            {
                if (nombre.Text != null)
                {
                    if (descrip.Text != null)
                    {
                        Video video1 = new Video
                        {
                            nombre = nombre.Text,
                            descripcion = descrip.Text,
                            path = mediaFile.Path
                        };
                        await App.SQLiteDB.SaveVideoAsync(video1);

                        await DisplayAlert("Registro", "Video guardado correctamente", "Ok");

                        await CrossMediaManager.Current.Play(mediaFile.Path);
                        nombre.Text = "";
                        descrip.Text = "";

                    }
                }
                Video video2 = new Video
                {
                    nombre = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "mp4",
                    descripcion = "Video mp4",
                    path = mediaFile.Path
                };
                await App.SQLiteDB.SaveVideoAsync(video2);

                await DisplayAlert("Registro", "Video guardado correctamente", "Ok");

                await CrossMediaManager.Current.Play(mediaFile.Path);
                nombre.Text = "";
                descrip.Text = "";
            }
        }

        private async void btnver_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();

            var detalles = new Videos();
            await Navigation.PushAsync(detalles);
        }
    }
}
