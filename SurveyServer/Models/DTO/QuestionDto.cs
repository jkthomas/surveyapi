using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Models.DTO
{
    public class QuestionDto
    {
        public string Content { get; set; }
        public int Type { get; set; }

        public IEnumerable<ReplyDto> Replies { get; set; }
    }
}
