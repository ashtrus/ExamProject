using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here


            return userIdentity;
        }

        // [Required(ErrorMessage = "FirstName is requiered")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is requiered")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email is requiered")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; } // file upload

        public virtual ICollection<SkillExperience> SkillExperience { get; set; }
        public virtual ICollection<CompanyRole> CompanyRoles { get; set; }

        public virtual Skill Skill { get; set; }  // relationship

        public CompanyRole[] CurrentRoles = new CompanyRole[3];  // show level for each skill. how??



    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() //constructor
            : base("DefaultConnection", throwIfV1Schema: false)  // configure connection and create database
        {
        }

        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyRole> CompanyRoles { get; set; }
        public DbSet<Tag> Tags { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ExamProject.Models.Skill> Skills { get; set; }
    }
}



