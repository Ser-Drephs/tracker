using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Tracker.Core.Domain.WorkTimes.UnitTests
{
    [TestClass()]
    public class WorkTimeTests
    {
        private string timeSeperator;
        private string dateSeperator;

        public WorkTimeTests()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            timeSeperator = dtfi.TimeSeparator;
            dateSeperator = dtfi.DateSeparator;
        }

        [TestMethod()]
        public void Now()
        {
            var time = DateTime.Now;
            time.Should().BeCloseTo(DateTime.Now);
        }

        [TestMethod()]
        public void GetTime_Seperated_By_Doubledot()
        {
            var time = DateTime.Now;
            Assert.Inconclusive();
            //time.GetTimeString().Should().Contain(timeSeperator);
            //time.GetTimeString().Should().NotContain(dateSeperator);
        }

        [TestMethod()]
        public void GetDate_Not_Seperated_By_Doubledot()
        {
            var time = DateTime.Now;
            Assert.Inconclusive();
            //time.GetDateString().Should().Contain(dateSeperator);
            //time.GetDateString().Should().NotContain(timeSeperator);
        }

        [TestMethod()]
        public void Equality()
        {
            var time1 = DateTime.Now;
            var time2 = DateTime.Now;
            Assert.Inconclusive();
            //DateTime timestamp2 = time2.GetDateTime();
            //time1.Should().BeCloseTo(timestamp2);
        }
    }
}