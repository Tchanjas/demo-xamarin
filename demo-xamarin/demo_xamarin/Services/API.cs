using demo_xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace demo_xamarin.Services
{
    public class API
    {
        HttpClient client = new HttpClient();
        static readonly string ApiUrl = "http://adamastor.ipt.pt/Azulejos2-mobile/api/AnimaisAPI";

        public API() { }

        public async Task<List<Animal>> GetAnimaisAsync()
        {
            var response = await client.GetStringAsync(ApiUrl);
            var animaisItems = JsonConvert.DeserializeObject<List<Animal>>(response);
            return animaisItems;
        }
    }
}
