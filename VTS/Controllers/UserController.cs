using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTS.Models;
using VTS.Repository;

namespace VTS.Controllers
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
        //GET: api/User
        [HttpGet]
        public IEnumerable<VTS.Models.User> Get()
        {
            var user = _userRepository.GetUser();
            return user;
        }
        [HttpPost("")]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                var result = await _userRepository.AddUsers(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("")]
        public async Task<IActionResult> Put(User user)
        {
            try
            {
                var result = await _userRepository.UpdateUsers(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}