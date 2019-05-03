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
    public class JobSkillsController : ControllerBase
    {
        private JobSkillsRepository _repository;

        public JobSkillsController()
        {
            _repository = new JobSkillsRepository();
        }

        // GET: api/JobSkills
        [HttpGet]
        public ActionResult<IEnumerable<JobSkills>> Get()
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

        // GET: api/JobSkills/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<JobSkills> Get(long id)
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

        // POST: api/JobSkills
        [HttpPost]
        public ActionResult<JobSkills> Post([FromBody] JobSkills jobSkills)
        {
            try
            {
                _repository.Insert(jobSkills);
                return Ok(jobSkills);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/JobSkills/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] JobSkills jobSkills)
        {
            try
            {
                _repository.Update(id, jobSkills);
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
