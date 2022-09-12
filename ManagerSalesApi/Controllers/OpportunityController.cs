using ManagerSalesApi.Client.Response;
using ManagerSalesApi.Controllers.Request;
using ManagerSalesApi.Models;
using ManagerSalesApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagerSalesApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class OpportunityController : ControllerBase
    {
        private static List<OpportunityRequest> opportunities = new List<OpportunityRequest>();
        private readonly RandomUserOpportunityService _service;

        public OpportunityController(RandomUserOpportunityService service)
        {
            _service = service;
        }

        /// POST v1/api/opportunity
        /// <summary>
        /// Inserção de uma nova oportunidade
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST v1/api/opportunity
        ///     {
        ///        "cnpj": "50247022000129",
        ///        "name": "Oportunidade de ouro",
        ///        "amount": 12.5
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Retorna os dados de usuários com Id</returns>
        /// <response code="200">Item criado no banco de dados</response>
        /// <response code="400">Nenhum cliente retornado com esse cnpj</response>
        /// <response code="400">Nenhum usuário foi encontrado para a região do cnpj!</response>
        [HttpPost]
        public IActionResult AddOpportunity([FromBody] OpportunityRequest opportunity)
        {
            return Ok(_service.GetUserOpportunity(opportunity));
        }
    }
}
