using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test_SqlTblDep_Infrastructure.Entities
{
    public class EyeColor
    {
        [Key]
        public Guid Id { get; set; }
        public string Color { get; set; }
    }
}
