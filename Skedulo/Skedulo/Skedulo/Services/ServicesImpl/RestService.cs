using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Skedulo.Services.ServicesImpl
{
    public class RestService : IRestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }


        public async Task<string> RefreshDataAsync(string url)
        {
            string content = "";
            var uri = new Uri(string.Format(url, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
            }
            catch(HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return content;
        }
    }
}
