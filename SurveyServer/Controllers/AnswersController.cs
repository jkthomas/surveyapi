using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SurveyServer.Models.DTO;
using SurveyServer.Repositories;
using SurveyServer.Utilities.Enum;

namespace SurveyServer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CORS")]
    public class AnswersController : Controller
    {
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;

        public AnswersController(AnswerRepository answerRepository, QuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        //JSON only
        //POST: api/answers
        [HttpPost]
        public IActionResult Post([FromBody] PostAnswerDto[] answers)
        {
            _answerRepository.SaveAnswer(answers);
            return Json(answers);
        }

        //GET: api/answers
        [HttpGet]
        public IActionResult GetAnswersStatistics()
        {
            IEnumerable<GetAnswerDto> answers = _answerRepository.GetAnswers();
            List<StatisticsDto> statistics = new List<StatisticsDto>();

            var groupedAnswers = answers.OrderBy(ans => ans.QuestionId).GroupBy(ans => ans.QuestionId).Where(group => group.Key != (int)Enum_QuestionType.Opened).ToArray();
            foreach (IGrouping<int, GetAnswerDto> questionAnswer in groupedAnswers)
            {
                var groupedReplies = questionAnswer.OrderBy(reply => reply.ReplyContent).GroupBy(reply => reply.ReplyContent).ToArray();
                Dictionary<string, int> answersInstances = new Dictionary<string, int>();
                foreach(IGrouping<string, GetAnswerDto> reply in groupedReplies)
                {
                    answersInstances.Add(reply.Key, reply.ToArray().Length);
                }

                statistics.Add(new StatisticsDto()
                {
                    QuestionContent = _questionRepository.GetQuestion(questionAnswer.Key).Content,
                    AnswerStatistics = answersInstances
                });
            }

            return Json(statistics);
        }
    }
}