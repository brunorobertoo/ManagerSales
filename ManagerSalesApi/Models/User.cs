using ManagerSalesApi.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerSalesApi.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required (ErrorMessage = "O campo de nome é obrigatório!")]
        public string Name { get; set; }

        [Required (ErrorMessage = "O campo de email é obrigatório!")]
        public string Email { get; set; }

        [Required (ErrorMessage = "O campo de região é obrigatório!")]
        public RegionEnum Region { get; set; }
    }
}
