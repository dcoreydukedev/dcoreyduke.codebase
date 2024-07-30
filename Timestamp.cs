/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCoreyDuke.CodeBase
{

    /// <summary>
    /// Initializes a new instance of the <see cref=".$Program"/> class.
    /// </summary>

    /// <summary>
    /// Create a Timestamp
    /// </summary>
    /// <remarks>
    /// 1.) A timestamp is a sequence of characters or encoded information identifying when a
    /// certain event occurred, usually giving date and time of day, sometimes accurate to a small
    /// fraction of a second, - Wikipedia 2.) Unix time, the number of seconds since 00:00:00 UTC on
    /// January 1, 1970 - Wikipedia
    /// </remarks>
    [ComplexType, Serializable]
    public class Timestamp
    {

        private DateTime _timestamp;
        private string _format = "MM/dd/yyyy HH:mm:ss";

        public Timestamp()
        {
            _timestamp = DateTime.Now;

            this.Day = _timestamp.Day;
            this.Month = _timestamp.Month;
            this.Year = _timestamp.Year;
            this.Hour = _timestamp.Hour;
            this.Minute = _timestamp.Minute;
            this.Second = _timestamp.Second;
            this.Milisecond = _timestamp.Millisecond;
        }


        /// <param name="format">The format string.</param>
        /// <remarks>
        /// 1.	    d  		    Represents the day of the month as a number from 1 through 31.
        /// 2.	    dd  	        Represents the day of the month as a number from 01 through 31.
        /// 3.	    ddd 	        Represents the abbreviated name of the day (Mon, Tues, Wed etc).
        /// 4.	    dddd 	    Represents the full name of the day (Monday, Tuesday etc).
        /// 5.	    h 		        12-hour clock hour (e.g. 4).
        /// 6.	    hh 		    12-hour clock, with a leading 0 (e.g. 06)
        /// 7.	    H 		        24-hour clock hour (e.g. 15)
        /// 8.	    HH 		    24-hour clock hour, with a leading 0 (e.g. 29)
        /// 9.	    m 		    Minutes
        /// 10.	mm 		    Minutes with a leading zero
        /// 11.	M 		    Month number(eg.3)
        /// 12.	MM 		    Month number with leading zero(eg.04)
        /// 13.	MMM 	    Abbreviated Month Name (e.g. Dec)
        /// 14.	MMMM 	Full month name (e.g. December)
        /// 15.	s 		        Seconds
        /// 16.	ss 		    Seconds with leading zero
        /// 17.	t 		        Abbreviated AM / PM (e.g. A or P)
        /// 18.	tt 		        AM / PM (e.g. AM or PM
        /// 19.	y 		        Year, no leading zero (e.g. 2015 would be 15)
        /// 20.	yy 		    Year, leading zero (e.g. 2015 would be 015)
        /// 21.	yyy          Year, (e.g. 2015)
        /// 22.	yyyy 	    Year, (e.g. 2015)
        /// 23.	K 		        Represents the time zone information of a date and time value (e.g. +05:00)
        /// 24.	z 		        With DateTime values, represents the signed offset of the local operating system's time zone from
        /// Format                                                   E.g.Result
        /// "MM/dd/yyyy"											05/29/2015
        /// "dddd, dd MMMM yyyy"							Friday, 29 May 2015
        /// "dddd, dd MMMM yyyy"							Friday, 29 May 2015 05:50
        /// "dddd, dd MMMM yyyy"							Friday, 29 May 2015 05:50 AM
        /// "dddd, dd MMMM yyyy"							Friday, 29 May 2015 5:50
        /// "dddd, dd MMMM yyyy"							Friday, 29 May 2015 5:50 AM
        /// "dddd, dd MMMM yyyy HH:mm:ss"		Friday, 29 May 2015 05:50:06
        /// "MM/dd/yyyy HH:mm"							05/29/2015 05:50
        /// "MM/dd/yyyy hh:mm tt"							05/29/2015 05:50 AM
        /// "MM/dd/yyyy H:mm"								05/29/2015 5:50
        /// "MM/dd/yyyy h:mm tt"							05/29/2015 5:50 AM
        /// "MM/dd/yyyy HH:mm:ss"						05/29/2015 05:50:06
        /// "MMMM dd"											May 29
        /// "yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"	2015-05-16T05:50:06.7199222-04:00
        /// "yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss"	2			015-05-16T05:50:06
        /// "HH:mm"												    05:50
        /// "hh:mm tt"											    05:50 AM
        /// "H:mm"												    5:50
        /// "h:mm tt"												    5:50 AM
        /// "HH:mm:ss"											05:50:06
        /// "yyyy MMMM"											2015 May
        /// </remarks>
        public Timestamp(string format) : this()
        {
            _format = format;
        }

        public int Day { get; set; }

        public int Hour { get; set; }

        public int? Milisecond { get; set; }

        public int Minute { get; set; }

        public int Month { get; set; }

        public int? Second { get; set; }

        public int Year { get; set; }

        #region Epoch

        /* Epoch = January 1, 1970 00:00:00 UTC */

        /// <summary>
        /// Gets the number of seconds since the Epoch = January 1, 1970 00:00:00 UTC
        /// </summary>
        /// <returns>The number of seconds since the Epoch = January 1, 1970 00:00:00 UTC</returns>
        private long GetEpochTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Gets the number of seconds since the Epoch = January 1, 1970 00:00:00 UTC
        /// </summary>
        /// <returns>The number of seconds since the Epoch = January 1, 1970 00:00:00 UTC</returns>
        public string GetEpochTimestamp()
        {
            return GetEpochTime().ToString().Trim();
        }

        #endregion Epoch

        public string GetTimestamp()
        {
            return _timestamp.ToString(_format);
        }


        public override string ToString()
        {
            return GetTimestamp();
        }


    }
}

