using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PageLinkB
    {
        public PageLinkB()
        {
            PageLinkAssign = new HashSet<PageLinkAssignB>();
        }

        public int PageLinkBId { get; set; }
        public int PageLinkCategoryBId { get; set; }
        public string PageName { get; set; } = string.Empty;
        public string PageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual PageLinkCategoryB PageLinkCategory { get; set; } = null!;
        public virtual ICollection<PageLinkAssignB> PageLinkAssign { get; set; }
    }
}
