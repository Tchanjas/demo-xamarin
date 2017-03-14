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
            //apiService.PostAnimalAsync
            await Navigation.PopAsync();
        }
    }
}
