using GtRacingNews.Data.DataModels;
using GtRacingNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrieveData : ControllerBase
    {
        private readonly IRepository repository;
        public RetrieveData (IRepository repository) => this.repository = repository;

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            return Ok(repository.GettAll<Team>());
        }
    }
}
