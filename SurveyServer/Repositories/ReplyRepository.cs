using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;
using SurveyServer.Utilities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Repositories
{
    public class ReplyRepository
    {

        private readonly SurveyContext _context;

        public ReplyRepository(SurveyContext context)
        {
            _context = context;
        }

        public IEnumerable<Entity_Reply> GetReplies()
        {
            return _context.Replies;
        }

        public async Task<Entity_Reply> GetReplyAsync(int id)
        {
            return await _context.Replies.FindAsync(id);
        }

        public IEnumerable<Entity_Reply> GetReplyForQuestion(int questionId, int questionType)
        {
            IEnumerable<Entity_Reply> replies = null;
            if (questionType == (int)Enum_QuestionType.YesNo)
            {
                replies = _context.Replies.Where(reply => reply.Type == (int)Enum_QuestionType.YesNo);
            }
            else if (questionType == (int)Enum_QuestionType.Opened)
            {
                replies = _context.Replies.Where(reply => reply.Type == (int)Enum_QuestionType.Opened);
            }
            else
            {
                replies = _context.Replies.Where(reply => reply.QuestionId == questionId && reply.Type == questionType);
            }

            foreach (Entity_Reply reply in replies)
            {
                reply.Question = null;
            }

            return replies;
        }
    }
}
