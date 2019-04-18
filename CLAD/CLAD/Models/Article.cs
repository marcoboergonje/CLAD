using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public Consultant consultant { get; set; }
        public string Content { get; set; }
        public bool IsVisible { get; set; }
        public string Title { get; set; }
        public List<ArticleTag> Tags { get; set; }
        public List<ArticleComment> Comments { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
