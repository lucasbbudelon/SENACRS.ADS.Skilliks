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
        

        public JobFeedBackController()
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
        [HttpGet("{id}", Name = "Get")]
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
