using ManagerSalesApi.Data;
using ManagerSalesApi.Enum;
using ManagerSalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ManagerSalesApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>();

        private DataBaseContext _context;

        public UsersController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public User addUser([FromBody] User user)
        {
            //Console.WriteLine("dddd " + ((int)RegionEnum.Sudeste));
            users.Add(user);
            return user;
        }

    }
}
