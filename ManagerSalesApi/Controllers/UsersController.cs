using ManagerSalesApi.Data;
using ManagerSalesApi.Enum;
using ManagerSalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagerSalesApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private DataBaseContext _context;

        public UsersController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            //Console.WriteLine("dddd " + ((int)RegionEnum.Sudeste));
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = user.Id}, user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User user = _context.Users.FirstOrDefault(filme => filme.Id == id);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

    }
}
