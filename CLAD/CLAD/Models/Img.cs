using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class Img
    {
        public int Id { get; set; }
        [DisplayName("Upload afbeelding")]
        public string ImgName { get; set; }
    }
}
