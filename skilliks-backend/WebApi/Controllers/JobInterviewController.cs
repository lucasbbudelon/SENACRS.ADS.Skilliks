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
        private readonly ISkillRepository _skillRepository;

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSkillRepository _userSkillRepository;

        private readonly IJobService _jobService;
        private readonly IJobRepository _jobRepository;
        private readonly IJobSkillRepository _jobSkillRepository;

        private readonly IJobFeedBackRepository _jobFeedBackRepository;
        private readonly IJobFeedBackService _jobFeedBackService;

        private readonly IJobFeedBackSkillRepository _jobFeedBackSkillRepository;

        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IJobApplicantService _jobApplicantService;

        private readonly IJobInterviewRepository _jobInterviewRepository;
        private readonly IJobInterviewService _jobInterviewService;

        public JobInterviewController()
        {
            _skillRepository = new SkillRepository();

            _userSkillRepository = new UserSkillRepository();
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository, _userSkillRepository, _skillRepository);

            _jobSkillRepository = new JobSkillRepository();
            _jobRepository = new JobRepository();
            _jobService = new JobService(_jobRepository, _jobSkillRepository, _skillRepository);

            _jobFeedBackSkillRepository = new JobFeedBackSkillRepository();
            _jobFeedBackRepository = new JobFeedBackRepository();
            _jobFeedBackService = new JobFeedBackService(_jobFeedBackRepository, _jobFeedBackSkillRepository, _userService, _skillRepository, _jobService);

            _jobApplicantRepository = new JobApplicantRepository();
            _jobApplicantService = new JobApplicantService(_jobApplicantRepository, _userService, _jobService);

            _jobInterviewRepository = new JobInterviewRepository();
            _jobInterviewService = new JobInterviewService(_jobInterviewRepository, _jobFeedBackService, _jobFeedBackRepository, _jobApplicantService, _userService);

        }

        // GET: api/JobInterview
        [HttpGet]
        public ActionResult<IEnumerable<JobInterview>> Get()
        {
            try
            {
                var result = _jobInterviewService.GetAll();
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
