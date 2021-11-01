using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    // Memberi nama Tabel
    [Table("Tb_M_Employee")]
    public class Employee
    {
        // Keyword [Key] menandakan bahwa itu Primary Key (NIK)
        [Key]
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual Account account { get; set; }

        // merubah enum menjadi string jika 0 (male) dan 1 (female)
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }
}
