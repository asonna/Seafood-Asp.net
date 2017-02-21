using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SonOfCodSeafood.Models
{
    [Table("Members")]
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Role { get; set; }
        public virtual ApplicationUser User { get; set; }

    }

}
