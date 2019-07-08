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
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: api/Job
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                var result = _jobService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public ActionResult<Job> Get(long id)
        {
            try
            {
                var result = _jobService.Get(id);

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

        // POST: api/Job
        [HttpPost]
        public ActionResult Post([FromBody] Job job)
        {
            try
            {
                _jobService.Insert(job);
                return Ok();
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
                _jobService.Update(id, job);
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
                _jobService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
