using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Models.DTO
{
    public class StatisticsDto
    {
        public string QuestionContent { get; set; }
        public Dictionary<string,int> AnswerStatistics { get; set; }
    }
}
