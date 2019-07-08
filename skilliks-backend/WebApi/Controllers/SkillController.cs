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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: api/Skill
        [HttpGet]
        public ActionResult<IEnumerable<Skill>> Get()
        {
            try
            {
                var result = _skillService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/Skill/5
        [HttpGet("{id}")]
        public ActionResult<Skill> Get(long id)
        {
            try
            {
                var result = _skillService.Get(id);

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

        // POST: api/Skill
        [HttpPost]
        public ActionResult Post([FromBody] Skill Skill)
        {
            try
            {
                _skillService.Insert(Skill);
                return Ok(Skill);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/Skill/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Skill Skill)
        {
            try
            {
                _skillService.Update(id, Skill);
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
                _skillService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
