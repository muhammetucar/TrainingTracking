using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingTracking.Entities;
using TrainingTracking.Services.Exercise;

namespace TrainingTracking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService) => _exerciseService = exerciseService;

        [HttpGet]
        [Route("exercise")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_exerciseService.GetById(id));
        }

        [HttpGet]
        [Route("exercises")]
        public IActionResult Get()
        {
            return new JsonResult(_exerciseService.GetAll());
        }

        [HttpGet]
        [Route("user/exercises")]
        public IActionResult GetByUserId(int userId)
        {
            return new JsonResult(_exerciseService.GetAllByUserId(userId));
        }

        [HttpPost]
        public IActionResult Post(Exercise exercise)
        {
            return new JsonResult(_exerciseService.Create(exercise));
        }

        [HttpPut]
        public IActionResult Put(Exercise exercise)
        {
            exercise.UserId = int.Parse(User.Claims
                .First(i => i.Type == ClaimTypes.Sid).Value);

            return new JsonResult(_exerciseService.Update(exercise));
        }
    }
}