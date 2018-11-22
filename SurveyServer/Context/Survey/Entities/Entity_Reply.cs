using System;
using System.Collections.Generic;

namespace SurveyServer.Context.Survey.Entities
{
    public partial class Entity_Reply
    {
        public Entity_Reply()
        {
            TableAnswer = new HashSet<Entity_Answer>();
        }

        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }

        public Entity_Question Question { get; set; }
        public ICollection<Entity_Answer> TableAnswer { get; set; }
    }
}
