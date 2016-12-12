using System.Collections.Generic;

namespace ExamProject.Models
{
    public class Skill
    {

        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}