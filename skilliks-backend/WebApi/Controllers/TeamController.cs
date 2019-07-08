using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Data.Repositories;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: api/Team
        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
        {
            try
            {
                var result = _teamService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public ActionResult<Team> Get(long id)
        {
            try
            {
                var result = _teamService.Get(id);

                if (result == null)
                    return NotFound();
                else
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // POST: api/Team
        [HttpPost]
        public ActionResult Post([FromBody] Team Team)
        {
            try
            {
                _teamService.Insert(Team);
                return Ok(Team);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Team Team)
        {
            try
            {
                _teamService.Update(id, Team);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(long id)
        {
            try
            {
                _teamService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
