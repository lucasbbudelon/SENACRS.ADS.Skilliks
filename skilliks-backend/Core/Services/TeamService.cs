using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class TeamService : ITeamService
    {
        public readonly ITeamRepository _repository;
        public readonly IUserService _userService;
        public readonly IJobRepository _jobRepository;

        public TeamService(ITeamRepository repository, IUserService userService, IJobRepository jobRepository)
        {
            _repository = repository;
            _userService = userService;
            _jobRepository = jobRepository;
        }

        public Team Get(long id)
        {
            var team = _repository.Get(id);

            if (team != null)
            {
                team.Users = _userService.GetAll().Where(x => x.IdTeam == id).ToList();
                team.Jobs = _jobRepository.GetAll().Where(x => x.IdTeam == id).Count();
            }

            return team;
        }

        public List<Team> GetAll()
        {
            var teams = _repository.GetAll();

            if (teams != null)
            {
                foreach (var team in teams)
                {
                    team.Users = _userService.GetAll().Where(x => x.IdTeam == team.Id).ToList();
                    team.Jobs = _jobRepository.GetAll().Where(x => x.IdTeam == team.Id).Count();
                }
            }

            return teams;
        }

        public Team Insert(Team entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(long id, Team entity)
        {
            _repository.Update(id, entity);
        }

        public void Delete(long id)
        {
            _repository.DeleteLogical(id);
        }
    }
}
