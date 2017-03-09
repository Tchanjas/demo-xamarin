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
    public partial class listarAnimais : ContentPage
    {
        API apiService;
        List<Animal> items;

        public listarAnimais()
        {
            InitializeComponent();
            apiService = new API();
            RefreshData();
        }

        async void RefreshData()
        {
            items = await apiService.GetAnimaisAsync();
            ListAnimais.ItemsSource = items.ToList();
            foreach (var item in items)
            {
                item.Imagem = "http://adamastor.ipt.pt/Azulejos2-mobile/" + item.Imagem;
            }
        }
    }
}
