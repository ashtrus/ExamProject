using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class RoleComment
    {
        public int RoleCommentId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public int CompanyRoleId { get; set; }

        [ForeignKey("CompanyRoleId")]
        public virtual CompanyRole CompanyRole { get; set; }

    }
}