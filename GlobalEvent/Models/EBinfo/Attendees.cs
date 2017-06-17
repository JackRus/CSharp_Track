using System.Collections.Generic;

namespace GlobalEvent.Models.EBinfo
{
    public class Attendees
    {
        public List<Attendee> attendees { get; set; }
        public Pagination pagination { get; set; }
    }
}