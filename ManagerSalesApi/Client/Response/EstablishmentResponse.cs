using Newtonsoft.Json;

namespace ManagerSalesApi.Client.Response
{
    public class EstablishmentResponse
    {
        [JsonProperty("atividade_principal")]
        public TasMainResponse TaskMain { get; set; }

        [JsonProperty("estado")]
        public StateResponse State { get; set; }
    }
}
