using System;

namespace FjRuiYiPack.Web.Models
{
    public class Article
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Cover { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
