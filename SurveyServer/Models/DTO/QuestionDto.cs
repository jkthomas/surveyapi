using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Models.DTO
{
    public class QuestionDto
    {
        public string Contento { get; set; }
        public int Typeo { get; set; }

        public IEnumerable<ReplyDto> Replies { get; set; }
    }
}
