using demo_xamarin.Models;
using demo_xamarin.Services;
using System;
using System.Collections.Generic;
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
        public adicionarAnimal()
        {
            InitializeComponent();
            apiService = new API();
        }

        async void addAnimal(object sender, EventArgs e)
        {
            Animal animal = new Animal();
            animal.AnimalID = Convert.ToInt32(this.AnimalID.Text);
            animal.Nome = this.Nome.Text;
            animal.Especie = this.Especie.Text;
            animal.Raca = this.Raca.Text;
            animal.Peso = this.Peso.Text;
            animal.Altura = this.Altura.Text;

            animal.Imagem = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABAQMAAAAl21bKAAAAA1BMVEUAAACnej3aAAAAAXRSTlMAQObYZgAAAApJREFUCNdjYAAAAAIAAeIhvDMAAAAASUVORK5CYII=";
            animal.Data = "2015-05-15T13:45:00";

            animal.DonosFK = 1;

            await apiService.PostAnimalAsync(animal);
        }
    }
}
