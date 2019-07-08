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
    public class JobApplicantController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJobApplicantService _jobApplicantService;

        public JobApplicantController(IJobApplicantService jobApplicantService, IUserService userService)
        {
            _jobApplicantService = jobApplicantService;
            _userService = userService;
        }

        // GET: api/JobApplicant
        [HttpGet]
        public ActionResult<IEnumerable<JobApplicant>> Get()
        {
            try
            {
                var authentication = new Authentication(Request, _userService);

                var result = _jobApplicantService
                    .GetAll(authentication.User)
                    .OrderByDescending(x => x.Job.Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/JobApplicant/5
        [HttpGet("{id}")]
        public ActionResult<JobApplicant> Get(long id)
        {
            try
            {
                var result = _jobApplicantService.Get(id);

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

        // POST: api/JobApplicant
        [HttpPost]
        public ActionResult Post([FromBody] JobApplicant jobApplicant)
        {
            try
            {
                _jobApplicantService.Insert(jobApplicant);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/JobApplicant/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] JobApplicant jobApplicant)
        {
            try
            {
                _jobApplicantService.Update(id, jobApplicant);
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
                _jobApplicantService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
