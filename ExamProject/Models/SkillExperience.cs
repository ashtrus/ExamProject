using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class SkillExperience
    {
        public int SkillExperienceId { get; set; }
        public int SkillId { get; set; }
        //public int EmployeeId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual Employee Employee{ get; set; }
        public int Experience { get; set; }
    }
}