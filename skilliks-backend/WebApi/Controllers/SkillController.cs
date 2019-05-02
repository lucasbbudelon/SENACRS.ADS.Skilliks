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
    public class SkillController : ControllerBase
    {
        private SkillRepository _repository;

        public SkillController()
        {
            _repository = new SkillRepository();
        }

        // GET: api/Skill
        [HttpGet]
        public ActionResult<IEnumerable<Skill>> Get()
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

        // GET: api/Skill/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Skill> Get(long id)
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

        // POST: api/Skill
        [HttpPost]
        public ActionResult Post([FromBody] Skill skill)
        {
            try
            {
                _repository.Insert(skill);
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/Skill/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Skill skill)
        {
            try
            {
                _repository.Update(id, skill);
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
