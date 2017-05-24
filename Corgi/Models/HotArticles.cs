using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corgi.Models
{
    public class HotArticles
    {
        public int? Id { get; set; }
        public string StoryName { get; set; }
        public string Url { get; set; }

        public int? NewsFeedId { get; set; }
        public NewsFeed NewsFeed { get; set; }

    }
}