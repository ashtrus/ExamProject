using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class CompanyRole
    {
        public int CompanyRoleId { get; set; } //Primary Key 
        //public int UserId { get; set; } //User 
        public string Title { get; set; } // title 
        public string Description { get; set; } //Desc
        public string FirstFutureFocus { get; set; }    //Future focous skils 1. 
        public string SecondFutureFocus { get; set; }   //Future focous skils 2. 
        public string ThirdFutureFocus { get; set; }    //Future focous skils 3. 
        //public int Experience { get; set; }  // number of years
        [Display(Name = "Creation date")]
        public DateTime SelectedOn { get; set; }  // date when role was selected
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Tag> Tags { get; set; } // to group similar roles
        [Display(Name = "Comments")]
        public virtual List<RoleComment> RoleComments { get; set; } // comments and curriculum for a particilar role
        public virtual List<string> Curriculum { get; set; } // wikipedia links, books, youtube/vimeo videos
        public virtual List<Achievement> Achievements { get; set; }  // achievements to a Role ranging from the first encounter by the novice to mastery
    }
}