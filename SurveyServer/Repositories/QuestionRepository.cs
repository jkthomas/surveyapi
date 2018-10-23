using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;
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
            return _context.Questions;
        }

        public Entity_Question GetQuestion(int id)
        {
            return _context.Questions.Where(question => question.Id == id).FirstOrDefault();
        }
    }
}
