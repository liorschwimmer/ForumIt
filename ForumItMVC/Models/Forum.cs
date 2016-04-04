using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumItMVC.Models
{
    public class Forum
    {
        public System.Guid ForumID { get; set; }
        public string ForumName { get; set; }
        public string ForumDescription { get; set; }
        public System.Guid CreateUserID { get; set; }
        public string CreateDate { get; set; }
        public System.DateTime ModifyDate { get; set; }
        public bool Active { get; set; }
    }
}