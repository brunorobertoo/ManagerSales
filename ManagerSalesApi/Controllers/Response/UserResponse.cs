using ManagerSalesApi.Enum;
using ManagerSalesApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerSalesApi.Controllers.Response
{
    public class UserResponse
    {
 
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo de email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de região é obrigatório!")]
        public RegionEnum Region { get; set; }

        public List<Opportunity> opportunities { get; set; }
    }
}
