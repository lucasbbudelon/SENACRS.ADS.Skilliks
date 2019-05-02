using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Repository.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _repository;

        public UserController()
        {
            _repository = new UserRepository();
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(long id)
        {
            try
            {
                var result = _repository.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // POST: api/User
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                _repository.Insert(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] User user)
        {
            try
            {
                _repository.Update(id, user);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(long id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
