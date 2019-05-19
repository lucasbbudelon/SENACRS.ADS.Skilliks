using Core.Services;
using Data.Migration;
using Data.Repositories;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Infra;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    public class InfraController : ControllerBase
    {
        private readonly Random _random;

        private readonly ISkillRepository _skillRepository;
        private readonly ISkillService _skillService;

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSkillRepository _userSkillRepository;

        private readonly IJobService _jobService;
        private readonly IJobRepository _jobRepository;
        private readonly IJobSkillRepository _jobSkillRepository;

        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IJobApplicantService _jobApplicantService;

        public InfraController()
        {
            _random = new Random();

            _skillRepository = new SkillRepository();
            _skillService = new SkillService(_skillRepository);

            _userSkillRepository = new UserSkillRepository();
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository, _userSkillRepository, _skillRepository);

            _jobSkillRepository = new JobSkillRepository();
            _jobRepository = new JobRepository();
            _jobService = new JobService(_jobRepository, _jobSkillRepository, _skillRepository);

            _jobApplicantRepository = new JobApplicantRepository();
            _jobApplicantService = new JobApplicantService(_jobApplicantRepository, _userService, _jobService);
        }

        [HttpPost]
        [Route("api/Infra/Migration")]
        public ActionResult Migration([FromBody] Migration migration)
        {
            try
            {
                var migrationRun = new MigrationRun(migration);
                migrationRun.Execute();
                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        [HttpPost]
        [Route("api/Infra/Mock")]
        public ActionResult Mock()
        {
            try
            {
                LoadMockSkills();
                LoadMockUsers();
                LoadMockJobs();
                LoadJobApplicant();

                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        private void LoadMockSkills()
        {
            foreach (var item in _skillRepository.GetAll())
            {
                _skillRepository.DeletePhysical(item.Id);
            }

            string[] skills = {
                "Angular", "React", "Java Script", "Type Script",
                "HTML 5", "CSS/Sass", "Bootstrap",
                ".net C#", ".net Core",
                "Java", "PHP", "NodeJS", "Scrum", "Sql", "DevOps",
                "User Experience (UX)", "Eser Interface (UI)"
            };

            foreach (var name in skills)
            {
                _skillService.Insert(new Skill()
                {
                    Name = name
                });
            }
        }

        private void LoadMockUsers()
        {
            int maximumUserSkillValue = 10;


            foreach (var item in _userRepository.GetAll())
            {
                _userSkillRepository.DeletePhysicalByRelacionalKey(item.Id);
                _userRepository.DeletePhysical(item.Id);
            }

            var skills = _skillRepository.GetAll();

            string[] names = {
                "Ricardo Guilherme Silveira", "Fernando Carlos Eduardo da Mota", "Danilo Marcos Vinicius Farias",
                "Geraldo Samuel Igor da Costa", "Gabriel Ricardo Danilo de Paula", "Arthur Marcos da Cunha",
                "Davi Augusto Moreira", "Hugo Manuel Pietro Ribeiro", "Emanuel Levi da Rocha",
                "Lorenzo Arthur da Mata", "Benjamin Iago Igor da Costa", "Diogo Theo da Cunha",
                "Milena Sophie Manuela Gomes", "Laura Nair Elisa da Costa", "Vanessa Joana Brenda Pires",
                "Antonella Brenda Emanuelly Costa", "Sueli Sara Melo", "Isabel Julia Aline Duarte",
                "Brenda Helena Isabelle Moreira", "Aparecida Isis Alves", "Maria Heloisa Pinto",
                "Maria Stella Bianca Teixeira", "Sarah Beatriz Sales", "Clarice Marcia da Cunha"
             };

            foreach (var name in names)
            {
                var newUser = new User()
                {
                    Name = name,
                    Email = GenerateEmail(name),
                    Category = GenerateUserCategory(),
                    Type = GenerateUserType(),
                    LastSalary = RamdomValue(),
                    Skills = new List<UserSkill>()
                };

                for (int i = 0; i < _random.Next(1, maximumUserSkillValue); i++)
                {
                    var idSkill = skills[_random.Next(skills.Count)].Id;
                    if (!newUser.Skills.Any(x => x.IdSkill == idSkill))
                    {
                        newUser.Skills.Add(new UserSkill()
                        {
                            IdSkill = idSkill,
                            Ranking = _random.Next(1, 5)
                        });
                    }
                }

                _userService.Insert(newUser);
            }
        }

        private void LoadMockJobs()
        {
            int maximumNumberOfJobs = 10;
            int maximumJobSkillValue = 10;

            foreach (var item in _jobRepository.GetAll())
            {
                _jobSkillRepository.DeletePhysicalByRelacionalKey(item.Id);
                _jobRepository.DeletePhysical(item.Id);
            }

            var skills = _skillRepository.GetAll();

            for (int i = 0; i < _random.Next(1, maximumNumberOfJobs); i++)
            {
                Level level = GenerateLevel();

                var newJob = new Job()
                {
                    Name = string.Format("Desenvolvedor {0}", GetLevelName(level)),
                    Description = "Desenvolvimento de novas aplicação com foco no usuário.",
                    Level = level,
                    Remuneration = RamdomValue(),
                    Skills = new List<JobSkill>()
                };

                for (int j = 0; j < _random.Next(1, maximumJobSkillValue); j++)
                {
                    var idSkill = skills[_random.Next(skills.Count)].Id;
                    if (!newJob.Skills.Any(x => x.IdSkill == idSkill))
                    {
                        newJob.Skills.Add(new JobSkill()
                        {
                            IdSkill = idSkill,
                            Ranking = _random.Next(1, 5)
                        });
                    }
                }

                _jobService.Insert(newJob);
            }
        }

        private void LoadJobApplicant()
        {
            int numberJobApplicants = 25;

            var users = _userRepository.GetAll();
            var jobs = _jobRepository.GetAll();

            for (int i = 0; i < numberJobApplicants; i++)
            {
                _jobApplicantRepository.Insert(new JobApplicant()
                {
                    IdApplicant = users[_random.Next(users.Count)].Id,
                    IdJob = jobs[_random.Next(jobs.Count)].Id,
                    SalaryClaim = RamdomValue()
                });
            }
        }

        #region random data

        private bool RandomBool()
        {
            return _random.Next(2) == 0;
        }

        private string GenerateEmail(string name)
        {
            string nickName = name.Replace(" ", "").ToLower();
            string company;

            switch (_random.Next(2))
            {
                case 0:
                    company = "@gmail.com";
                    break;
                case 1:
                    company = "@outlook.com";
                    break;
                case 2:
                    company = "@yahoo.com";
                    break;

                default:
                    company = "@gmail.com";
                    break;
            }

            return string.Concat(nickName, company);
        }

        private UserCategory GenerateUserCategory()
        {
            switch (_random.Next(5))
            {
                case 1: return UserCategory.HumanResources;
                default: return UserCategory.Technical;
            }
        }

        private UserType GenerateUserType()
        {
            return RandomBool()
                ? UserType.Applicant
                : UserType.Employee;
        }

        private Level GenerateLevel()
        {
            switch (_random.Next(4))
            {
                case 0: return Level.Junior;
                case 1: return Level.Full;
                case 2: return Level.Senior;
                case 3: return Level.Trainee;
                default: return Level.Full;
            }
        }

        private string GetLevelName(Level level)
        {
            switch (level)
            {
                case Level.Junior: return "Júnior";
                case Level.Full: return "Pleno";
                case Level.Senior: return "Sênior";
                case Level.Trainee: return "Estagiário";
                default: return "Pleno";
            }
        }

        private double RamdomValue()
        {
            double value = _random.Next(1, 10) * 1000;

            switch (_random.Next(5))
            {
                case 0: return value *= 0.25;
                case 1: return value *= 0.5;
                case 2: return value *= 0.75;
                default: return value;
            }
        }

        #endregion
    }
}
