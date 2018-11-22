using System;
using System.Collections.Generic;

namespace SurveyServer.Context.Survey.Entities
{
    public partial class Entity_Question
    {
        public Entity_Question()
        {
            TableAnswer = new HashSet<Entity_Answer>();
            TableReply = new HashSet<Entity_Reply>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }

        public ICollection<Entity_Answer> TableAnswer { get; set; }
        public ICollection<Entity_Reply> TableReply { get; set; }
    }
}
