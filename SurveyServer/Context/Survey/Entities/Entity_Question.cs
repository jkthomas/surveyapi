using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Context.Survey.Entities
{
    public partial class Entity_Question
    {
        public Entity_Question()
        {
            Reply = new HashSet<Entity_Reply>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }

        public ICollection<Entity_Reply> Reply { get; set; }
    }
}
