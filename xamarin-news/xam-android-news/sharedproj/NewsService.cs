using Newtonsoft.Json;
using RestSharp;
using sharedproj.Models;    
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sharedproj
{
    class NewsService
    {
        public const string Url = "http://sch.nilsenlabs.com";
        private static RestClient NewsClient = new RestClient(Url);
        private static HttpClient ArticleClient = new HttpClient();

        public Task<ArticleList> loadLatestList()
        {
            var t = new TaskCompletionSource<ArticleList>();

            var req = new RestRequest("data/latest");
            NewsClient.ExecuteAsync<ArticleList>(req, resp =>
            {
                t.TrySetResult(resp.Data);
            });
            return t.Task;
        }

        public async Task<dynamic> LoadArticle(string articleId)
        {
            // Using Newstonsoft JSON to deserialize
            var resp = await ArticleClient.GetAsync(Url + "/v1/articles/" + articleId);
            var textData = await resp.Content.ReadAsStringAsync();
            var dataObj = JsonConvert.DeserializeObject<dynamic>(textData);
            return dataObj;
        }
    }
}
