﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_7232_5482
{
    class Bus
    {
        private int licenseNum;
        private DateTime startDate;
        private DateTime lastTreat;
        private double km;
        private double kmafterRefueling;
        private double kmaftertreat;

        public double Kmaftertreat
        {
            get { return kmaftertreat; }
            set { kmaftertreat = value; }
        }

        public double Kmafterrefueling
        {
            get { return kmafterRefueling; }
            set { kmafterRefueling = value; }
        }
        public double Km
        {
            get { return km; }
            set {
                if (value < km)
                { throw new Exception(); }
                km = value; }
        }

        public DateTime LastTreat
        {
            get { return lastTreat; }
            set { lastTreat = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public int LicenseNum
        {
            get { return licenseNum; }
            set { licenseNum = value; }
        }

        public void  get_LicesNum()//Prints the license number in the appropriate format
        { 

            string s_l = this.LicenseNum.ToString();
            string prefix, middle, suffix;
            if (startDate.Year < 2018)
            {
                prefix = s_l.Substring(0, 2);
                middle = s_l.Substring(2, 3);
                suffix = s_l.Substring(5, 2);
            }
            else
            {
                prefix = s_l.Substring(0, 3);
                middle = s_l.Substring(3, 2);
                suffix = s_l.Substring(5, 3);
            }
            string registrationString = String.Format("{0}-{1}-{2}", prefix, middle, suffix);
            Console.WriteLine(registrationString);

        }

        
        public bool needTreat(double RandKm1)
        {
            return ((this.kmaftertreat + RandKm1 >= 20000) || ((DateTime.Now - this.lastTreat).TotalDays >= 365));
        }


        public Bus(int licNum, DateTime dt, DateTime My_DT, double My_Km = 0, double My_Kmaftertreat = 0, double My_Kmafterrefueling = 0)
        {
            this.startDate = dt;
            this.licenseNum = licNum;
            this.lastTreat = My_DT;
            this.Km = My_Km;
            this.kmaftertreat = My_Kmaftertreat;
            this.kmafterRefueling = My_Kmafterrefueling;
        }  
}
}
