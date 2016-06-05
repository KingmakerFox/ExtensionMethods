namespace KingmakerFox.ExtensionMethodsTest

open System
open Xunit

type DateExtensionsTest() =

    [<Theory>]
    [<InlineData("06/14/2014","05/31/2014")>]
    [<InlineData("01/29/2014","12/31/2013")>]
    [<InlineData("12/31/2013","11/30/2013")>]
    member this.TestLastCalendarMonthEndDate(dateStringInputValue : string, expectedResultString : string) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = date.LastCalendarMonthEndDate
        let expectedResult = DateTime.Parse expectedResultString
        Assert.Equal(expectedResult, calculatedResult)

    [<Theory>]
    [<InlineData("04/30/2016",true)>]
    [<InlineData("04/29/2016",false)>]
    member this.TestIsCalendarMonthEndDate(dateStringInputValue : string, expectedResult : bool) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let result = date.IsCalendarMonthEndDate
        Assert.Equal(expectedResult, result)

    [<Theory>]
    [<InlineData("06/14/2014","05/30/2014")>]
    [<InlineData("05/02/2016","04/29/2016")>]
    [<InlineData("04/05/2016","03/31/2016")>]
    [<InlineData("07/14/2013","06/28/2013")>]
    [<InlineData("05/14/2014","04/30/2014")>]
    member this.TestBusinessMonthEndDate(dateStringInputValue : string, expectedResultString : string) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = date.LastBusinessMonthEndDate
        let expectedResult = DateTime.Parse expectedResultString
        Assert.Equal(expectedResult, calculatedResult)

    [<Theory>]
    [<InlineData("06/14/2014",false)>]
    [<InlineData("06/15/2014",false)>]
    [<InlineData("06/5/2016",false)>]
    [<InlineData("06/13/2014",true)>]
    member this.TestIsWeekday(dateStringInputValue : string, expectedResult : bool) =
        // Give date that is a Saturday
        let date = System.DateTime.Parse(dateStringInputValue)
        Assert.Equal(expectedResult,date.IsWeekday)

    [<Theory>]
    [<InlineData("06/05/2016","12/31/2015")>]
    member this.TestLastCalendarYearEndDate(dateStringInputValue : string, expectedResultString: string) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = date.LastCalendarYearEndDate
        let expectedResult = DateTime.Parse(expectedResultString)
        Assert.Equal(expectedResult, calculatedResult)

    [<Theory>]
    [<InlineData("06/14/2008","12/31/2007")>]
    [<InlineData("06/14/2007","12/29/2006")>]
    [<InlineData("06/14/2006","12/30/2005")>]
    member this.TestLastBusinessYearEndDate(dateStringInputValue : string, expectedResultString: string) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = date.LastBusinessYearEndDate
        let expectedResult = DateTime.Parse(expectedResultString)
        Assert.Equal(expectedResult, calculatedResult)

    [<Theory>]
    [<InlineData("06/14/2014","06/13/2014")>]
    [<InlineData("06/15/2014","06/13/2014")>]
    [<InlineData("06/16/2014","06/13/2014")>]
    [<InlineData("06/13/2014","06/12/2014")>]
    member this.TestLastWeekday(dateStringInputValue : string, expectedResultString: string) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = date.LastWeekdayDate
        let expectedResult = DateTime.Parse(expectedResultString)
        Assert.Equal(expectedResult, calculatedResult)

    [<Theory>]
    [<InlineData("06/14/2014","06/16/2014")>]
    [<InlineData("06/15/2014","06/16/2014")>]
    [<InlineData("06/16/2014","06/17/2014")>]
    [<InlineData("06/13/2014","06/16/2014")>]
    member this.TestNextWeekday(dateStringInputValue : string, expectedResultString: string) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = date.NextWeekdayDate
        let expectedResult = DateTime.Parse(expectedResultString)
        Assert.Equal(expectedResult, calculatedResult)

    [<Theory>]
    [<InlineData("06/08/2014","06/07/2014")>]
    [<InlineData("06/09/2014","06/07/2014")>]
    [<InlineData("06/10/2014","06/07/2014")>]
    [<InlineData("06/11/2014","06/07/2014")>]
    [<InlineData("06/12/2014","06/07/2014")>]
    [<InlineData("06/13/2014","06/07/2014")>]
    [<InlineData("06/14/2014","06/07/2014")>]
    [<InlineData("06/15/2014","06/14/2014")>]
    member this.TestLastCalendarWeekendDate(dateStringInputValue : string, expectedResultString: string) =
        let date = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = date.LastCalendarWeekendDate
        let expectedResult = DateTime.Parse(expectedResultString)
        Assert.Equal(expectedResult, calculatedResult)

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
    [<InlineData("01/31/2016","12/31/2015")>]
    [<InlineData("02/29/2016","12/31/2015")>]
    [<InlineData("03/30/2016","12/31/2015")>]
    [<InlineData("03/31/2016","12/31/2015")>]
    [<InlineData("04/30/2016","03/31/2016")>]
    [<InlineData("05/31/2016","03/31/2016")>]
    [<InlineData("06/29/2016","03/31/2016")>]
    [<InlineData("06/30/2016","03/31/2016")>]
    [<InlineData("07/31/2016","06/30/2016")>]
    [<InlineData("08/11/2016","06/30/2016")>]
    [<InlineData("09/30/2016","06/30/2016")>]
    [<InlineData("10/05/2016","09/30/2016")>]
    [<InlineData("10/21/2016","09/30/2016")>]
    [<InlineData("11/26/2016","09/30/2016")>]
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

    [<Theory>]
    [<InlineData("06/14/2013","03/29/2013")>]
    [<InlineData("06/14/2014","03/31/2014")>]
    member this.TestLastBusinessQuarterEndDate(dateStringInputValue : string, dateStringExpectedValue : string) = 
        let item = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = item.LastBusinessQuarterEndDate
        let expectedResult = System.DateTime.Parse(dateStringExpectedValue)
        Assert.Equal(expectedResult,calculatedResult)

    [<Theory>]
    [<InlineData("03/14/2013","12/31/2012")>]
    [<InlineData("09/11/2001","06/30/2001")>]
    member this.TestLastCalendarSemiannualEndDate(dateStringInputValue : string, dateStringExpectedValue : string) = 
        let item = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = item.LastCalendarSemiannualEndDate
        let expectedResult = System.DateTime.Parse(dateStringExpectedValue)
        Assert.Equal(expectedResult,calculatedResult)
    
    [<Theory>]
    [<InlineData("03/14/2008","12/31/2007")>]
    [<InlineData("03/14/2007","12/29/2006")>]
    [<InlineData("03/14/2006","12/30/2005")>]
    [<InlineData("09/14/2013","06/28/2013")>]
    [<InlineData("09/14/2015","06/30/2015")>]
    member this.TestLastBusinessSemiannualEndDate(dateStringInputValue : string, dateStringExpectedValue : string) = 
        let item = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = item.LastBusinessSemiannualEndDate
        let expectedResult = System.DateTime.Parse(dateStringExpectedValue)
        Assert.Equal(expectedResult,calculatedResult)
        
    [<Fact>]
    member this.TestRelativeDateWithInvalidRelativePeriod() =
        let period = "X"
        let testDate = DateTime.Parse("04/26/2016")
        let calculatedResult = testDate.RelativeDate(period)
        let expectedResult = None
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.TestRelativeDateWithInvalidRelativePeriod2() =
        let period = "-10B"
        let testDate = DateTime.Parse("04/26/2016")
        let calculatedResult = testDate.RelativeDate(period)
        let expectedResult = None
        Assert.Equal(expectedResult,calculatedResult)

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
    [<InlineData("05/01/2016","6D","05/09/2016")>]
    [<InlineData("06/14/2014","0D","06/13/2014")>]
    [<InlineData("06/14/2014","-1D","06/12/2014")>]
    [<InlineData("06/14/2014","1D","06/16/2014")>]
    [<InlineData("06/14/2014","+1D","06/16/2014")>]
    [<InlineData("06/14/2014","-5D","06/06/2014")>]
    [<InlineData("06/05/2016","0D","06/03/2016")>]
    [<InlineData("06/05/2016","1D","06/06/2016")>]
    [<InlineData("06/05/2016","5D","06/10/2016")>]
    [<InlineData("05/30/2016","+7AD","06/06/2016")>]
    [<InlineData("05/29/2016","+7D","06/07/2016")>]
    [<InlineData("05/30/2016","+7D","06/07/2016")>]
    [<InlineData("06/14/2014","0AD","06/14/2014")>]
    [<InlineData("06/14/2014","-1AD","06/13/2014")>]
    [<InlineData("06/14/2014","1AD","06/15/2014")>]
    [<InlineData("06/14/2014","+1AD","06/15/2014")>]
    [<InlineData("06/14/2014","-5AD","06/09/2014")>]
    [<InlineData("06/14/2014","5AD","06/19/2014")>]
    [<InlineData("06/14/2014","0W","06/13/2014")>]
    [<InlineData("06/15/2014","0W","06/13/2014")>]
    [<InlineData("06/14/2014","-1W","06/06/2014")>]
    [<InlineData("06/14/2014","1W","06/20/2014")>]
    [<InlineData("06/14/2014","+1W","06/20/2014")>]
    [<InlineData("06/14/2014","-5W","05/09/2014")>]
    [<InlineData("06/14/2014","5W","07/18/2014")>]
    [<InlineData("06/14/2014","0AW","06/14/2014")>]
    [<InlineData("06/14/2014","1AW","06/21/2014")>]
    [<InlineData("06/14/2014","+1AW","06/21/2014")>]
    [<InlineData("06/14/2014","+2AW","06/28/2014")>]
    [<InlineData("06/14/2014","-5AW","05/10/2014")>]
    [<InlineData("06/14/2014","5AW","07/19/2014")>]
    [<InlineData("06/14/2014","0M","05/30/2014")>]
    [<InlineData("06/14/2014","-1M","04/30/2014")>]
    [<InlineData("06/14/2014","1M","06/30/2014")>]
    [<InlineData("06/14/2014","+1M","06/30/2014")>]
    [<InlineData("06/14/2014","-5M","12/31/2013")>]
    [<InlineData("06/14/2014","5M","10/31/2014")>]
    [<InlineData("06/14/2014","0AM","06/14/2014")>]
    [<InlineData("06/14/2014","-1AM","05/14/2014")>]
    [<InlineData("06/14/2014","+1AM","07/14/2014")>]
    [<InlineData("06/14/2014","1AM","07/14/2014")>]
    [<InlineData("06/14/2014","-5AM","01/14/2014")>]
    [<InlineData("06/14/2014","5AM","11/14/2014")>]
    [<InlineData("06/14/2014","+5AM","11/14/2014")>]
    [<InlineData("06/14/2014","1AM","07/14/2014")>]
    [<InlineData("06/14/2014","0Q","03/31/2014")>]
    [<InlineData("06/14/2014","-1Q","12/31/2013")>]
    [<InlineData("06/14/2014","1Q","06/30/2014")>]
    [<InlineData("06/14/2014","+1Q","06/30/2014")>]
    [<InlineData("06/14/2014","+2Q","09/30/2014")>]
    [<InlineData("06/14/2014","-5Q","12/31/2012")>]
    [<InlineData("06/14/2014","5Q","06/30/2015")>]
    [<InlineData("06/14/2014","0AQ","06/14/2014")>]
    [<InlineData("06/14/2014","-1AQ","03/14/2014")>]
    [<InlineData("06/14/2014","-2AQ","12/14/2013")>]
    [<InlineData("06/14/2014","1AQ","09/14/2014")>]
    [<InlineData("06/14/2014","2AQ","12/14/2014")>]
    [<InlineData("06/14/2014","+2AQ","12/14/2014")>]
    [<InlineData("06/14/2014","-5AQ","03/14/2013")>]
    [<InlineData("06/14/2014","5AQ","09/14/2015")>]
    [<InlineData("06/14/2014","0S","12/31/2013")>]
    [<InlineData("06/14/2007","0S","12/29/2006")>]
    [<InlineData("06/14/2006","0S","12/30/2005")>]
    [<InlineData("06/14/2006","1S","06/30/2006")>]
    [<InlineData("06/14/2016","-1S","06/30/2015")>]
    [<InlineData("06/14/2014","-5S","06/30/2011")>]
    [<InlineData("06/14/2014","5S","06/30/2016")>]
    [<InlineData("06/14/2014","+5S","06/30/2016")>]
    [<InlineData("06/14/2014","0AS","06/14/2014")>]
    [<InlineData("06/14/2007","0AS","06/14/2007")>]
    [<InlineData("06/14/2006","0AS","06/14/2006")>]
    [<InlineData("06/14/2006","1AS","12/14/2006")>]
    [<InlineData("06/14/2014","-1AS","12/14/2013")>]
    [<InlineData("06/14/2014","-5AS","12/14/2011")>]
    [<InlineData("06/14/2014","5AS","12/14/2016")>]
    [<InlineData("06/14/2014","+5AS","12/14/2016")>]
    [<InlineData("06/14/2014","0Y","12/31/2013")>]
    [<InlineData("06/14/2014","-1Y","12/31/2012")>]
    [<InlineData("06/14/2014","+1Y","12/31/2014")>]
    [<InlineData("06/14/2014","-5Y","12/31/2008")>]
    [<InlineData("06/14/2014","5Y","12/31/2018")>]
    [<InlineData("06/14/2014","+5Y","12/31/2018")>]
    [<InlineData("01/15/2012","-5Y","12/29/2006")>]
    [<InlineData("06/14/2014","0AY","06/14/2014")>]
    [<InlineData("06/14/2014","-1AY","06/14/2013")>]
    [<InlineData("06/14/2014","1AY","06/14/2015")>]
    [<InlineData("06/14/2014","-5AY","06/14/2009")>]
    [<InlineData("06/14/2014","+5AY","06/14/2019")>]
    [<InlineData("06/14/2014","-5ay","06/14/2009")>]
    [<InlineData("06/14/2014","+5ay","06/14/2019")>]
    [<InlineData("06/14/2014","2ay","06/14/2016")>]
    member this.TestRelativeDate(dateStringInputValue : string, relativePeriod : string, expectedDateStringValue : string) =
        let inputDate = System.DateTime.Parse(dateStringInputValue)
        let calculatedResult = inputDate.RelativeDate(relativePeriod).Value
        let expectedResult = System.DateTime.Parse(expectedDateStringValue)
        Assert.Equal(expectedResult,calculatedResult)

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