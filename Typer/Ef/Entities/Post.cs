using System.Collections;
using System.Collections.Generic;

namespace Typer.Ef.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string BookName { get; set; }
        public string Writer { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

    }
}
