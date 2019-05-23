using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class JobApplicantService : IJobApplicantService
    {
        public readonly IJobApplicantRepository _repository;
        public readonly IUserService _userService;
        public readonly IJobService _jobService;

        public JobApplicantService(
            IJobApplicantRepository repository,
            IUserService userService,
            IJobService jobService)
        {
            _repository = repository;
            _userService = userService;
            _jobService = jobService;
        }

        public JobApplicant Get(long id)
        {
            var jobApplicant = _repository.Get(id);

            jobApplicant.Applicant = _userService.Get(jobApplicant.IdApplicant);
            jobApplicant.Job = _jobService.Get(jobApplicant.IdJob);
            jobApplicant.Ranking = CalculateRanking(jobApplicant);

            return jobApplicant;
        }

        public List<JobApplicant> GetAll()
        {
            var jobApplicants = _repository.GetAll();

            foreach (var jobApplicant in jobApplicants)
            {
                jobApplicant.Applicant = _userService.Get(jobApplicant.IdApplicant);
                jobApplicant.Job = _jobService.Get(jobApplicant.IdJob);
                jobApplicant.Ranking = CalculateRanking(jobApplicant);
            }

            return jobApplicants;
        }

        public JobApplicant Insert(JobApplicant entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(long id, JobApplicant entity)
        {
            _repository.Update(id, entity);
        }

        public void Delete(long id)
        {
            _repository.DeleteLogical(id);
        }

        private double CalculateRanking(JobApplicant jobApplicant)
        {
            double ranking = 0;

            foreach (var jobSkill in jobApplicant.Job.Skills)
            {
                var applicantSkill = jobApplicant.Applicant.Skills.FirstOrDefault(s => s.IdSkill == jobSkill.IdSkill);

                if (applicantSkill != null)
                {
                    var percent = 100 / jobApplicant.Job.Skills.Count;

                    if (applicantSkill.Ranking > jobSkill.Ranking)
                    {
                        ranking += jobSkill.Weight;
                        jobApplicant.Star = true;
                    }
                    else
                    {
                        ranking += (jobSkill.Weight / jobSkill.Ranking) * applicantSkill.Ranking;
                    }
                }
            }

            return ranking;
        }
    }
}
