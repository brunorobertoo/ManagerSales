using AutoMapper;
using ManagerSalesApi.Client;
using ManagerSalesApi.Client.Response;
using ManagerSalesApi.Controllers.Response;
using ManagerSalesApi.Data;
using ManagerSalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ManagerSalesApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private DataBaseContext _context;
        private readonly IMapper _mapper;

        public UsersController(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = user.Id}, user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            List<Opportunity> opportunities = _context.Opportunities.Where(b => b.user.Id == id).ToList();

            UserResponse userResponse = _mapper.Map<UserResponse>(user);

            userResponse.opportunities = opportunities;

            if(user != null)
            {
                return Ok(userResponse);
            }
            return BadRequest();
        }

    }
}
