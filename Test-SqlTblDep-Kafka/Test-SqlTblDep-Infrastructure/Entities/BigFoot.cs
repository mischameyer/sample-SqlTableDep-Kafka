using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test_SqlTblDep_Infrastructure.Entities
{
    public class BigFoot
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal FootSize { get; set; }
        [ForeignKey("EyeColor")]
        public Guid EyeColor { get; set; }
        public DateTime Birthdate { get; set; }
        public Guid Mom { get; set; }
        public Guid Daddy { get; set; }
        public bool isParent { get; set; }

    }
}
