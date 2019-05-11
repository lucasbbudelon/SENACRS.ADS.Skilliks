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

namespace WebApi.Controllers
{
    [ApiController]
    public class InfraController : ControllerBase
    {
        private readonly Random _random;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillService _skillService;
        private readonly IUserSkillRepository _userSkillRepository;

        public InfraController()
        {
            _random = new Random();
            _skillRepository = new SkillRepository();
            _skillService = new SkillService(_skillRepository);
            _userSkillRepository = new UserSkillRepository();
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository, _userSkillRepository, _skillRepository);
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

                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }


        private readonly string[] names = {
            "Ricardo Guilherme Silveira",
            "Fernando Carlos Eduardo da Mota",
            "Danilo Marcos Vinicius Farias",
            "Geraldo Samuel Igor da Costa",
            "Gabriel Ricardo Danilo de Paula",
            "Arthur Marcos da Cunha",
            "Davi Augusto Moreira",
            "Hugo Manuel Pietro Ribeiro",
            "Emanuel Levi da Rocha",
            "Lorenzo Arthur da Mata",
            "Milena Sophie Manuela Gomes",
            "Laura Nair Elisa da Costa",
            "Vanessa Joana Brenda Pires",
            "Antonella Brenda Emanuelly Costa",
            "Sueli Sara Melo",
            "Isabel Julia Aline Duarte",
            "Brenda Helena Isabelle Moreira",
            "Aparecida Isis Alves",
            "Maria Heloisa Pinto",
            "Maria Stella Bianca Teixeira",
         };

        private readonly string[] skills = {
            "Angular 4+",
            "HTML 5",
            ".NET C#",
            "CSS/Sass",
            "Bootstrap",
            "Scrum",
            "Java Script",
            "Java"
        };


        private void LoadMockSkills()
        {
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
            foreach (var name in names)
            {
                var newUser = new User()
                {
                    Name = name,
                    Email = GenerateEmail(name),
                    Category = UserCategory.Technical,
                    Type = UserType.Applicant,
                    Skills = new List<UserSkill>()
                };

                for (int i = 0; i < _random.Next(1, 5); i++)
                {
                    newUser.Skills.Add(new UserSkill()
                    {
                        IdSkill = _random.Next(1, skills.Length),
                        Ranking = _random.Next(1, 5)
                    });
                }

                _userService.Insert(newUser);
            }
        }

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
    }
}
