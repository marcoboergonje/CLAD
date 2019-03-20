using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class Message
    {
        [Required(ErrorMessage = "Vul uw vraag in.")]
        [MaxLength(250,ErrorMessage = "Uw vraag is te lang")]
        [MinLength(10,ErrorMessage = "Uw vraag is te kort")]
        public string Content { get; set; }


        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Vul uw email in.")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Vul een geldig email adres in.")]
        public string Email { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vul uw naam in.")]
        [RegularExpression("^[A-Za-z]*$",ErrorMessage = "Vul een geldige naam in.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vul een telefoonummer in.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Vul een geldig nummer in")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Geen geldig nummer.")]
        public string PhoneNumber { get; set; }

        
        public string Answer { get; set; }

    }
}
