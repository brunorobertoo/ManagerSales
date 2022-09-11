using ManagerSalesApi.Client.Response;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManagerSalesApi.Client
{
    public class PublicaCnpjClient
    {

        private readonly HttpClient _httpClient;
        private const string BASE_URL = "https://publica.cnpj.ws";

        public PublicaCnpjClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<CnpjResponse> GetInfoByCnpj(string cnpj)
        {
            var clientHttp = new HttpClient { BaseAddress = new System.Uri(BASE_URL) };
            var response = await clientHttp.GetAsync($"cnpj/{cnpj}");
            var resp = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CnpjResponse>(resp);
        }

    }
}
