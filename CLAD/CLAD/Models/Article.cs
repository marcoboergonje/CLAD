﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class Article
    {
        public Consultant Consultant { get; set; }
        public int ConsultantId { get; set; }
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public bool IsVisible { get; set; }
        public string Title { get; set; }
        public List<ArticleTag> Tags { get; set; }
        public List<ArticleComment> Comments { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
