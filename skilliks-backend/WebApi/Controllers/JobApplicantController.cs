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
        private readonly ISkillRepository _skillRepository;

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSkillRepository _userSkillRepository;

        private readonly IJobService _jobService;
        private readonly IJobRepository _jobRepository;
        private readonly IJobSkillRepository _jobSkillRepository;

        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IJobApplicantService _jobApplicantService;

        public JobApplicantController()
        {
            _skillRepository = new SkillRepository();

            _userSkillRepository = new UserSkillRepository();
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository, _userSkillRepository, _skillRepository);

            _jobSkillRepository = new JobSkillRepository();
            _jobRepository = new JobRepository();
            _jobService = new JobService(_jobRepository, _jobSkillRepository, _skillRepository);

            _jobApplicantRepository = new JobApplicantRepository();
            _jobApplicantService = new JobApplicantService(_jobApplicantRepository, _userService, _jobService);
        }

        // GET: api/JobApplicant
        [HttpGet]
        public ActionResult<IEnumerable<JobApplicant>> Get()
        {
            try
            {
                if (Request.Headers.Any(x => x.Key.Equals("user-logged-in")))
                {
                    var userLoggedIn = Request.Headers.FirstOrDefault(x => x.Key.Equals("user-logged-in")).Value;
                }

                var result = _jobApplicantService
                    .GetAll()
                    .OrderByDescending(x => x.Ranking);

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
