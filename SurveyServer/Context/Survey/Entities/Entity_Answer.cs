using System;
using System.Collections.Generic;

namespace SurveyServer.Context.Survey.Entities
{
    public partial class Entity_Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public int SessionNumber { get; set; }

        public Entity_Question Question { get; set; }
        public Entity_Reply Reply { get; set; }
    }
}
