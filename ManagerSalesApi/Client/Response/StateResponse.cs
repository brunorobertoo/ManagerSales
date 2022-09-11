using Newtonsoft.Json;

namespace ManagerSalesApi.Client.Response
{
    public class StateResponse
    {
        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("ibge_id")]
        public string IbgeId { get; set; }
    }
}
