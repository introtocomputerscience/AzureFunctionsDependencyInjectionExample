using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace DependencyInjectionExampleTests
{
    public class TestHelpers
    {
        public static HttpRequestMessage CreateGetRequest(string hostName = null, Dictionary<string, string> queryString = null)
        {
            var requestPath = string.IsNullOrWhiteSpace(hostName) ? "https://localhost" : hostName;
            requestPath += queryString == null ? string.Empty : $"?{string.Join("&", queryString.Select(kvp => $"{kvp.Key}={kvp.Value}"))}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestPath)
            };

            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            return request;
        }

        public static HttpRequestMessage CreatePostRequest<T>(T obj, string hostName = null)
        {
            var requestPath = string.IsNullOrWhiteSpace(hostName) ? "https://localhost" : hostName;
            var json = JsonConvert.SerializeObject(obj);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestPath),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            return request;
        }
    }
}
