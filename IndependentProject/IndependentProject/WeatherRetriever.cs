using IndependentProject.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IndependentProject
{
    class WeatherRetriever
    {
        private string apikey = "fe6981316a9439d7";

        public async Task<ConditionsRootObject> GetConditions(string cityLink)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"http://api.wunderground.com/api/{apikey}/conditions{cityLink}.json";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            ConditionsRootObject conditions = JsonConvert.DeserializeObject<ConditionsRootObject>(responseString);

            return conditions;
        }

        public async Task<AutoCompleteRootObject> GetSuggestions(string enteredstr)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"http://autocomplete.wunderground.com/aq?query={enteredstr}&c=US";
            string responseString = await httpClient.GetStringAsync(apiUrl);
            AutoCompleteRootObject suggestions = JsonConvert.DeserializeObject<AutoCompleteRootObject>(responseString);
            return suggestions;
        }
    }
}
