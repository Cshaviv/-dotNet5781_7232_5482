﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineTrip
    {
        public int LineTripId { get; set; }
        public int LineId { get; set; }
        public TimeSpan StartAt { get; set; }
        //StartAt
        public TimeSpan Frequency { get; set; }
        public TimeSpan FinishAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
