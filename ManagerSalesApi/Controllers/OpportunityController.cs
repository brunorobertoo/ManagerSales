﻿using ManagerSalesApi.Client.Response;
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
        
        [HttpPost]
        public IActionResult AddOpportunity([FromBody] OpportunityRequest opportunity)
        {
            return Ok(_service.GetUserOpportunity(opportunity));
        }
    }
}
