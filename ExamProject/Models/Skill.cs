using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamProject.Models
{
    public class Skill
    {
        //public Skill()
        //{
        //    SkillExperience = new List<SkillExperience>();
        //}
        public int SkillId { get; set; }
        [Display(Name = "Skills")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<SkillExperience> SkillExperience { get; set; }
      
    }
}