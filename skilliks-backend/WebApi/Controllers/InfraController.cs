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

        public InfraController(
            ISkillRepository skillRepository,
            ISkillService skillService,
            IUserService userService,
            IUserRepository userRepository,
            IUserSkillRepository userSkillRepository,
            IJobService jobService,
            IJobRepository jobRepository,
            IJobSkillRepository jobSkillRepository,
            IJobApplicantRepository jobApplicantRepository,
            IJobApplicantService jobApplicantService
        )
        {
            _random = new Random();

            _skillRepository = skillRepository;
            _skillService = skillService;

            _userSkillRepository = userSkillRepository;
            _userRepository = userRepository;
            _userService = userService;

            _jobSkillRepository = jobSkillRepository;
            _jobRepository = jobRepository;
            _jobService = jobService;

            _jobApplicantRepository = jobApplicantRepository;
            _jobApplicantService = jobApplicantService;
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
                "User Experience (UX)", "User Interface (UI)"
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
            int numberMaximumUserSkill = 10;

            foreach (var item in _userRepository.GetAll())
            {
                _userSkillRepository.DeletePhysicalByRelacionalKey(item.Id);
                _userRepository.DeletePhysical(item.Id);
            }

            var skills = _skillRepository.GetAll();

            string[] maleFirstNames = {
                "Ricardo", "Fernando", "Danilo", "Guilherme", "Carlos", "Samuel", "Igor","Marcos","Augusto","Manuel",
                "Geraldo", "Gabriel", "Arthur", "Theo", "Davi", "Hugo", "Emanuel", "Lorenzo", "Benjamin", "Diogo"
             };

            string[] femaleFirstNames = {
                "Milena", "Laura", "Vanessa","Sophie", "Manuela", "Elisa", "Joana","Brenda", "Emanuelly", "Antonella",
                "Sueli", "Isabel", "Aline", "Julia","Helena", "Isabelle", "Maria", "Sarah", "Brenda", "Isis"
             };

            string[] middleNames = {
                "Silveira", "Moreira", "Farias", "Pietro", "Ribeiro",
                "Levi", "Gomes", "Pires", "Nair", "Costa",
                "Pinto", "Silva", "Severo", "Marques", "Santos"
            };

            string[] lastNames = {
                "da Costa", "da Mota", "de Paula", "da Cunha", "da Rocha",
                "da Mata", "Melo", "Duarte", "Aparecida", "Alves",
                "Teixeira", "Sales", "da Silva", "Campos","Moura"
            };

            for (int i = 1; i <= 20; i++)
            {
                bool isMale = i <= 10;

                var firstName = isMale
                    ? maleFirstNames[_random.Next(maleFirstNames.Length)]
                    : femaleFirstNames[_random.Next(femaleFirstNames.Length)];

                string name = string.Format("{0} {1} {2}",
                    firstName,
                    middleNames[_random.Next(middleNames.Length)],
                    lastNames[_random.Next(lastNames.Length)]);

                var newUser = new User()
                {
                    Image = string.Format("assets/img/users/{0}.jpg", i),
                    Name = name,
                    Description = RamdomDescription(),
                    Birthday = RamdomBirthday(),
                    Email = GenerateEmail(name),
                    Phone = RamdomPhone(),
                    Address = RamdomAddress(),
                    Type = GenerateUserType(),
                    Category = GenerateUserCategory(),
                    CurrentPosition = RamdomPosition(),
                    CurrentCompany = RamdomCompany(),
                    CurrentWage = RamdomValue(),
                    Skills = new List<UserSkill>()
                };

                for (int j = 0; j < _random.Next(1, numberMaximumUserSkill); j++)
                {
                    var idSkill = skills[_random.Next(skills.Count)].Id;

                    if (newUser.Skills.Any(x => x.IdSkill == idSkill))
                    {
                        j--;
                    }
                    else
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
            int maximumNumberOfJobs = 20;
            int maximumNumberJobSkill = 10;

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

                var numberJobSkill = _random.Next(1, maximumNumberJobSkill);

                for (int j = 0; j < numberJobSkill; j++)
                {
                    var idSkill = skills[_random.Next(skills.Count)].Id;

                    if (newJob.Skills.Any(x => x.IdSkill == idSkill))
                    {
                        j--;
                    }
                    else
                    {
                        newJob.Skills.Add(new JobSkill()
                        {
                            IdSkill = idSkill,
                            Ranking = _random.Next(1, 5),
                            Weight = 100 / numberJobSkill
                        });
                    }
                }

                _jobService.Insert(newJob);
            }
        }

        private void LoadJobApplicant()
        {
            int numberJobApplicants = 20;

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

        private string RamdomDescription()
        {
            string[] descriptions = {
                "Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja de tipos e os embaralhou para fazer um livro de modelos de tipos. Lorem Ipsum sobreviveu não só a cinco séculos, como também ao salto para a editoração eletrônica, permanecendo essencialmente inalterado. Se popularizou na década de 60, quando a Letraset lançou decalques contendo passagens de Lorem Ipsum, e mais recentemente quando passou a ser integrado a softwares de editoração eletrônica como Aldus PageMaker.",
                "Ao contrário do que se acredita, Lorem Ipsum não é simplesmente um texto randômico. Com mais de 2000 anos, suas raízes podem ser encontradas em uma obra de literatura latina clássica datada de 45 AC. Richard McClintock, um professor de latim do Hampden-Sydney College na Virginia, pesquisou uma das mais obscuras palavras em latim, consectetur, oriunda de uma passagem de Lorem Ipsum, e, procurando por entre citações da palavra na literatura clássica, descobriu a sua indubitável origem. Lorem Ipsum vem das seções 1.10.32 e 1.10.33 do 'de Finibus Bonorum et Malorum' (Os Extremos do Bem e do Mal), de Cícero, escrito em 45 AC. Este livro é um tratado de teoria da ética muito popular na época da Renascença. A primeira linha de Lorem Ipsum, 'Lorem Ipsum dolor sit amet...' vem de uma linha na seção 1.10.32.",
                "É um fato conhecido de todos que um leitor se distrairá com o conteúdo de texto legível de uma página quando estiver examinando sua diagramação. A vantagem de usar Lorem Ipsum é que ele tem uma distribuição normal de letras, ao contrário de 'Conteúdo aqui, conteúdo aqui', fazendo com que ele tenha uma aparência similar a de um texto legível. Muitos softwares de publicação e editores de páginas na internet agora usam Lorem Ipsum como texto-modelo padrão, e uma rápida busca por 'lorem ipsum' mostra vários websites ainda em sua fase de construção. Várias versões novas surgiram ao longo dos anos, eventualmente por acidente, e às vezes de propósito (injetando humor, e coisas do gênero).",
                "Existem muitas variações disponíveis de passagens de Lorem Ipsum, mas a maioria sofreu algum tipo de alteração, seja por inserção de passagens com humor, ou palavras aleatórias que não parecem nem um pouco convincentes. Se você pretende usar uma passagem de Lorem Ipsum, precisa ter certeza de que não há algo embaraçoso escrito escondido no meio do texto. Todos os geradores de Lorem Ipsum na internet tendem a repetir pedaços predefinidos conforme necessário, fazendo deste o primeiro gerador de Lorem Ipsum autêntico da internet. Ele usa um dicionário com mais de 200 palavras em Latim combinado com um punhado de modelos de estrutura de frases para gerar um Lorem Ipsum com aparência razoável, livre de repetições, inserções de humor, palavras não características, etc.",
            };

            return descriptions[_random.Next(descriptions.Length)];
        }

        private DateTime RamdomBirthday()
        {
            return DateTime.Now.AddYears(-30).AddYears(_random.Next(10));
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

        private string RamdomPhone()
        {
            return string.Format("51 9{0}{1}{2}{3} {4}{5}{6}{7}",
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10));
        }

        private string RamdomAddress()
        {
            string[] address = {
                "Av. Alberto Bins",
                "Av. Borges de Medeiros",
                "Av. Desembargador André da Rocha",
                "Av. Independência",
                "Av. João Pessoa",
                "Av. Júlio de Castilhos",
                "Av. Loureiro da Silva",
                "Av. Mauá",
                "Rua Coronel Genuíno",
                "Rua Coronel Vicente",
                "Rua dos Andradas",
                "Rua Doutor Flores",
                "Rua Duque de Caxias",
            };

            return string.Format("{0}, {1} - Centro - Porto Alegre/RS", address[_random.Next(address.Length)], _random.Next(000, 9999).ToString());
        }

        private string RamdomPosition()
        {
            switch (_random.Next(4))
            {
                case 0: return "Desenvolvedor frontend";
                case 1: return "Desenvolvedor backend";
                default: return "Desenvolvedor full stack";
            }
        }

        private string RamdomCompany()
        {
            switch (_random.Next(5))
            {
                case 0: return "Empresa Azul";
                case 1: return "Empresa Verde";
                case 2: return "Empresa Vermelho";
                case 3: return "Empresa Branco";
                default: return "Empresa Preto";
            }
        }

        #endregion
    }
}
