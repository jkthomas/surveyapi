using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;
using SurveyServer.Models.DTO;
using SurveyServer.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//https://localhost:44329/api/questions

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
        [EnableCors("MyPolicy")]
        public IActionResult Get()
        {
            IEnumerable<Entity_Question> questions = _questionRepository.GetAllQuestions();
            List<QuestionDto> questionsDtos = new List<QuestionDto>();
            if (!questions.Any())
            {
                return BadRequest();
            }
            
            foreach (Entity_Question question in questions)
            {
                questionsDtos.Add(new QuestionDto()
                {
                    Contento = question.Content,
                    Typeo = question.Type,
                    Replies = _replyRepository.GetReplyForQuestion(question.Id, question.Type).ToArray()
                });
            }

            return Json(questionsDtos);
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

            QuestionDto questionDto = new QuestionDto()
            {
                Contento = question.Content,
                Typeo = question.Type,
                Replies = _replyRepository.GetReplyForQuestion(question.Id, question.Type).ToArray()
            };

            return Json(questionDto);
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
