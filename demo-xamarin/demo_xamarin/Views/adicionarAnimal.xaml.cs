using demo_xamarin.Models;
using demo_xamarin.Services;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace demo_xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class adicionarAnimal : ContentPage
    {
        API apiService;
        public byte[] animalImage;
        public adicionarAnimal()
        {
            InitializeComponent();
            apiService = new API();


            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");

                animalImage = new byte[file.GetStream().Length];
                await file.GetStream().ReadAsync(animalImage, 0, (int)file.GetStream().Length);

                Imagem.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };

            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });


                if (file == null)
                    return;

                animalImage = new byte[file.GetStream().Length];
                await file.GetStream().ReadAsync(animalImage, 0, (int)file.GetStream().Length);

                Imagem.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        async void addAnimal(object sender, EventArgs e)
        {
            Animal animal = new Animal();
            animal.AnimalID = 28;
            animal.Nome = this.Nome.Text;
            animal.Especie = this.Especie.Text;
            animal.Raca = this.Raca.Text;
            animal.Peso = this.Peso.Text;
            animal.Altura = this.Altura.Text;

            if (animalImage == null)
                return;

            try
            {
                animal.Imagem = Convert.ToBase64String(animalImage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var dx = this.Data.Date.ToString("yyyy-MM-dd");
            var tx = this.Horas.Time.ToString();
            animal.Data = dx + "T" + tx;

            animal.DonosFK = 1;
            await apiService.PostAnimalAsync(animal);
        }
    }
}
