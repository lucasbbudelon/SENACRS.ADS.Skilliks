using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Contracts.Services;
using Domain.Contracts.Repositories;
using Core.Services;
using Data.Repositories;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobFeedBackController : ControllerBase
    {
        private readonly IJobFeedBackService _jobFeedBackService;

        public JobFeedBackController(IJobFeedBackService jobFeedBackService)
        {
            _jobFeedBackService = jobFeedBackService;
        }

        // GET: api/JobFeedBack
        [HttpGet]
        public ActionResult<IEnumerable<JobFeedBack>> Get()
        {
            try
            {
                var result = _jobFeedBackService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/JobFeedBack/5
        [HttpGet("{id}")]
        public ActionResult<JobFeedBack> Get(long id)
        {
            try
            {
                var result = _jobFeedBackService.Get(id);

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

        // POST: api/JobFeedBack
        [HttpPost]
        public ActionResult Post([FromBody] JobFeedBack jobFeedBack)
        {
            try
            {
                _jobFeedBackService.Insert(jobFeedBack);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/JobFeedBack/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] JobFeedBack jobFeedBack)
        {
            try
            {
                _jobFeedBackService.Update(id, jobFeedBack);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _jobFeedBackService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
