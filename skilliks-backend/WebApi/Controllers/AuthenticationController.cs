using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Domain.Contracts.Repositories;
using Data.Repositories;
using Domain.Contracts.Services;
using Core.Services;
using Domain.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly ISkillRepository _skillRepository;

        public AuthenticationController()
        {
            _skillRepository = new SkillRepository();
            _userSkillRepository = new UserSkillRepository();
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository, _userSkillRepository, _skillRepository);
        }

        // GET: api/authentication/user@gmail.com
        [HttpGet("{email}")]
        public ActionResult<User> Get(string email)
        {
            try
            {
                var user = _userService.GetAll().FirstOrDefault(x => x.Email.Equals(email));

                if (user == null)
                {
                    return Unauthorized();                   
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}