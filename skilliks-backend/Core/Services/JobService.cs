using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _repository;
        private readonly IJobSkillRepository _jobSkillRepository;
        private readonly ISkillRepository _skillRepository;

        public JobService(
            IJobRepository repository,
            IJobSkillRepository jobSkillRepository,
            ISkillRepository skillRepository)
        {
            _repository = repository;
            _jobSkillRepository = jobSkillRepository;
            _skillRepository = skillRepository;
        }

        public void Delete(long id)
        {
            _jobSkillRepository.DeleteLogicalByRelacionalKey(id);
            _repository.DeleteLogical(id);
        }

        public Job Get(long id)
        {
            var job = _repository.Get(id);

            if(job != null)
            {
                job.Skills = LoadSkills(id);
            }

            return job;
        }

        public List<Job> GetAll()
        {
            var jobs = _repository.GetAll();

            foreach (var job in jobs)
            {
                job.Skills = LoadSkills(job.Id);
            }

            return jobs;
        }

        public Job Insert(Job job)
        {
            job = _repository.Insert(job);

            if (job.Skills != null && job.Skills.Any())
            {
                foreach (var skill in job.Skills)
                {
                    skill.IdJob = job.Id;
                    _jobSkillRepository.Insert(skill);
                }
            }

            return job;
        }

        public void Update(long id, Job job)
        {
            if (job.Skills != null && job.Skills.Any())
            {
                foreach (var skill in job.Skills)
                {
                    skill.IdJob = id;

                    if (_jobSkillRepository.Get(skill.Id) == null)
                    {
                        _jobSkillRepository.Insert(skill);
                    }
                    else
                    {
                        _jobSkillRepository.Update(skill.Id, skill);
                    }
                }
            }

            _repository.Update(id, job);
        }

        private List<JobSkill> LoadSkills(long idJob)
        {
            var jobSkills = _jobSkillRepository.GetAllByRelacionalKey(idJob);

            foreach (var jobSkill in jobSkills)
            {
                jobSkill.Skill = _skillRepository.Get(jobSkill.IdSkill);
            }

            return jobSkills;
        }
    }
}
