using System.Collections.Generic;

namespace FjRuiYiPack.Web.Models
{
    public class IndexModel
    {
        public IEnumerable<Article> Articles { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
