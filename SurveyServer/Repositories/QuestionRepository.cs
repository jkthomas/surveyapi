using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;
using SurveyServer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Repositories
{
    public class QuestionRepository
    {
        private readonly SurveyContext _context;
        private readonly ReplyRepository _replyRepository;

        public QuestionRepository(SurveyContext context, ReplyRepository replyRepository)
        {
            _context = context;
            _replyRepository = replyRepository;
        }

        public IEnumerable<Entity_Question> GetAllQuestions()
        {
            IEnumerable<Entity_Question> questions = _context.Questions.ToArray();

            return questions;
        }

        public Entity_Question GetQuestion(int id)
        {
            Entity_Question question = _context.Questions.Where(q => q.Id == id).FirstOrDefault();

            return question;
        }
    }
}
