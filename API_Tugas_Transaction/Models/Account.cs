using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Tugas_Transaction.Models
{
    [Table("Tbl_Account")]
    public class Account
    {
        [Key][ForeignKey("Employee")]
        public int Id { set; get; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        public virtual Employee Employee { set; get; }
    }
}