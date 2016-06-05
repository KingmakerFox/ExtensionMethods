namespace CommonTest

open Xunit
open Common.DateTimeExtensions

type DateExtensionsTest() =

    [<Fact>]
    member this.TestLastCalendarMonthEndDate_20140614() =
        let date = System.DateTime.Parse("06/14/2014")
        let calendarMonthEndDate = System.DateTime.Parse("05/31/2014")
        Assert.Equal(calendarMonthEndDate,date.LastCalendarMonthEndDate)

    [<Theory>]
    [<InlineData("04/30/2016",true)>]
    [<InlineData("04/29/2016",false)>]
    member this.TestIsCalendarMonthEndDate(dateStringInputValue : string, expectedResult : bool) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let result = date.IsCalendarMonthEndDate
        Assert.Equal(expectedResult, result)

    [<Fact>]
    member this.TestBusinessMonthEndDate_DifferentCalendarMonthEndDateSaturday() =
        let date = System.DateTime.Parse("06/14/2014")
        let businessMonthEndDate = System.DateTime.Parse("05/30/2014")
        Assert.Equal(businessMonthEndDate,date.LastBusinessMonthEndDate)

    [<Fact>]
    member this.TestBusinessMonthEndDate_DifferentCalendarMonthEndDateSunday() =
        let date = System.DateTime.Parse("07/14/2013")
        //Month end was a Sunday
        let businessMonthEndDate = System.DateTime.Parse("06/28/2013")
        Assert.Equal(businessMonthEndDate,date.LastBusinessMonthEndDate)

    [<Fact>]
    member this.TestBusinessMonthEndDate_SameCalendarMonthEndDate() =
        let date = System.DateTime.Parse("05/14/2014")
        let businessMonthEndDate = System.DateTime.Parse("04/30/2014")
        Assert.Equal(businessMonthEndDate,date.LastBusinessMonthEndDate)

    [<Fact>]
    member this.TestIsWeekdaySaturday() =
        // Give date that is a Saturday
        let date = System.DateTime.Parse("06/14/2014")
        Assert.Equal(false,date.IsWeekday)

    [<Fact>]
    member this.TestIsWeekdaySunday() =
        // Give date that is a Sunday
        let date = System.DateTime.Parse("06/15/2014")
        Assert.Equal(false,date.IsWeekday)

    [<Fact>]
    member this.TestIsWeekdayFriday() =
        // Give date that is a Sunday
        let date = System.DateTime.Parse("06/13/2014")
        Assert.Equal(true,date.IsWeekday)

    [<Fact>]
    member this.TestLastCalendarYearEndDate() =
        let date = System.DateTime.Parse("06/14/2014")
        let lastYearEndDate = System.DateTime.Parse("12/31/2013")
        Assert.Equal(lastYearEndDate,date.LastCalendarYearEndDate)

    [<Fact>]
    member this.TestBusinessYearEndDate_SameCalendarYearEndDate() =
        // 6/14/2008 was a Saturday
        let date = System.DateTime.Parse("06/14/2008")
        // 12/31/2007 was a Monday
        let businessYearEndDate = System.DateTime.Parse("12/31/2007")
        Assert.Equal(businessYearEndDate,date.LastBusinessYearEndDate)

    [<Fact>]
    member this.TestBusinessYearEndDate_DifferentCalendarYearEndDateSunday() =
        // 6/14/2007 was a Thursday
        let date = System.DateTime.Parse("06/14/2007")
        // 12/31/2006 was a Sunday
        let businessYearEndDate = System.DateTime.Parse("12/29/2006")
        Assert.Equal(businessYearEndDate,date.LastBusinessYearEndDate)

    [<Fact>]
    member this.TestBusinessYearEndDate_DifferentCalendarYearEndDateSaturday() =
        // 6/14/2006 was a Wednesday
        let date = System.DateTime.Parse("06/14/2006")
        // 12/31/2006 was a Saturday
        let businessYearEndDate = System.DateTime.Parse("12/30/2005")
        Assert.Equal(businessYearEndDate,date.LastBusinessYearEndDate)

    [<Fact>]
    member this.TestLastWeekdaySaturday() =
        let date = System.DateTime.Parse("06/14/2014")
        let lastWeekday = System.DateTime.Parse("06/13/2014")
        Assert.Equal(lastWeekday,date.LastWeekdayDate)

    [<Fact>]
    member this.TestLastWeekdaySunday() =
        let date = System.DateTime.Parse("06/15/2014")
        let lastWeekday = System.DateTime.Parse("06/13/2014")
        Assert.Equal(lastWeekday,date.LastWeekdayDate)

    [<Fact>]
    member this.TestLastWeekdayFriday() =
        let date = System.DateTime.Parse("06/13/2014")
        let lastWeekday = System.DateTime.Parse("06/12/2014")
        Assert.Equal(lastWeekday,date.LastWeekdayDate)

    [<Fact>]
    member this.TestLastWeekdayMonday() =
        let date = System.DateTime.Parse("06/16/2014")
        let lastWeekday = System.DateTime.Parse("06/13/2014")
        Assert.Equal(lastWeekday,date.LastWeekdayDate)

    [<Fact>]
    member this.TestNewWeekdaySaturday() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/16/2014")
        Assert.Equal(expectedResult,date.NextWeekdayDate)

    [<Fact>]
    member this.TestNewWeekdaySunday() =
        let date = System.DateTime.Parse("06/15/2014")
        let expectedResult = System.DateTime.Parse("06/16/2014")
        Assert.Equal(expectedResult,date.NextWeekdayDate)

    [<Fact>]
    member this.TestNewWeekdayFriday() =
        let date = System.DateTime.Parse("06/13/2014")
        let expectedResult = System.DateTime.Parse("06/16/2014")
        Assert.Equal(expectedResult,date.NextWeekdayDate)

    [<Fact>]
    member this.TestLastCalendarWeekendDateSunday() =
        let date = System.DateTime.Parse("06/08/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        Assert.Equal(expectedResult,date.LastCalendarWeekendDate)

    [<Fact>]
    member this.TestLastCalendarWeekendDateMonday() =
        let date = System.DateTime.Parse("06/09/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        Assert.Equal(expectedResult,date.LastCalendarWeekendDate)

    [<Fact>]
    member this.TestLastCalendarWeekendDateTuesday() =
        let date = System.DateTime.Parse("06/10/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        Assert.Equal(expectedResult,date.LastCalendarWeekendDate)

    [<Fact>]
    member this.TestLastCalendarWeekendDateWednesday() =
        let date = System.DateTime.Parse("06/11/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        Assert.Equal(expectedResult,date.LastCalendarWeekendDate)

    [<Fact>]
    member this.TestLastCalendarWeekendDateThursday() =
        let date = System.DateTime.Parse("06/12/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        Assert.Equal(expectedResult,date.LastCalendarWeekendDate)

    [<Fact>]
    member this.TestLastCalendarWeekendDateFriday() =
        let date = System.DateTime.Parse("06/13/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        let calculatedResult = date.LastCalendarWeekendDate
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestLastCalendarWeekendDateSaturday() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        let calculatedResult = date.LastCalendarWeekendDate
        Assert.Equal(expectedResult,date.LastCalendarWeekendDate)

    [<Theory>]
    [<InlineData("04/30/2016")>]
    [<InlineData("05/01/2016")>]
    [<InlineData("05/02/2016")>]
    [<InlineData("05/03/2016")>]
    [<InlineData("05/04/2016")>]
    [<InlineData("05/05/2016")>]
    [<InlineData("05/06/2016")>]
    member this.TestLastBusinessWeekendDate(dateString : string) =
        let item = System.DateTime.Parse(dateString)
        let expectedResult = System.DateTime.Parse("04/29/2016")
        let calculatedResult = item.LastBusinessWeekendDate
        Assert.Equal(expectedResult,calculatedResult)

    [<Theory>]
    [<InlineData("12/31/2015","09/30/2015")>]
    [<InlineData("01/15/2016","12/31/2015")>]
    [<InlineData("03/30/2016","12/31/2015")>]
    [<InlineData("03/31/2016","12/31/2015")>]
    [<InlineData("06/29/2016","03/31/2016")>]
    [<InlineData("06/30/2016","03/31/2016")>]
    [<InlineData("08/11/2016","06/30/2016")>]
    [<InlineData("09/30/2016","06/30/2016")>]
    [<InlineData("10/05/2016","09/30/2016")>]
    member this.TestLastCalendarQuarterEndDate(dateStringInputValue: string, dateStringExpectedValue : string) =
        let item = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = item.LastCalendarQuarterEndDate
        let expectedResult = System.DateTime.Parse(dateStringExpectedValue)
        Assert.Equal(expectedResult,calculatedResult)

    [<Theory>]
    [<InlineData("01/01/2016","01/31/2016")>]
    [<InlineData("02/01/2016","02/29/2016")>]
    [<InlineData("03/01/2016","03/31/2016")>]
    [<InlineData("04/01/2016","04/30/2016")>]
    [<InlineData("05/01/2016","05/31/2016")>]
    [<InlineData("06/01/2016","06/30/2016")>]
    [<InlineData("07/01/2016","07/31/2016")>]
    [<InlineData("08/01/2016","08/31/2016")>]
    [<InlineData("09/01/2016","09/30/2016")>]
    [<InlineData("10/01/2016","10/31/2016")>]
    [<InlineData("11/01/2016","11/30/2016")>]
    [<InlineData("12/01/2016","12/31/2016")>]
    [<InlineData("11/30/2016","12/31/2016")>]
    [<InlineData("12/31/2015","01/31/2016")>]
    [<InlineData("02/28/2016","02/29/2016")>]
    [<InlineData("02/29/2016","03/31/2016")>]
    member this.TestNextCalendarMonthEndDate(dateStringInputValue : string, dateStringExpectedValue : string) = 
        let item = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = item.NextCalendarMonthEndDate
        let expectedResult = System.DateTime.Parse(dateStringExpectedValue)
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestLastBusinessQuarterEndDateWeekend() =
        let date = System.DateTime.Parse("06/14/2013")
        let expectedResult = System.DateTime.Parse("03/29/2013")
        Assert.Equal(expectedResult,date.LastBusinessQuarterEndDate)

    [<Fact>]
    member this.TestLastBusinessQuarterEndDateWeekday() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("03/31/2014")
        Assert.Equal(expectedResult,date.LastBusinessQuarterEndDate)

    [<Fact>]
    member this.TestLastCalendarSemiannualEndDateFirstHalf() =
        let date = System.DateTime.Parse("03/14/2013")
        let expectedResult = System.DateTime.Parse("12/31/2012")
        Assert.Equal(expectedResult,date.LastCalendarSemiannualEndDate)

    [<Fact>]
    member this.TestLastCalendarSemiannualEndDateSecondHalf() =
        let date = System.DateTime.Parse("09/14/2013")
        let expectedResult = System.DateTime.Parse("06/30/2013")
        Assert.Equal(expectedResult,date.LastCalendarSemiannualEndDate)

    [<Fact>]
    member this.TestLastBusinessSemiannualEndDateFirstHalf() =
        let date = System.DateTime.Parse("03/14/2007")
        let expectedResult = System.DateTime.Parse("12/29/2006")
        Assert.Equal(expectedResult,date.LastBusinessSemiannualEndDate)

    [<Fact>]
    member this.TestLastBusinessSemiannualEndDateFirstHalf2() =
        let date = System.DateTime.Parse("03/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2013")
        Assert.Equal(expectedResult,date.LastBusinessSemiannualEndDate)

    [<Fact>]
    member this.TestLastBusinessSemiannualEndDateSecondHalf() =
        let date = System.DateTime.Parse("09/14/2013")
        let expectedResult = System.DateTime.Parse("06/28/2013")
        Assert.Equal(expectedResult,date.LastBusinessSemiannualEndDate)

    [<Theory>]
    [<InlineData("05/01/2016","-1AW","04/24/2016")>]
    [<InlineData("05/01/2016","0W","04/29/2016")>]
    [<InlineData("05/01/2016","-1W","04/22/2016")>]
    [<InlineData("05/01/2016","-2W","04/15/2016")>]
    [<InlineData("05/01/2016","1W","05/06/2016")>]
    [<InlineData("05/01/2016","1D","05/02/2016")>]
    [<InlineData("05/01/2016","2D","05/03/2016")>]
    [<InlineData("05/01/2016","3D","05/04/2016")>]
    [<InlineData("05/01/2016","4D","05/05/2016")>]
    [<InlineData("05/01/2016","5D","05/06/2016")>]
    [<InlineData("05/01/2016","5D","05/09/2016")>]
    [<InlineData("05/01/2016","X","05/01/2016")>]
    [<InlineData("04/26/2016","1D","04/27/2016")>]
    [<InlineData("04/26/2016","1D","04/27/2016")>]
    [<InlineData("04/26/2016","1D","04/27/2016")>]
    [<InlineData("04/26/2016","1D","04/27/2016")>]
    


    member this.TestRelativeDate(dateStringInputValue : string, relativePeriod : string, expectedDateStringValue : string) =
        let inputDate = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = inputDate.RelativeDate(relativePeriod)
        let expectedResult = System.DateTime.Parse(expectedDateStringValue)
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Weekdays
    [<Fact>]
    member this.TestRelativeDate_0D() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/13/2014")
        let calculatedResult = date.RelativeDate("0D")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1DBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/12/2014")
        let calculatedResult = date.RelativeDate("-1D")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1DAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/16/2014")
        let calculatedResult = date.RelativeDate("1D")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1DAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/16/2014")
        let calculatedResult = date.RelativeDate("+1D")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5DBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/06/2014")
        let calculatedResult = date.RelativeDate("-5D")
        Assert.Equal(expectedResult,calculatedResult)

    //Test RelativeDate ActualDays
    [<Fact>]
    member this.TestRelativeDate_0AD() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("0AD")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1ADBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/13/2014")
        let calculatedResult = date.RelativeDate("-1AD")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1ADAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/15/2014")
        let calculatedResult = date.RelativeDate("1AD")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1ADAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/15/2014")
        let calculatedResult = date.RelativeDate("+1AD")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5ADBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/09/2014")
        let calculatedResult = date.RelativeDate("-5AD")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5ADAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/19/2014")
        let calculatedResult = date.RelativeDate("5AD")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Weeks
    [<Fact>]
    member this.TestRelativeDate_0WSaturday() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/13/2014")
        let calculatedResult = date.RelativeDate("0W")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_0WSunday() =
        let date = System.DateTime.Parse("06/15/2014")
        let expectedResult = System.DateTime.Parse("06/13/2014")
        let calculatedResult = date.RelativeDate("0W")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1WBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/06/2014")
        let calculatedResult = date.RelativeDate("-1W")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1WAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("1W")
        let expectedResult = System.DateTime.Parse("06/20/2014")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1WAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/20/2014")
        let calculatedResult = date.RelativeDate("+1W")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5WBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("05/09/2014")
        let calculatedResult = date.RelativeDate("-5W")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5WAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("07/18/2014")
        let calculatedResult = date.RelativeDate("5W")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate ActualWeeks
    [<Fact>]
    member this.TestRelativeDate_0AW() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("0AW")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AWBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/07/2014")
        let calculatedResult = date.RelativeDate("-1AW")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AWAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/21/2014")
        let calculatedResult = date.RelativeDate("1AW")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AWAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/21/2014")
        let calculatedResult = date.RelativeDate("+1AW")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AWBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("05/10/2014")
        let calculatedResult = date.RelativeDate("-5AW")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AWAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("07/19/2014")
        let calculatedResult = date.RelativeDate("5AW")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Months
    [<Fact>]
    member this.TestRelativeDate_0M() =
        let date = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("0M")
        let expectedResult = System.DateTime.Parse("05/30/2014")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1MBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("-1M")
        let expectedResult = System.DateTime.Parse("04/30/2014")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1MAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("1M")
        let expectedResult = System.DateTime.Parse("06/30/2014")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1MAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("+1M")
        let expectedResult = System.DateTime.Parse("06/30/2014")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5MBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2013")
        let calculatedResult = date.RelativeDate("-5M")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5MAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("10/31/2014")
        let calculatedResult = date.RelativeDate("5M")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate ActualMonths
    [<Fact>]
    member this.TestRelativeDate_0AM() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("0AM")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AMBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("05/14/2014")
        let calculatedResult = date.RelativeDate("-1AM")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AMAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("07/14/2014")
        let calculatedResult = date.RelativeDate("1AM")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AMAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("07/14/2014")
        let calculatedResult = date.RelativeDate("+1AM")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AMBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("01/14/2014")
        let calculatedResult = date.RelativeDate("-5AM")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AMAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("11/14/2014")
        let calculatedResult = date.RelativeDate("5AM")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Quarters
    [<Fact>]
    member this.TestRelativeDate_0Q() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("03/31/2014")
        let calculatedResult = date.RelativeDate("0Q")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1QBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2013")
        let calculatedResult = date.RelativeDate("-1Q")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1QAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/30/2014")
        let calculatedResult = date.RelativeDate("1Q")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1QAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/30/2014")
        let calculatedResult = date.RelativeDate("+1Q")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5QBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2012")
        let calculatedResult = date.RelativeDate("-5Q")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5QAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("5Q")
        let expectedResult = System.DateTime.Parse("06/30/2015")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Actual Quarters
    [<Fact>]
    member this.TestRelativeDate_0AQ() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("0AQ")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AQBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("03/14/2014")
        let calculatedResult = date.RelativeDate("-1AQ")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AQAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("09/14/2014")
        let calculatedResult = date.RelativeDate("1AQ")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AQAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("09/14/2014")
        let calculatedResult = date.RelativeDate("+1AQ")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AQBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("03/14/2013")
        let calculatedResult = date.RelativeDate("-5AQ")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AQAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("09/14/2015")
        let calculatedResult = date.RelativeDate("5AQ")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Semiannual Periods
    [<Fact>]
    member this.TestRelativeDate_0S() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2013")
        let calculatedResult = date.RelativeDate("0S")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1SBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/28/2013")
        let calculatedResult = date.RelativeDate("-1S")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1SAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/30/2014")
        let calculatedResult = date.RelativeDate("1S")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1SAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/30/2014")
        let calculatedResult = date.RelativeDate("+1S")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5SBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/30/2011")
        let calculatedResult = date.RelativeDate("-5S")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5SAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/30/2016")
        let calculatedResult = date.RelativeDate("5S")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Actual Semiannual Periods
    [<Fact>]
    member this.TestRelativeDate_0AS() =
        let date = System.DateTime.Parse("06/14/2014").ToLocalTime()
        let expectedResult = System.DateTime.Parse("06/14/2014").ToLocalTime()
        let calculatedResult = date.RelativeDate("0AS")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1ASBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/14/2013")
        let calculatedResult = date.RelativeDate("-1AS")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1ASAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/14/2014")
        let calculatedResult = date.RelativeDate("1AS")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1ASAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/14/2014")
        let calculatedResult = date.RelativeDate("+1AS")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5ASBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/14/2011")
        let calculatedResult = date.RelativeDate("-5AS")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5ASAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/14/2016")
        let calculatedResult = date.RelativeDate("5AS")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Years
    [<Fact>]
    member this.TestRelativeDate_0Y() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2013")
        let calculatedResult = date.RelativeDate("0Y")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1YBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2012")
        let calculatedResult = date.RelativeDate("-1Y")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1YAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2014")
        let calculatedResult = date.RelativeDate("1Y")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1YAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2014")
        let calculatedResult = date.RelativeDate("+1Y")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5YBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2008")
        let calculatedResult = date.RelativeDate("-5Y")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5YAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("12/31/2018")
        let calculatedResult = date.RelativeDate("5Y")
        Assert.Equal(expectedResult,calculatedResult)

    // Test RelativeDate Actual Semiannual Periods
    [<Fact>]
    member this.TestRelativeDate_0AY() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2014")
        let calculatedResult = date.RelativeDate("0AY")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AYBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2013")
        let calculatedResult = date.RelativeDate("-1AY")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AYAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2015")
        let calculatedResult = date.RelativeDate("1AY")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_1AYAheadWithPlus() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2015")
        let calculatedResult = date.RelativeDate("+1AY")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AYBack() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2009")
        let calculatedResult = date.RelativeDate("-5AY")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AYAhead() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2019")
        let calculatedResult = date.RelativeDate("5AY")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_5AYAheadLowercase() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("06/14/2019")
        let calculatedResult = date.RelativeDate("5ay")
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDate_PassWrongValue() =
        let date = System.DateTime.Parse("06/14/2014")
        let expectedResult = System.DateTime.Parse("01/01/0001")
        let calculatedResult = date.RelativeDate("5ay")
        Assert.NotEqual(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestToDatabaseString() =
        let date = System.DateTime.Parse("12/14/2016")
        let result = date.ToDatabaseString()
        Assert.Equal(result,"20161214")

    [<Fact>]
    member this.TestToODBCString() =
        let date = System.DateTime.Parse("12/14/2016")
        let result = date.ToODBCString()
        Assert.Equal(result,"2016-12-14")

