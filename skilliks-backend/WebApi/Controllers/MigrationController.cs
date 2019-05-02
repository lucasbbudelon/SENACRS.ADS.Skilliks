using System;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        // POST api/migration
        [HttpPost]
        public ActionResult<Migration> Post([FromBody] Migration migration)
        {
            try
            {
                var repository = new Repository.Repositories.MigrationRepository();
                repository.Execute(migration);
                return Ok("\\O/");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            } 
        }
    }
}
