using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingClient
{
    class TimeTracking
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Employee Employee { get; set; }
    }
}
