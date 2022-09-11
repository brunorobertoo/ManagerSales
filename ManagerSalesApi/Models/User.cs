using System.ComponentModel.DataAnnotations;

namespace ManagerSalesApi.Models
{
    public class User
    {
        [Required (ErrorMessage = "O campo de nome é obrigatório!")]
        public string Name { get; set; }
        
        [Required (ErrorMessage = "O campo de email é obrigatório!")]
        public string Email { get; set; }

        [Required (ErrorMessage = "O campo de região é obrigatório!")]
        public string Region { get; set; }
    }
}
