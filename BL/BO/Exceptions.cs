﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    public class BadLicenseNumException : Exception
    {
        public int licenseNum;
        public BadLicenseNumException(int ln) : base() => licenseNum = ln;
        public BadLicenseNumException(int ln, string message) :
            base(message) => licenseNum = ln;
        public BadLicenseNumException(int ln, string message, Exception innerException) :
            base(message, innerException) => licenseNum = ln;

        public override string ToString() => base.ToString() + $", bad license number: {licenseNum}";
    }
    public class BadInputException : Exception
    {
        public int num;
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
        public BadLineIdException(string message) : base(message) { }
        public BadLineIdException(int id) : base() => ID = id;
        public BadLineIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad Line ID number: {ID}";
    }
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
    public class BadLineTripException : Exception
    {
        public int idLine;
        public int code;

        public BadLineTripException(int id) : base() => idLine = id;
        public BadLineTripException(int id, string message) :
            base(message) => idLine = id;

        public BadLineTripException(string message) : base(message) { }

        //public override string ToString() => base.ToString() + $", bad Line ID number: {idLine}";
    }
}

