using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App2.Api
{
    public static class ApiService
    {

        public const string _url = "http://192.168.1.51:8885";

        public static async Task<List<Moca>> ObterMocas()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _url + "/v1/mocas";
                var response = await client.GetStringAsync(url);

                List<Moca> mocas = JsonConvert.DeserializeObject<List<Moca>>(response);

                return mocas;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
