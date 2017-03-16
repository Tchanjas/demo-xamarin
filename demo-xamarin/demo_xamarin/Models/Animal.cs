using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_xamarin.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string Nome { get; set; }

        public string Especie { get; set; }
        public string Raca { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }

        public string Imagem { get; set; }
        public string Data { get; set; }

        public int DonosFK { get; set; }
    }
}
