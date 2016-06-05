namespace Common

module StringFunctions =

    open Common.StringExtensions

    let RelativePeriodText(relativePeriod:string) =
        if relativePeriod.Substring(relativePeriod.Length-2,1).IsNumeric=true then
            let relativePeriodText = relativePeriod.Substring(relativePeriod.Length-1,1).ToUpper()
            relativePeriodText
        else
            let relativePeriodText = relativePeriod.Substring(relativePeriod.Length-2,2).ToUpper()
            relativePeriodText

    let RelativePeriodNumber(relativePeriod:string) =
        if relativePeriod.Substring(relativePeriod.Length-2,1).IsNumeric=true then
            let relativePeriodNumber = relativePeriod.Substring(0,relativePeriod.Length-1)
            let relativePeriod = float relativePeriodNumber
            relativePeriod
        else
            let relativePeriodNumber = relativePeriod.Substring(0,relativePeriod.Length-2)
            let relativePeriod = float relativePeriodNumber
            relativePeriod
