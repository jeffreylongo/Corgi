using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corgi.Models
{
    public class NewsFeed
    {
        public int Id { get; set; }
        public string StoryName { get; set; }
        public int HerdId { get; set; }
        public string Url { get; set; }
    }
}