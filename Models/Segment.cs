using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTracker.BackService.Models
{
    public class Segment
    {
        public int Id { get; set; }

        public int SegmentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }
        
        public DateTime EndDateTime { get; set; }
    }
}
