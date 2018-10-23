using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;
using SurveyServer.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyServer.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private readonly QuestionRepository _questionRepository;
        private readonly ReplyRepository _replyRepository;

        public QuestionsController(QuestionRepository questionRepository, ReplyRepository replyRepository)
        {
            _questionRepository = questionRepository;
            _replyRepository = replyRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Entity_Question> questions = _questionRepository.GetAllQuestions();
            if (!questions.Any())
            {
                return BadRequest();
            }

            foreach (Entity_Question question in questions)
            {
                question.Reply = _replyRepository.GetReplyForQuestion(question.Id, question.Type).ToArray();
            }

            return Json(questions);
        }

        // GET api/<controller>/5
        [HttpGet("{questionId}")]
        public IActionResult Get(int questionId)
        {
            Entity_Question question = _questionRepository.GetQuestion(questionId);
            if(question == null)
            {
                return BadRequest();
            }

            question.Reply = _replyRepository.GetReplyForQuestion(question.Id, question.Type).ToArray();

            return Json(question);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
