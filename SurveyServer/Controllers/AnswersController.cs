using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SurveyServer.Models.DTO;
using SurveyServer.Repositories;

namespace SurveyServer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CORS")]
    public class AnswersController : Controller
    {
        private readonly AnswerRepository _answerRepository;

        public AnswersController(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        //JSON only
        [HttpPost]
        public IActionResult Post([FromBody] AnswerDto[] answers)
        {
            _answerRepository.SaveAnswer(answers);
            return Json(answers);
        }
    }
}