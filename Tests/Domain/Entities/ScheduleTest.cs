
using Domain.Entities;
using System;
using Xunit;

namespace Tests.Domain.Entities
{
    public class ScheduleTest
    {
        [Fact]
        public void Datetime_getdays_returns_Count_6()
        {
            var schedule = new Schedule(DateTime.Now,DateTime.Now.AddDays(5));
            var unvaibleDays = schedule.getUnvaibleDays();
            Assert.Equal(6, unvaibleDays.Count);
        }
        [Fact]
        public void Datetime_getdays_returns_Count_30()
        {
            var testData = DateTime.Now.AddMonths(1);
            var schedule = new Schedule(DateTime.Now, testData);
            var unvaibleDays = schedule.getUnvaibleDays();
            Assert.True(unvaibleDays.Count>29);
        }
    }
}
