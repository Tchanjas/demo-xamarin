using System.Collections.Generic;
using Xamarin.Forms;
using demo_xamarin.Views;
using demo_xamarin.Models;
using System;
namespace demo_xamarin
{
    public partial class MainPage : MasterDetailPage
    {
        private List<Item> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            menuList = new List<Item>
            {
                 new Item() { Type = "list", Title = "Listar Animais" },
                 new Item() { Type = "add", Title = "Adicionar Animal" }
            };
            menuDrawer.ItemsSource = menuList;
            Detail = new NavigationPage(new listarAnimais());
        }

        void menuItemClick(object sender, ItemTappedEventArgs e)
        {
            this.IsPresented = false;
            var pageType = (Item)e.Item;
            if (pageType.Type == "add") { Detail = new NavigationPage(new adicionarAnimal()); }
            else if (pageType.Type == "list") { Detail = new NavigationPage(new listarAnimais()); }
        }
    }
}
