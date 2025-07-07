using System.Net.Http.Headers;
using System.Text;

namespace OfertasCsv.Infrasctructure.Configuration
{
    public class ConfigHttpClient
    {
        private static readonly string user = "Gabriel Marques";
        private static readonly string appPassword = "";


        public HttpClient Create()
        {
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{appPassword.Trim()}"));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            return client;
        }
    }
}
