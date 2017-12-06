using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SearchAPI.Models;
using Newtonsoft.Json;

namespace SearchAPI.Data
{
    public class ITunesSearch
    {
        public static async Task<List<DisplayObject>> GetSearchResults(string searchString)
        {
            string apiUrl = "https://itunes.apple.com/search?term=";

            using (var client = new HttpClient())
            {
                string searchUrl = apiUrl + searchString;
                HttpResponseMessage response = await client.GetAsync(searchUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var rootResult = JsonConvert.DeserializeObject<JsonResult>(result);
                    return rootResult.Results.ToList();
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class JsonResult
    {
        public IEnumerable<DisplayObject> Results { get; set; }
    }
}
