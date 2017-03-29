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
    public partial class detalhesAnimal : ContentPage
    {
        String strID;
        API apiService;
        List<Animal> items;
        public detalhesAnimal(int id)
        {
            InitializeComponent();
            strID = id.ToString();
            apiService = new API();
            fillDetails();
        }

        async void fillDetails()
        {
            Animal itemAnimal = await apiService.GetAnimalAsync(strID);
            items = new List<Animal>();
            items.Add(itemAnimal);
            foreach (var item in items)
            {
                item.Imagem = "http://adamastor.ipt.pt/Azulejos2-mobile/" + item.Imagem;
            }
            detailsAnimal.ItemsSource = items.ToList();
        }
    }
}
