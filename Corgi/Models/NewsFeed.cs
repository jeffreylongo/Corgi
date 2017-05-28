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

        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
        public ICollection<HotArticles> HotArticles { get; set; } = new HashSet<HotArticles>();

    }
}