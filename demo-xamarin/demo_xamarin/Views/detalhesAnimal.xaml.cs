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
        public detalhesAnimal()
        {
            InitializeComponent();
            //this.details = obj;
        }
    }
}
