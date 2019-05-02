using System;
using System.Collections.Generic;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private JobRepository _repository;

        public JobController()
        {
            _repository = new JobRepository();
        }

        // GET: api/Job
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
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

        // GET: api/Job/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Job> Get(long id)
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

        // POST: api/Job
        [HttpPost]
        public ActionResult Post([FromBody] Job job)
        {
            try
            {
                _repository.Insert(job);
                return Ok(job);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/Job/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Job job)
        {
            try
            {
                _repository.Update(id, job);
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
