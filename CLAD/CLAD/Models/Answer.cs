using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public Consultant Consultant { get; set; }
        public int ConsultantId { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
    }
}
