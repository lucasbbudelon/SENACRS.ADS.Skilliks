using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class JobInterviewService : IJobInterviewService
    {
        private readonly IJobInterviewRepository _repository;
        public readonly IJobFeedBackService _jobFeedBackService;
        public readonly IJobFeedBackRepository _jobFeedBackRepository;
        public readonly IJobApplicantService _jobApplicantService;
        public readonly IUserService _userService;

        public JobInterviewService(
            IJobInterviewRepository repository,
            IJobFeedBackService jobFeedBackService,
            IJobFeedBackRepository jobFeedBackRepository,
            IJobApplicantService jobApplicantService,
            IUserService userService)
        {
            _repository = repository;
            _jobFeedBackService = jobFeedBackService;
            _jobApplicantService = jobApplicantService;
            _userService = userService;
        }

        public JobInterview Get(long id)
        {
            var jobInterview = _repository.Get(id);

            if (jobInterview != null)
            {
                jobInterview.JobApplicant = _jobApplicantService.Get(jobInterview.IdJobApplicant);
                jobInterview.UserTechnical = _userService.Get(jobInterview.IdUserTechnical);
                jobInterview.UserRecruiter = _userService.Get(jobInterview.IdUserRecruiter);

                if (jobInterview.IdJobFeedBack.HasValue)
                {
                    jobInterview.JobFeedBack = _jobFeedBackService.Get(jobInterview.IdJobFeedBack.Value);
                }
            }

            return jobInterview;
        }

        public List<JobInterview> GetAll()
        {
            var jobInterviews = _repository.GetAll();

            foreach (var jobInterview in jobInterviews)
            {
                jobInterview.JobApplicant = _jobApplicantService.Get(jobInterview.IdJobApplicant);
                jobInterview.UserTechnical = _userService.Get(jobInterview.IdUserTechnical);
                jobInterview.UserRecruiter = _userService.Get(jobInterview.IdUserRecruiter);

                if (jobInterview.IdJobFeedBack.HasValue)
                {
                    jobInterview.JobFeedBack = _jobFeedBackService.Get(jobInterview.IdJobFeedBack.Value);
                }
            }

            return jobInterviews;
        }

        public List<JobInterview> GetAll(User user)
        {
            var list = GetAll();

            return user.IsTechnical
                ? list.Where(x => x.IdUserTechnical == user.Id || x.IdJobApplicant == user.Id).ToList()
                : list;
        }

        public JobInterview Insert(JobInterview user)
        {
            user = _repository.Insert(user);
            return user;
        }

        public void Update(long id, JobInterview user)
        {
            _repository.Update(id, user);
        }

        public void Delete(long id)
        {
            _jobFeedBackRepository.DeleteLogicalByRelacionalKey(id);
            _repository.DeleteLogical(id);
        }
    }
}
