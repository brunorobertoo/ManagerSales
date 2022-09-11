using ManagerSalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagerSalesApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class OpportunityController
    {
        private static List<Opportunity> opportunities = new List<Opportunity>();

        [HttpPost]
        public Opportunity addOpportunity([FromBody] Opportunity opportunity)
        {
            opportunities.Add(opportunity);
            return opportunity;
        }
    }
}
