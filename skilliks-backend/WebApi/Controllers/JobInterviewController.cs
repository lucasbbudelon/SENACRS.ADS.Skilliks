using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Data.Repositories;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobInterviewController : ControllerBase
    {
        private readonly IJobInterviewService _jobInterviewService;
        private readonly IUserService _userService;

        public JobInterviewController(IJobInterviewService jobInterviewService, IUserService userService)
        {
            _jobInterviewService = jobInterviewService;
            _userService = userService;
        }

        // GET: api/JobInterview
        [HttpGet]
        public ActionResult<IEnumerable<JobInterview>> Get()
        {
            try
            {
                var authentication = new Authentication(Request, _userService);

                var result = _jobInterviewService.GetAll(authentication.User);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/JobInterview/5
        [HttpGet("{id}")]
        public ActionResult<JobInterview> Get(long id)
        {
            try
            {
                var result = _jobInterviewService.Get(id);

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

        // POST: api/JobInterview
        [HttpPost]
        public ActionResult Post([FromBody] JobInterview jobInterview)
        {
            try
            {
                _jobInterviewService.Insert(jobInterview);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/JobInterview/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] JobInterview jobInterview)
        {
            try
            {
                _jobInterviewService.Update(id, jobInterview);
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
                _jobInterviewService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
