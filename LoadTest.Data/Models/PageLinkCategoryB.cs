using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PageLinkCategoryB
    {
        public PageLinkCategoryB()
        {
            PageLink = new HashSet<PageLinkB>();
        }

        public int PageLinkCategoryBId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PageLinkB> PageLink { get; set; }
    }
}
