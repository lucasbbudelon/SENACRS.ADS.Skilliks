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
            jobApplicant.Score = CalculateScore(jobApplicant);

            return jobApplicant;
        }

        public List<JobApplicant> GetAll()
        {
            var jobApplicants = _repository.GetAll();

            foreach (var jobApplicant in jobApplicants)
            {
                jobApplicant.Applicant = _userService.Get(jobApplicant.IdApplicant);
                jobApplicant.Job = _jobService.Get(jobApplicant.IdJob);
                jobApplicant.Score = CalculateScore(jobApplicant);
            }

            return jobApplicants;
        }

        public List<JobApplicant> GetAll(User user)
        {
            var list = GetAll();

            if (user.Type.Equals(UserType.Applicant))
            {
                list = list.Where(x => x.Applicant.Id == user.Id).ToList();
            }
            else if (user.Category.Equals(UserCategory.Technical))
            {
                list = list.Where(x => x.Job.IdTeam == user.IdTeam).ToList();
            }

            return list;
        }

        public JobApplicant Insert(JobApplicant entity)
        {
            entity.Status = JobApplicantStatus.InProcess;

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

        private double CalculateScore(JobApplicant jobApplicant)
        {
            double ranking = 0;

            foreach (var jobSkill in jobApplicant.Job.Skills)
            {
                var applicantSkill = jobApplicant.Applicant.Skills.FirstOrDefault(x => x.IdSkill == jobSkill.IdSkill);
                if (applicantSkill != null)
                {
                    ranking += applicantSkill.Ranking > jobSkill.Ranking
                            ? jobSkill.Weight
                            : (jobSkill.Weight / jobSkill.Ranking) * applicantSkill.Ranking;
                }
            }

            jobApplicant.Star = ranking >= jobApplicant.Job.MinScore;

            return ranking;
        }
    }
}
