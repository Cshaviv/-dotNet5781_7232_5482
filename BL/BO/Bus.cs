﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class Bus
    {
        public int LicenseNum { get; set; }//license number
        public DateTime StartDate { get; set; }//start date(date of start)
        public double TotalKm { get; set; }//total km
        public double FuelTank { get; set; }//fuel tank
        public BusStatus StatusBus { get; set; }//status of the bus
        public DateTime DateLastTreat { get; set; }//date of the last treatment
        public double KmLastTreat { get; set; }// total km from the last treatment
    }
}
