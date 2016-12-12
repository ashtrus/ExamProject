using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }  // number of years
        public DateTime SelectedOn { get; set; }  // date when role was selected
        public List<Tag> Tags = new List<Tag>(); // to group similar roles
        public List<string> Curriculum = new List<string>(); // wikipedia links, books, youtube/vimeo videos
        public List<Achievement> Achievements = new List<Achievement>();  // achievements to a Role ranging from the first encounter by the novice to mastery
    }
}