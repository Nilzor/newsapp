using RestSharp;
using sharedproj.Models;    
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sharedproj
{
    class NewsService
    {
        public const string Url = "http://sch.nilsenlabs.com";

        public Task<ArticleList> loadLatestList()
        {
            var t = new TaskCompletionSource<ArticleList>();

            var client = new RestClient(Url);
            var req = new RestRequest("data/latest");
            client.ExecuteAsync<ArticleList>(req, resp =>
            {
                t.TrySetResult(resp.Data);
            });
            return t.Task;
        }
    }
}
