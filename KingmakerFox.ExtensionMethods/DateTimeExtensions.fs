namespace Common

module DateTimeExtensions =

    open System
    open System.Runtime.CompilerServices
    open Common.StringFunctions

    //You need to declare all Extension Attributes explicitly
    [<assembly:Extension>]

    do()

    type System.DateTime with
        [<Extension>]
        member this.ToDatabaseString() =
            let year = this.Year.ToString("0000")
            let month = this.Month.ToString("00")
            let day = this.Day.ToString("00")
            let result = year+month+day
            result

        [<Extension>]
        member this.ToODBCString() =
            let year = this.Year.ToString("0000")
            let month = this.Month.ToString("00")
            let day = this.Day.ToString("00")
            let result = year+"-"+month+"-"+day
            result

        [<Extension>]
        member this.IsWeekday =
            match this.DayOfWeek with
            | DayOfWeek.Saturday | DayOfWeek.Sunday -> false
            | _ -> true

        [<Extension>]
        member this.LastWeekdayDate =
            match this.DayOfWeek with
            | DayOfWeek.Sunday -> this.AddDays(-2.0)
            | DayOfWeek.Monday -> this.AddDays(-3.0)
            | _ -> this.AddDays(-1.0)

        [<Extension>]
        member this.NextWeekdayDate =
            match this.DayOfWeek with
            | DayOfWeek.Friday -> this.AddDays(+3.0)
            | DayOfWeek.Saturday -> this.AddDays(+2.0)
            | _ -> this.AddDays(+1.0)

        [<Extension>]
        member this.LastCalendarMonthEndDate =
            let firstDayOfMonth = DateTime.Parse(this.Month.ToString("00")+ "/01/" + this.Year.ToString("0000"))
            let lastCalendarMonthEnd = firstDayOfMonth.AddDays(-1.0)
            lastCalendarMonthEnd

        [<Extension>]
        member this.LastBusinessMonthEndDate =
            if this.LastCalendarMonthEndDate.IsWeekday then
                this.LastCalendarMonthEndDate
            else
                this.LastCalendarMonthEndDate.LastWeekdayDate

        [<Extension>]
        member this.IsCalendarMonthEndDate =
            let today = this
            let tomorrow = this.AddDays(1.0)
            if today.Month<>tomorrow.Month then
                true
            else
                false

        [<Extension>]
        member this.NextCalendarMonthEndDate =
            if this.IsCalendarMonthEndDate = true then
                let adjDate = this.AddDays(1.0)
                if adjDate.Month<>12 then
                    let nextMonth = adjDate.Month+1
                    let firstDayOfNextMonth = DateTime.Parse(nextMonth.ToString("00")+ "/01/" + adjDate.Year.ToString("0000"))
                    let nextCalendarMonthEnd = firstDayOfNextMonth.AddDays(-1.0)
                    nextCalendarMonthEnd
                else
                    let nextYear = adjDate.Year+1
                    let firstDayOfNextMonth = DateTime.Parse("01/01/" + nextYear.ToString("0000"))
                    let nextCalendarMonthEnd = firstDayOfNextMonth.AddDays(-1.0)
                    nextCalendarMonthEnd
            else
                if this.Month<>12 then
                    let nextMonth = this.Month+1
                    let firstDayOfNextMonth = DateTime.Parse(nextMonth.ToString("00")+ "/01/" + this.Year.ToString("0000"))
                    let nextCalendarMonthEnd = firstDayOfNextMonth.AddDays(-1.0)
                    nextCalendarMonthEnd
                else
                    let nextYear = this.Year+1
                    let firstDayOfNextMonth = DateTime.Parse("01/01/" + nextYear.ToString("0000"))
                    let nextCalendarMonthEnd = firstDayOfNextMonth.AddDays(-1.0)
                    nextCalendarMonthEnd

        [<Extension>]
        member this.LastCalendarWeekendDate =
            match this.DayOfWeek with
            | DayOfWeek.Sunday -> this.AddDays(-1.0)
            | DayOfWeek.Monday -> this.AddDays(-2.0)
            | DayOfWeek.Tuesday -> this.AddDays(-3.0)
            | DayOfWeek.Wednesday -> this.AddDays(-4.0)
            | DayOfWeek.Thursday -> this.AddDays(-5.0)
            | DayOfWeek.Friday -> this.AddDays(-6.0)
            | _ -> this.AddDays(-7.0)

        [<Extension>]
        member this.LastBusinessWeekendDate =
            match this.DayOfWeek with
            | DayOfWeek.Sunday -> this.AddDays(-2.0)
            | DayOfWeek.Monday -> this.AddDays(-3.0)
            | DayOfWeek.Tuesday -> this.AddDays(-4.0)
            | DayOfWeek.Wednesday -> this.AddDays(-5.0)
            | DayOfWeek.Thursday -> this.AddDays(-6.0)
            | DayOfWeek.Friday -> this.AddDays(-7.0)
            | _ -> this.AddDays(-1.0)

        [<Extension>]
        member this.LastCalendarQuarterEndDate =
            let month = this.Month

            match month with
            | 4 | 5 | 6 -> DateTime.Parse("03/31/"+this.Year.ToString("0000"))
            | 7 | 8 | 9 -> DateTime.Parse("06/30/"+this.Year.ToString("0000"))
            | 10 | 11 | 12 -> DateTime.Parse("09/30/"+this.Year.ToString("0000"))
            | _ -> DateTime.Parse("12/31/"+(this.Year-1).ToString("0000"))

        [<Extension>]
        member this.LastBusinessQuarterEndDate =
            if this.LastCalendarQuarterEndDate.IsWeekday then
                this.LastCalendarQuarterEndDate
            else
                this.LastCalendarQuarterEndDate.LastWeekdayDate

        [<Extension>]
        member this.LastCalendarSemiannualEndDate =
            match this.Month with
            | 7 | 8 | 9 | 10 | 11 | 12 -> DateTime.Parse("06/30/"+this.Year.ToString("0000"))
            | _ -> DateTime.Parse("12/31/"+(this.Year-1).ToString("0000"))

        [<Extension>]
        member this.LastBusinessSemiannualEndDate =
            if this.LastCalendarSemiannualEndDate.IsWeekday then
                this.LastCalendarSemiannualEndDate
            else
                this.LastCalendarSemiannualEndDate.LastWeekdayDate

        [<Extension>]
        member this.LastCalendarYearEndDate =
            DateTime.Parse("12/31/"+(this.Year-1).ToString("0000"))

        [<Extension>]
        member this.LastBusinessYearEndDate =
            if this.LastCalendarYearEndDate.IsWeekday then
                this.LastCalendarYearEndDate
            else
                this.LastCalendarYearEndDate.LastWeekdayDate

        [<Extension>]
        member this.RelativeDate(relativePeriod : string) =
            let rpText = RelativePeriodText(relativePeriod)
            let rpNumber = RelativePeriodNumber(relativePeriod)
            let mutable loopDate = this

            match rpText with
            | "D" ->
                let calcDate =
                    if int rpNumber<=0 then
                        for i in 0 .. -1 .. int rpNumber do
                            loopDate <- loopDate.LastWeekdayDate
                        loopDate
                    elif int rpNumber>2 then
                        for i in 1 .. 1 .. int rpNumber do
                            loopDate <- loopDate.NextWeekdayDate
                        loopDate
                    elif loopDate.IsWeekday then loopDate
                    else loopDate.NextWeekdayDate
                calcDate
            | "W" -> this.LastBusinessWeekendDate.AddDays(rpNumber*7.0)
            | "M" -> this.AddMonths(int rpNumber).LastBusinessMonthEndDate
            | "Q" -> this.AddMonths(int rpNumber * 3).LastBusinessQuarterEndDate
            | "S" -> this.AddMonths(int rpNumber * 6).LastBusinessSemiannualEndDate
            | "Y" -> this.AddYears(int rpNumber).LastBusinessYearEndDate
            | "AD" -> this.AddDays(rpNumber)
            | "AW" -> this.AddDays(rpNumber*7.0)
            | "AM" -> this.AddMonths(int rpNumber)
            | "AQ" -> this.AddMonths(int rpNumber*3)
            | "AS" -> this.AddMonths(int rpNumber*6)
            | "AY" -> this.AddYears(int rpNumber)
            | _ -> this