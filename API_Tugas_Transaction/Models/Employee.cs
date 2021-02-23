using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Tugas_Transaction.Models
{
    [Table("Tbl_M_Employee")]
    public class Employee
    {
        [Key]
        public int Id { set; get; }

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Name must be Alphabet")]
        [DisplayName("Full Name")]
        public string FullName { set; get; }

        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { set; get; }

        public string Phone { set; get; }

        public string Address { set; get; }

        public string Email { set; get; }
    }
}