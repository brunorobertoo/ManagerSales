using System.ComponentModel.DataAnnotations;

namespace ManagerSalesApi.Controllers.Request
{
    public class OpportunityRequest
    {
        [Required(ErrorMessage = "O campo de cnpj é obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo de valor monetário é obrigatório!")]
        public double Amount { get; set; }
    }
}
