using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class Role
    {
        public int RoleId { get; set; } //Primary Key 
        //public int UserId { get; set; } //User 
        public string Title { get; set; } // title 
        public string Description { get; set; } //Desc
        //public int Experience { get; set; }  // number of years
        public DateTime SelectedOn { get; set; }  // date when role was selected

        public virtual List<Tag> Tags { get; set; } // to group similar roles
        public virtual List<string> Curriculum { get; set; } // wikipedia links, books, youtube/vimeo videos
        public virtual List<Achievement> Achievements { get; set; }  // achievements to a Role ranging from the first encounter by the novice to mastery
    }
}