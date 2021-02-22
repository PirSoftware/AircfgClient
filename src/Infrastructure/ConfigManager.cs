using Com.Aircfg.Client.Models;
using RestSharp;
using System.IO;
using System.Text;

namespace Com.Aircfg.Client.Infrastructure
{
    public static class ConfigManager
    {
        #region Public Methods

        public static Stream GetConfig(string id, string key, string domain)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(GetConfigString(id, key, domain));

            var m= new MemoryStream(byteArray);
            m.Position = 0;
            return m;
        }

        public static string GetConfigString(string id, string key, string domain)
        {
            var client = new RestClient(domain + "/api");
            client.Timeout = 30 * 60 * 60;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(new SearchModel() { Id = id, Key = key }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var obj= Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            return obj.ToString();
        }

        #endregion Public Methods
    }
}