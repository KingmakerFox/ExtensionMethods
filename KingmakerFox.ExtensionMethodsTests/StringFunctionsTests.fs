namespace CommonTest

open Common.Helpers
open Common.StringFunctions
open System.Diagnostics
open Xunit

type StringFunctionsTests() =

    [<Fact>]
    member this.RelativePeriodText_ExpectW() =
        let item = "-24W"
        let expectedResult = "W"
        let calculatedResult = RelativePeriodText(item)
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.RelativePeriodText_ExpectAW() =
        let item = "-24AW"
        let expectedResult = "AW"
        let calculatedResult = RelativePeriodText(item)
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.RelativePeriodNumber_Expect_neg24_1() =
        let item = "-24W"
        let expectedResult = -24
        let calculatedResult = int (RelativePeriodNumber(item))
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.RelativePeriodNumber_Expect_neg24_2() =
        let item = "-24AW"
        let expectedResult = -24
        let calculatedResult = int (RelativePeriodNumber(item))
        Assert.Equal(expectedResult,calculatedResult)

    [<Fact>]
    member this.JsonSerializeDeserialize() =
        let item = 24.0
        let expectedResult = 24.0
        let serializedDouble = JsonSerialize(item)
        let deserializedDouble = JsonDeserialize(serializedDouble) :?> float
        Assert.Equal(expectedResult,deserializedDouble)

    [<Fact>]
    member this.TestAddition()=
        Assert.Equal(1,1)
