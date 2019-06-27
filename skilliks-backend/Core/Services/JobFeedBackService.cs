using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class JobFeedBackService : IJobFeedBackService
    {

        public readonly IJobFeedBackRepository _repository;
        public readonly IJobFeedBackSkillRepository _jobFeedBackSkillRepository;
        public readonly IUserRepository _userRepository;
        public readonly ISkillRepository _skillRepository;
        public readonly IUserService _userService;
        public readonly IJobService _jobService;

        public JobFeedBackService(IJobFeedBackRepository repository,
            IJobFeedBackSkillRepository jobFeedBackRepository,
            IUserService userService,
            ISkillRepository skillRepository,
            IJobService jobService)
        {
            _repository = repository;
            _jobFeedBackSkillRepository = jobFeedBackRepository;
            _userService = userService;
            _skillRepository = skillRepository;
            _jobService = jobService;
        }

        public void Delete(long id)
        {
            _jobFeedBackSkillRepository.DeleteLogicalByRelacionalKey(id);
            _repository.DeleteLogical(id);
        }

        public JobFeedBack Get(long id)
        {
            var jobFeedBack = _repository.Get(id);
            jobFeedBack.Applicant = _userService.Get(jobFeedBack.IdApplicant);
            jobFeedBack.Job = _jobService.Get(jobFeedBack.IdJob);
            jobFeedBack.Skills = LoadSkills(id);

            return jobFeedBack;
        }

        private List<JobFeedBackSkill> LoadSkills(long id)
        {
            var jobFeedBackSkills = _jobFeedBackSkillRepository.GetAllByRelacionalKey(id);

            foreach (var jobFeedBackSkill in jobFeedBackSkills)
            {
                jobFeedBackSkill.Skill = _skillRepository.Get(jobFeedBackSkill.IdSkill);
            }

            return jobFeedBackSkills
                .OrderByDescending(x => x.SelfEvaluation)
                .ToList();
        }

        public List<JobFeedBack> GetAll()
        {
            var jobFeedBacks = _repository.GetAll();

            foreach(var jobfeedback in jobFeedBacks)
            {
                jobfeedback.Applicant = _userService.Get(jobfeedback.IdApplicant);
                jobfeedback.Job = _jobService.Get(jobfeedback.IdJob);
                jobfeedback.Skills = LoadSkills(jobfeedback.Id);
                jobfeedback.UserTechnical = _userService.Get(jobfeedback.IdUserTecnical);
            }

            return jobFeedBacks;
        }

        public JobFeedBack Insert(JobFeedBack jobFeedBack)
        {
            jobFeedBack = _repository.Insert(jobFeedBack);

            foreach(var skill in jobFeedBack.Skills)
            {
                skill.IdJobFeedBack = jobFeedBack.Id;
                _jobFeedBackSkillRepository.Insert(skill);
            }

            return jobFeedBack;
        }

        public void Update(long id, JobFeedBack jobFeedBack)
        {
            if (jobFeedBack.Skills != null && jobFeedBack.Skills.Any())
            {
                foreach (var skill in jobFeedBack.Skills)
                {
                    skill.IdJobFeedBack = id;

                    if(_jobFeedBackSkillRepository.Get(skill.Id) == null)
                    {
                        _jobFeedBackSkillRepository.Insert(skill);
                    }
                    else
                    {
                        _jobFeedBackSkillRepository.Update(skill.Id, skill);
                    }
                }
            }

            _repository.Update(id, jobFeedBack);
        }
    }
}
