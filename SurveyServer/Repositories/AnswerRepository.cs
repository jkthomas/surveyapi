using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;
using SurveyServer.Models.DTO;
using SurveyServer.Utilities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Repositories
{
    public class AnswerRepository
    {
        private readonly SurveyContext _context;
        private readonly ReplyRepository _replyRepository;

        public AnswerRepository(SurveyContext context, ReplyRepository replyRepository)
        {
            _context = context;
            _replyRepository = replyRepository;
        }

        public void SaveAnswer(PostAnswerDto[] answers)
        {
            int oldSessionNumber = 0;
            try
            {
                oldSessionNumber = _context.Answers.Max(ans => ans.SessionNumber);
            }
            catch
            {
                //IF DATABASE HAS NO ENTRIES
            }

            foreach (PostAnswerDto answer in answers)
            {
                _context.Add(new Entity_Answer()
                {
                    QuestionId = answer.QuestionId,
                    ReplyId = answer.ReplyId,
                    ReplyContent = answer.ReplyContent,
                    SessionNumber = (int)oldSessionNumber + 1
                });
            }
            _context.SaveChanges();
        }

        public IEnumerable<GetAnswerDto> GetAnswers()
        {
            List<GetAnswerDto> answerDtos = new List<GetAnswerDto>();
            IEnumerable<Entity_Answer> answers = _context.Answers.ToArray();
            foreach (Entity_Answer answer in answers)
            {
                answerDtos.Add(new GetAnswerDto()
                {
                    QuestionId = answer.QuestionId,
                    ReplyId = answer.ReplyId,
                    ReplyContent = answer.ReplyContent,
                    SessionNumber = answer.SessionNumber
                });
            }

            return answerDtos;
        }
    }
}
