﻿using System;
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
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly ISkillRepository _skillRepository;

        public UserService(
            IUserRepository repository,
            IUserSkillRepository userSkillRepository,
            ISkillRepository skillRepository)
        {
            _repository = repository;
            _userSkillRepository = userSkillRepository;
            _skillRepository = skillRepository;
        }

        public User Get(long id)
        {
            var user = _repository.Get(id);

            if (user != null)
            {
                user.Skills = LoadSkills(id);
            }

            return user;
        }

        public List<User> GetAll()
        {
            var users = _repository.GetAll();

            foreach (var user in users)
            {
                user.Skills = LoadSkills(user.Id);
            }

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

        public UserDashboard GetDashboard()
        {
            var all = _repository.GetAll();

            var dashboard = new UserDashboard
            {
                Total = all.Count(),
                New = all.Count(x => x.RegistryDate > DateTime.Now.AddDays(-7)),
                Active = all.Count(x => x.DisabledDate == null),
                Inactive = all.Count(x => x.DisabledDate != null)
            };

            return dashboard;
        }


        private List<UserSkill> LoadSkills(long idUser)
        {
            var userSkills = _userSkillRepository.GetAllByRelacionalKey(idUser);

            foreach (var userSkill in userSkills)
            {
                userSkill.Skill = _skillRepository.Get(userSkill.IdSkill);
            }

            return userSkills;
        } 
    }
}
