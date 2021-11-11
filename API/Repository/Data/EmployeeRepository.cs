using API.Context;
using API.Models;
using API.Viewmodels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int Register(RegisterVM registerVM)
        {
            var cekNIK = myContext.Employees.Find(registerVM.NIK);
            var cekEmail = myContext.Employees.Where(a => a.Email == registerVM.Email).FirstOrDefault();
            var cekPhone = myContext.Employees.Where(b => b.Phone == registerVM.Phone).FirstOrDefault();

            if (cekNIK != null)
            {
                //Jika nik sama
                return 2;
            }
            else if (cekEmail != null)
            {
                //jika email sama
                return 3;
            }
            else if (cekPhone != null)
            {
                //jika nomer sama
                return 4;
            }
            else
            {
                Employee employee = new Employee()
                {
                    NIK = registerVM.NIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Phone = registerVM.Phone,
                    BirthDate = registerVM.BirthDate,
                    Salary = registerVM.Salary,
                    Email = registerVM.Email,
                    Gender = (Models.Gender)registerVM.Gender
                };
                //insert data ke tabel employee
                myContext.Employees.Add(employee);
                myContext.SaveChanges();

                Account account = new Account()
                {
                    NIK = registerVM.NIK,
                    Password = Hasing.HashPassword(registerVM.Password)
                };
                //insert data ke tabel Account
                myContext.Accounts.Add(account);
                myContext.SaveChanges();

                Education education = new Education()
                {
                    Degree = registerVM.Degree,
                    GPA = registerVM.GPA,
                    UniversityId = registerVM.UniversityId
                };
                //insert data ke tabel Education
                myContext.Educations.Add(education);
                myContext.SaveChanges();

                Profiling profiling = new Profiling()
                {
                    NIK = employee.NIK,
                    EducationId = education.EducationId
                };
                //insert data ke tabel Profiling
                myContext.Profilings.Add(profiling);
                var result = myContext.SaveChanges();

                int cekRole = registerVM.RoleId;
                int roleId;
                if(cekRole == 0)
                {
                    roleId = 1;
                }
                else
                {
                    roleId = cekRole;
                }

                AccountRole accountRole = new AccountRole()
                {
                    NIK = employee.NIK,
                    RoleId = roleId
                };
                myContext.AccountRoles.Add(accountRole);
                myContext.SaveChanges();
                return result;
            }            
        }
        //Tampil data
        public IEnumerable<Register> GetProfile()
        {
            var join = (from em in myContext.Employees
                       join ac in myContext.Accounts
                        on em.NIK equals ac.NIK
                       join pr in myContext.Profilings
                        on em.NIK equals pr.NIK
                       join edu in myContext.Educations
                        on pr.EducationId equals edu.EducationId
                       join uni in myContext.Universities
                        on edu.UniversityId equals uni.UniversityId
                       join acr in myContext.AccountRoles
                        on ac.NIK equals acr.NIK
                       join role in myContext.Roles
                        on acr.RoleId equals role.RoleId
                       select new Register
                       {
                           NIK = em.NIK,
                           FullName = $"{em.FirstName} {em.LastName}",
                           PhoneNumber = em.Phone,
                           BirthDate = em.BirthDate,
                           Salary = em.Salary,
                           Email = em.Email,
                           Gender = (Viewmodels.Gender)em.Gender,
                           Degree = edu.Degree,
                           GPA = edu.GPA,
                           RoleName = role.RoleName,
                           UniversityName = uni.Name
                       });
            return join.ToList();
        }
        //Tampil data berdasarkan NIK
        public IEnumerable<Register> GetProfile(string NIK)
        {
            var join = (from em in myContext.Employees
                        join ac in myContext.Accounts
                         on em.NIK equals ac.NIK
                        join pr in myContext.Profilings
                         on em.NIK equals pr.NIK
                        join edu in myContext.Educations
                         on pr.EducationId equals edu.EducationId
                        join uni in myContext.Universities
                         on edu.UniversityId equals uni.UniversityId
                        join acr in myContext.AccountRoles
                       on ac.NIK equals acr.NIK
                        join role in myContext.Roles
                         on acr.RoleId equals role.RoleId
                        select new Register
                        {
                            NIK = em.NIK,
                            FullName = $"{em.FirstName} {em.LastName}",
                            PhoneNumber = em.Phone,
                            BirthDate = em.BirthDate,
                            Salary = em.Salary,
                            Email = em.Email,
                            Gender = (Viewmodels.Gender)em.Gender,
                            Degree = edu.Degree,
                            GPA = edu.GPA,
                            RoleName = role.RoleName,
                            UniversityName = uni.Name
                        }).Where(em => em.NIK == NIK).ToList();
            return join;
        }
        public string Login(LoginVM loginVM)
        {
            var cekEmail = myContext.Employees.Where(a => a.Email == loginVM.Email).FirstOrDefault();
            //Lakukan Cek Email
            if(cekEmail != null)
            {
                //Lakukan cek password jika email ditemukan
                var nik = cekEmail.NIK;
                var getPassword = myContext.Accounts.Find(nik);
                string pass = getPassword.Password;
                var cekPassword = Hasing.ValidatePassword(loginVM.Password, pass);
                //Lakukan Cek Password
                if(cekPassword == true)
                {       
                    // berhasil login akan me return nilai nik
                    return nik;
                }
                else
                {
                    //jika password salah akan me return hasil nya
                    var result = "password";
                    return result;
                }
            }
            else
            {
                //jika email salah akan me return hasil nya
                var result = "email";
                return result;
            }            
        }
        public int Sign(LoginVM loginVM)
        {
            var cekEmail = myContext.Employees.Where(a => a.Email == loginVM.Email).FirstOrDefault();
            //Lakukan Cek Email
            if (cekEmail != null)
            {
                //Lakukan cek password jika email ditemukan
                var nik = cekEmail.NIK;
                var getPassword = myContext.Accounts.Find(nik);
                string pass = getPassword.Password;
                var cekPassword = Hasing.ValidatePassword(loginVM.Password, pass);
                //Lakukan Cek Password
                if (cekPassword == true)
                {
                    // berhasil login akan me return nilai nik
                    return 1;
                }
                else
                {
                    //jika password salah akan me return hasil nya
                    var result = 0;
                    return result;
                }
            }
            else
            {
                //jika email salah akan me return hasil nya
                var result = 2;
                return result;
            }
        }
        public string[] GetRole(string email)
        {
            var getData = myContext.Employees.Where(a => a.Email == email).FirstOrDefault();
            var getRole = (from acr in myContext.AccountRoles
                           join rol in myContext.Roles
                          on acr.RoleId equals rol.RoleId
                           select new
                           {
                               NIK = acr.NIK,
                               RoleName = rol.RoleName
                           }).Where(acr => acr.NIK == getData.NIK).ToList();
            List<string> result = new List<string>();
            foreach (var item in getRole)
            {
                result.Add(item.RoleName);
            }
            return result.ToArray();
        }
        public int AddManager(AccountRole accountRole)
        {
            try
            {
                myContext.AccountRoles.Add(accountRole);
                var result = myContext.SaveChanges();
                return result;
            }
            catch(Exception)
            {
                return 0;
            }
        }
        public int Hapus(string NIK)
        {
            var dataEdu = myContext.Profilings.Find(NIK);
            var idEdu = dataEdu.EducationId;

            var hapusEdu = myContext.Educations.Find(idEdu);
            myContext.Remove(hapusEdu);
            myContext.SaveChanges();
            var entity = myContext.Employees.Find(NIK);
            myContext.Remove(entity);
            var result = myContext.SaveChanges();
            return result;
        }
        public IEnumerable<GetGender> GetGender()
        {
            var result = from emp in myContext.Employees
                         group emp by emp.Gender into x
                         select new GetGender
                         {
                             Gender = (Viewmodels.Gender)x.Key,
                             Jumlah = x.Count()
                         };
            return result;
        }
        public IEnumerable GetRole()
        {
            var result = from acr in myContext.AccountRoles
                         join rol in myContext.Roles
                        on acr.RoleId equals rol.RoleId
                         group rol by new { rol.RoleId, rol.RoleName } into a
                         select new
                         {
                             roleName = a.Key.RoleName,
                             Jumlah = a.Count()
                         };
            return result;
        }
        public Object[] GetSalary()
        {
            var data = (from e in myContext.Employees
                        select new {
                            Label = "Salary < Rp. 2.000.000",
                            Jumlah = (from emp in myContext.Employees
                                      where emp.Salary < 2000000 select emp.Salary).Count()
                        }).First();
            var data1 = (from e in myContext.Employees
                        select new
                        {
                            Label = "Rp. 2.000.000 - Rp. 5.000.0000",
                            Jumlah = (from emp in myContext.Employees
                                      where emp.Salary >= 2000000 && emp.Salary <= 5000000
                                      select emp.Salary).Count()
                        }).First();
            var data2 = (from e in myContext.Employees
                        select new
                        {
                            Label = "Salary > Rp. 5.000.000",
                            Jumlah = (from emp in myContext.Employees
                                      where emp.Salary > 5000000
                                      select emp.Salary).Count()
                        }).First();

            List<Object> result = new List<Object>();
            result.Add(data);
            result.Add(data1);
            result.Add(data2);

            return result.ToArray();
        }
    }
    public class Hasing
    {
        //menambahkan salt agar hasil hash password yang sama hasilnya berbeda beda
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        //melakukan hash password
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        //melakukan pengecekan hasil hash, Biasanya dilakukan untuk fungsi login
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
