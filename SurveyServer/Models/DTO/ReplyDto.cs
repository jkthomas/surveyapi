﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Models.DTO
{
    public class ReplyDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
    }
}
