using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Business;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserBusiness _business;

        public UserController()
        {
            _business = new UserBusiness();
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_business.GetAll());
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(Guid id)
        {
            return Ok(_business.GetById(id));
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<bool> Post([FromBody] User user)
        {
            return Ok(_business.Save(user));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] string value)
        {
            return Ok(true);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(true);
        }
    }
}
