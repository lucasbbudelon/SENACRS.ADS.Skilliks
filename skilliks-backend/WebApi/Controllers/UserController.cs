using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Contracts.Services;
using Domain.Contracts.Repositories;
using Core.Services;
using Data.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                var result = _userService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            try
            {
                var result = _userService.Get(id);

                if (result == null)
                    return NotFound();
                else
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
                _userService.Insert(user);
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
                _userService.Update(id, user);
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
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
