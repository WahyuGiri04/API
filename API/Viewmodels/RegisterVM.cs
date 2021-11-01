using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Viewmodels
{
    public class RegisterVM
    {
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        // merubah enum menjadi string jika 0 (male) dan 1 (female)
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }

        public string Password { get; set; }

        public string Degree { get; set; }
        public string GPA { get; set; }

        public int UniversityId { get; set; }
        public int RoleId { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }
    public class Register
    {
        public string NIK { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        // merubah enum menjadi string jika 0 (male) dan 1 (female)
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }

        public string Degree { get; set; }
        public string GPA { get; set; }
        public string RoleName { get; set; }
        public string UniversityName { get; set; }
    }
}
