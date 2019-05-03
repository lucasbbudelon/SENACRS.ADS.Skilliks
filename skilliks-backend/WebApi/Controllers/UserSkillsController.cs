using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillsController : ControllerBase
    {
        private UserSkillsRepository _repository;

        public UserSkillsController()
        {
            _repository = new UserSkillsRepository();
        }

        // GET: api/UserSkills
        [HttpGet]
        public ActionResult<IEnumerable<UserSkills>> Get()
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

        // GET: api/UserSkills/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<UserSkills> Get(long id)
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

        // POST: api/UserSkills
        [HttpPost]
        public ActionResult Post([FromBody] UserSkills userSkills)
        {
            try
            {
                _repository.Insert(userSkills);
                return Ok(userSkills);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/UserSkills/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] UserSkills userSkills)
        {
            try
            {
                _repository.Update(id, userSkills);
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
