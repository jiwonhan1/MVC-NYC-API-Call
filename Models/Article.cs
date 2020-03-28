using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace MvcApiCall.Models
{
    public class Article
    {
        public string Section {get; set;}
        public string Title {get; set;}
        public string Abstract {get; set;}
        public string Url {get; set;}
        public string Byline {get; set;}

        public static List<Article> GetArticles(string apiKey)
        {
            var apiCallTask = ApiHelper.ApiCall(apiKey);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());

            return articleList;
        }
    class ApiHelper
    {
        public static async Task<string> ApiCall(string apiKey)
        {
            RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
            RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
    }
}