/*
*  .Net DateTime() Formatting
* 1.	d  		Represents the day of the month as a number from 1 through 31.
* 2.	dd  	Represents the day of the month as a number from 01 through 31.
* 3.	ddd 	Represents the abbreviated name of the day (Mon, Tues, Wed etc).
* 4.	dddd 	Represents the full name of the day (Monday, Tuesday etc).
* 5.	h 		12-hour clock hour (e.g. 4).
* 6.	hh 		12-hour clock, with a leading 0 (e.g. 06)
* 7.	H 		24-hour clock hour (e.g. 15)
* 8.	HH 		24-hour clock hour, with a leading 0 (e.g. 29)
* 9.	m 		Minutes
* 10.	mm 		Minutes with a leading zero
* 11.	M 		Month number(eg.3)
* 12.	MM 		Month number with leading zero(eg.04)
* 13.	MMM 	Abbreviated Month Name (e.g. Dec)
* 14.	MMMM 	Full month name (e.g. December)
* 15.	s 		Seconds
* 16.	ss 		Seconds with leading zero
* 17.	t 		Abbreviated AM / PM (e.g. A or P)
* 18.	tt 		AM / PM (e.g. AM or PM
* 19.	y 		Year, no leading zero (e.g. 2015 would be 15)
* 20.	yy 		Year, leading zero (e.g. 2015 would be 015)
* 21.	yyy 	Year, (e.g. 2015)
* 22.	yyyy 	Year, (e.g. 2015)
* 23.	K 		Represents the time zone information of a date and time value (e.g. +05:00)
* 24.	z 		With DateTime values, represents the signed offset of the local operating system's time zone from
*
* Coordinated Universal Time (UTC), measured in hours. (e.g. +6)
* 25.	zz 		As z, but with leading zero (e.g. +06)
* 26.	zzz 	With DateTime values, represents the signed offset of the local operating system's time zone from UTC,measured in hours and minutes. (e.g. +06:00)
* 27.	f 		Represents the most significant digit of the seconds fraction; that is, it represents the tenths of a second in a date and time value.
* 28.	ff 		Represents the two most significant digits of the seconds fraction in date and time
* 29.	fff 	Represents the three most significant digits of the seconds fraction; that is, it represents the milliseconds in a date and time value.
* 30.	ffff 	Represents the four most significant digits of the seconds fraction; that is, it represents the ten thousandths of a second in a date and time value. While it is possible to display                the ten thousandths of a second component of a time value, that value may not be meaningful.
* 31.	fffff 	Represents the five most significant digits of the seconds fraction; that is, it represents the hundred thousandths of a second in a date and time value.
* 32.	ffffff 	Represents the six most significant digits of the seconds fraction; that is, it represents the millionths of a Second in a date and time value.
* 33.	fffffff Represents the seven most significant digits of the seconds fraction; that is, it represents the ten millionths of a second in a date and time value.
*
*	Format																			E.g. Result
*	DateTime.Now.ToString("MM/dd/yyyy")												05/29/2015
*	DateTime.Now.ToString("dddd, dd MMMM yyyy") 									Friday, 29 May 2015
*	DateTime.Now.ToString("dddd, dd MMMM yyyy") 									Friday, 29 May 2015 05:50
*	DateTime.Now.ToString("dddd, dd MMMM yyyy") 									Friday, 29 May 2015 05:50 AM
*	DateTime.Now.ToString("dddd, dd MMMM yyyy")										Friday, 29 May 2015 5:50
*	DateTime.Now.ToString("dddd, dd MMMM yyyy")										Friday, 29 May 2015 5:50 AM
*	DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")							Friday, 29 May 2015 05:50:06
*	DateTime.Now.ToString("MM/dd/yyyy HH:mm")										05/29/2015 05:50
*	DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")									05/29/2015 05:50 AM
*	DateTime.Now.ToString("MM/dd/yyyy H:mm")										05/29/2015 5:50
*	DateTime.Now.ToString("MM/dd/yyyy h:mm tt")										05/29/2015 5:50 AM
*	DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")									05/29/2015 05:50:06
*	DateTime.Now.ToString("MMMM dd")												May 29
*	DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK")					2015-05-16T05:50:06.7199222-04:00
*	DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’")						Fri, 16 May 2015 05:50:06 GMT
*	DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss")	2						015-05-16T05:50:06
*	DateTime.Now.ToString("HH:mm")													05:50
*	DateTime.Now.ToString("hh:mm tt")												05:50 AM
*	DateTime.Now.ToString("H:mm")													5:50
*	DateTime.Now.ToString("h:mm tt")												5:50 AM
*	DateTime.Now.ToString("HH:mm:ss")												05:50:06
*	DateTime.Now.ToString("yyyy MMMM")												2015 May
*/