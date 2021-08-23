﻿//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//

namespace Sys.Data.Coding
{
    public enum DateInterval
    {
        year, //yyyy, yy = Year
        quarter, //qq, q = Quarter
        month, //mm, m = month
        dayofyear, //dy, y = Day of the year
        day, //dd, d = Day
        week, //ww, wk = Week
        weekday, //dw, w = Weekday
        hour, //hh = hour
        minute, //mi, n = Minute
        second, //ss, s = Second
        millisecond, //ms = Millisecond
    }
}