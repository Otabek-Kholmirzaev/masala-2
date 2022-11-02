using _2_masala_web_api.Models;
using _2_masala_web_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2_masala_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        private readonly JsonRepo _jsonRepo;
        public ProblemsController()
        {
            _jsonRepo = new JsonRepo();
        }

        [HttpGet]
        public IActionResult GetAllResults()
        {
            var results = _jsonRepo.GetDataInJsonFile();
            return Ok(results);
        }

        [HttpPost]
        public IActionResult AddProblem(int a, int b)
        {
            if (a > b)
                return BadRequest();

            var input = a.ToString() + " " + b.ToString();
            var result = ((a + b) * (b - a + 1)) / 2;

            var obj = new Log()
            {
                Input = input,
                Output = result.ToString(),
                Date = DateTime.Now,
            };

            _jsonRepo.SaveDataToJson(obj);

            return Ok();
        }
    }
}
