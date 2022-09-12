using AutoMapper;
using ManagerSalesApi.Controllers.Request;
using ManagerSalesApi.Controllers.Response;
using ManagerSalesApi.Data;
using ManagerSalesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;

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

        /// POST v1/api/user
        /// <summary>
        /// Inserção de novo usuário.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST v1/api/user
        ///     {
        ///        "name": "teste do teste",
        ///        "email": "email@teste.com",
        ///        "region": 3
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Retorna os dados de usuários com Id</returns>
        /// <response code="201">Item criado no banco de dados</response>
        /// <response code="400">Se o item for enviado com email já cadastrado</response> 
        [HttpPost]
        public IActionResult AddUser([FromBody] UserRequest userRequest)
        {
            User user = _mapper.Map<User>(userRequest);
            List<User> usersValid = _context.Users.Where(b => b.Email == userRequest.Email).ToList();
            if(usersValid.Count > 0)
            {
                return BadRequest("Email já foi cadastrado anteriormente");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = user.Id}, user);
        }

        /// POST v1/api/user/1
        /// <summary>
        /// Lista o usuário com todos as suas oportunidades vinculadas
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna os dados de usuário com suas oportunidades</returns>
        /// <response code="200">Retorno de usuário com sua lista de oportunidades</response>
        /// <response code="400">Se o usuário não existir na base de dados</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            List<Opportunity> opportunities = _context.Opportunities.Where(b => b.user.Id == id).ToList();

            UserResponse userResponse = _mapper.Map<UserResponse>(user);
            if(user != null)
            {
                userResponse.opportunities = opportunities;
                return Ok(userResponse);
            }
            return BadRequest();
        }

    }
}
