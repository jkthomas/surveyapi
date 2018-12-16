using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Models.DTO
{
    public class GetAnswerDto
    {
        public int QuestionId { get; set; }
        public int ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public int SessionNumber { get; set; }
    }
}
