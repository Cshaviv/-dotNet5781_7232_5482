﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BLAPI
{
    public static class BLFactory
    {
        public static IBL GetBL(string type)
        {
            switch (type)
            {
                case "1":
                     return /*new*/ BLImp.Instance;
                default:
                    return /*new*/ BLImp.Instance/*()*/;
            }
        }
    }
    //public  class a
    //{
    //    IBL d = new BLAPI.BLFactory.GetBL("BLImp");
    //}
}
