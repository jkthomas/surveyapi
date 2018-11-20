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
    public class ReplyRepository
    {

        private readonly SurveyContext _context;

        public ReplyRepository(SurveyContext context)
        {
            _context = context;
        }

        public IEnumerable<ReplyDto> GetReplies()
        {
            IEnumerable<ReplyDto> replies = _context.Replies.Select(
                reply => new ReplyDto
                {
                    Id = reply.Id,
                    Content = reply.Content,
                    Type = reply.Type
                });

            return replies;
        }

        public ReplyDto GetReplyAsync(int id)
        {
            ReplyDto reply = new ReplyDto();
            Entity_Reply reply_entity = _context.Replies.Where(r => r.Id == id).FirstOrDefault();

            if (reply_entity != null)
            {
                reply.Id = reply_entity.Id;
                reply.Content = reply_entity.Content;
                reply.Type = reply_entity.Type;
            }

            return reply;
        }

        public IEnumerable<ReplyDto> GetReplyForQuestion(int questionId, int questionType)
        {
            IEnumerable<ReplyDto> replies = null;
            if (questionType == (int)Enum_QuestionType.YesNo)
            {
                replies = _context.Replies.Where(reply => reply.Type == (int)Enum_QuestionType.YesNo).Select(
                reply => new ReplyDto
                {
                    Id = reply.Id,
                    Content = reply.Content,
                    Type = reply.Type
                });
            }
            else if (questionType == (int)Enum_QuestionType.Opened)
            {
                replies = _context.Replies.Where(reply => reply.Type == (int)Enum_QuestionType.Opened).Select(
                reply => new ReplyDto
                {
                    Id = reply.Id,
                    Content = reply.Content,
                    Type = reply.Type
                });
            }
            else
            {
                replies = _context.Replies.Where(reply => reply.QuestionId == questionId && reply.Type == questionType).Select(
                reply => new ReplyDto
                {
                    Id = reply.Id,
                    Content = reply.Content,
                    Type = reply.Type
                });
            }

            return replies;
        }
    }
}
