using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class Question
    {
        public List<Answer> answers { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
        public bool IsVisible { get; set; }
        public DateTime PublicaionDate { get; set; }
        public List<QuestionTag> questionTags { get; set; }
        public string Title { get; set; }
    }
}
