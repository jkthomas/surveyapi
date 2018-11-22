using SurveyServer.Context;
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

        public void SaveAnswer(AnswerDto answer)
        {
            int oldSessionNumber = _context.Answers.Max(ans => ans.SessionNumber);
            answer.SessionNumber = oldSessionNumber + 1;

            _context.Add(answer);
            _context.SaveChanges();
        }
    }
}
