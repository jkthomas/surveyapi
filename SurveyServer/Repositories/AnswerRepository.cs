using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;
using SurveyServer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Repositories
{
    public class AnswerRepository
    {
        private readonly SurveyContext _context;

        public AnswerRepository(SurveyContext context)
        {
            _context = context;
        }

        public void SaveAnswer(AnswerDto[] answers)
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

            foreach (AnswerDto answer in answers)
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
    }
}
