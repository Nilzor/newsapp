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

        public Task<String> loadIt()
        {
            var t = new TaskCompletionSource<string>();

            var client = new RestClient(Url);
            var req = new RestRequest("data/latest");
            client.ExecuteAsync(req, resp =>
            {
                t.TrySetResult(resp.Content);
            });
            return t.Task;
        }

        public String syncLoadIt()
        {
            var client = new RestClient(Url);
            var req = new RestRequest("data/latest");
            var res = client.Execute(req);
            return res.Content;
        }


        public ArticleList syncLoadStrong()
        {
            var client = new RestClient(Url);
            var req = new RestRequest("data/latest");
            var res = client.Execute<ArticleList>(req);
            return res.Data;
        }
    }
}
