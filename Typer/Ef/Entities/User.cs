using System;
using System.Collections.Generic;

namespace Typer.Ef.Entities
{
    public class User
    {   
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int PostCount { get; set; }
        public string AvatarUrl { get; set; }
        public ICollection<Post> Posts { get; set; }
       
        //TODO
        //public DateTime CreatedDate { get; set; }
    }
}
