using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyServer.Models.DTO;
using SurveyServer.Repositories;

namespace SurveyServer.Controllers
{
    [Route("api/[controller]")]
    public class AnswersController : Controller
    {
        private readonly AnswerRepository _answerRepository;

        public AnswersController(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        //JSON only
        [HttpPost]
        public IActionResult Post([FromBody][Bind("QuestionId, ReplyId, ReplyContent")] AnswerDto answer)
        {
            _answerRepository.SaveAnswer(answer);
            return Json(answer);
        }
    }
}