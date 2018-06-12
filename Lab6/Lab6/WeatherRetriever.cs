using Lab6.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab6
{
    class WeatherRetriever
    {
        private string apikey = "fe6981316a9439d7";

        public async Task<ConditionsRootObject> GetConditions()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://api.wunderground.com/api/{apikey}/conditions/q/CA/San_Francisco.json";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            ConditionsRootObject conditions = JsonConvert.DeserializeObject<ConditionsRootObject>(responseString);

            return conditions;
        }
    }
}
