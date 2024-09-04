using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using UserService.Models;
using UserService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();
            return new OkObjectResult(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetUserById(id);
            return new OkObjectResult(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            using (var scope = new TransactionScope())
            {
                _userRepository.AddUser(user);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
        }

        // PUT api/<UserController>
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    _userRepository.UpdateUser(user);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }


        // PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] User user)
        //{
        //    var userData = _userRepository.GetUserById(id);
        //    if (userData != null)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            _userRepository.UpdateUser(user);
        //            scope.Complete();
        //            return new OkResult();
        //        }
        //    }
        //    return new NoContentResult();
        //}

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
