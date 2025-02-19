﻿using System.ComponentModel.DataAnnotations;

namespace ManagerSalesApi.Models
{
    public class Opportunity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de cnpj é obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo de valor monetário é obrigatório!")]
        public double Amount { get; set; }

        public string CorporateName { get; set; }

        public string TaskMain { get; set; }

        public User user { get; set; }
    }
}
