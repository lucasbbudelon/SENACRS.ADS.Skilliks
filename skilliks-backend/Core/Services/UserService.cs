using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ISkillRepository _skillRepository;
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IJobInterviewRepository _jobInterviewRepository;

        public UserService(
            IUserRepository repository,
            ISkillRepository skillRepository,
            IUserSkillRepository userSkillRepository,
            IJobApplicantRepository jobApplicantRepository,
            IJobInterviewRepository jobInterviewRepository)
        {
            _repository = repository;
            _skillRepository = skillRepository;
            _userSkillRepository = userSkillRepository;
            _jobApplicantRepository = jobApplicantRepository;
            _jobInterviewRepository = jobInterviewRepository;
        }

        public User Get(long id)
        {
            var user = _repository.Get(id);

            if (user != null)
            {
                user.Skills = LoadSkills(id);

                var jobApplications = _jobApplicantRepository.GetAll().Where(x => x.IdApplicant == id);

                user.JobApplications = jobApplications
                    .Where(x => x.Status.Equals(JobApplicantStatus.InProcess))
                    .Count();

                user.JobApplicationsApproved = jobApplications
                   .Where(x => x.Status.Equals(JobApplicantStatus.Approved))
                   .Count();

                user.JobInterviews = _jobInterviewRepository.GetAll()
                    .Where(x => x.IdJobApplicant == id)
                    .Count();
            }

            return user;
        }

        public List<User> GetAll()
        {
            var users = _repository.GetAll();
            return users;
        }

        public User Insert(User user)
        {
            user = _repository.Insert(user);

            if (user.Skills != null && user.Skills.Any())
            {
                foreach (var skill in user.Skills)
                {
                    skill.IdUser = user.Id;
                    _userSkillRepository.Insert(skill);
                }
            }

            return user;
        }

        public void Update(long id, User user)
        {
            if (user.Skills != null && user.Skills.Any())
            {
                foreach (var skill in user.Skills)
                {
                    skill.IdUser = id;

                    if (_userSkillRepository.Get(skill.Id) == null)
                    {
                        _userSkillRepository.Insert(skill);
                    }
                    else
                    {
                        _userSkillRepository.Update(skill.Id, skill);
                    }
                }
            }

            _repository.Update(id, user);
        }

        public void Delete(long id)
        {
            _userSkillRepository.DeleteLogicalByRelacionalKey(id);
            _repository.DeleteLogical(id);
        }


        private List<UserSkill> LoadSkills(long idUser)
        {
            var userSkills = _userSkillRepository.GetAllByRelacionalKey(idUser);

            foreach (var userSkill in userSkills)
            {
                userSkill.Skill = _skillRepository.Get(userSkill.IdSkill);
            }

            return userSkills
                .OrderByDescending(x => x.Ranking)
                .ToList();
        }
    }
}
