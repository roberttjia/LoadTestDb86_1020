using System;

namespace LoadTest.Data.Models
{
    public class PageLinkAssignB
    {
        public int PageLinkAssignBId { get; set; }
        public int PageLinkBId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public bool CanView { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual PageLinkB PageLink { get; set; } = null!;
    }
}
