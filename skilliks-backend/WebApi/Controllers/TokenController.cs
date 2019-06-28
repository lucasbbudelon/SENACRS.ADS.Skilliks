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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly ISkillRepository _skillRepository;

        public TokenController()
        {
            _skillRepository = new SkillRepository();
            _userSkillRepository = new UserSkillRepository();
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository, _userSkillRepository, _skillRepository);
        }

        // GET: api/Token
        [HttpGet]
        public ActionResult<string> Get(string username, string password)
        {
            try
            {
                var hasUser = _userService.GetAll().Any(x => x.Email.Equals(username));

                if (hasUser)
                {
                    var token = GetMD5(username, password);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        public string GetMD5(string username, string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(username + password));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
