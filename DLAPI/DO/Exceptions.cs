﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BadLicenseNumException : Exception
    {
        public int licenseNum;
        public BadLicenseNumException(int licNum) : base() => licenseNum = licNum;
        public BadLicenseNumException(int licNum, string message) :
            base(message) => licenseNum = licNum;
        public BadLicenseNumException(int licNum, string message, Exception innerException) :
            base(message, innerException) => licenseNum = licNum;

        public override string ToString() => base.ToString() + $", bad license number: {licenseNum}";
    }
    public class BadInputException : Exception
    {
        int num;
        public BadInputException(string message) : base(message) { }
        public override string ToString() => base.ToString();
        public BadInputException(int ln, string message) :
          base(message) => num = ln;
    }
    public class BadUserException : Exception
    {
        public BadUserException(string message) : base(message) { }
        public override string ToString() => base.ToString();
    }
    public class BadLineIdException : Exception
    {
        public int ID;
        public int code;

        public BadLineIdException(int id) : base() => ID = id;
        public BadLineIdException(int id, string message) :
            base(message) => ID = id;
       
        public BadLineIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad Line ID number: {ID}";
    }
    [Serializable]
    public class BadLineTripException : Exception
    {
        public int idLine;
        public int code;

        public BadLineTripException(int id) : base() => idLine = id;
        public BadLineTripException(int id, string message) :
            base(message) => idLine = id;

        public BadLineTripException(int id, string message, Exception innerException) :
            base(message, innerException) => idLine = id;

        public override string ToString() => base.ToString() + $", bad Line ID number: {idLine}";
    }
    //public class BadLineTripException : Exception
    //{
    //    public int lineId;
    //    public BadLineTripException(int LineId) : base()
    //    {
    //        lineId = LineId;
    //    }

    //    public BadLineTripException(int LineId, string message) :
    //             base(message) => lineId = LineId;

    //    //public override string ToString()
    //    //{
    //    //    return Message;
    //    //}
    //}
    public class BadStationCodeException : Exception
    {
        public int stationCode;
        public BadStationCodeException(int code) : base() => stationCode = code;
        public BadStationCodeException(int code, string message) :
            base(message) => stationCode = code;
        public BadStationCodeException(int code, string message, Exception innerException) :
            base(message, innerException) => stationCode = code;

        public override string ToString() => base.ToString() + $", bad station code number: {stationCode}";
    }

    //public class BadLineTripException : Exception
    //{
    //    public int lineId;
    //    public TimeSpan depTime;//departure time
    //    public BadLineTripException(int lineId, string message) :
    //     base(message, innerException)
    //    {
    //        lineId = ((DO.BadLineTripException)innerException).lineId;
    //        depTime = ((DO.BadLineTripException)innerException).depTime;
    //    }
    //    public override string ToString()
    //    {
    //        return Message;
    //    }
    //}
}


