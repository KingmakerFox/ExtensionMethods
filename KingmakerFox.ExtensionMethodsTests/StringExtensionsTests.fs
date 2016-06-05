namespace CommonTest

open Common.StringExtensions
open Common.Helpers
open Xunit


type StringExtensionsTest() =

    [<Fact>]
    member this.TestIsNumeric_ExpectFalse() =
        let item = "Tom"
        Assert.Equal(false,item.IsNumeric)

    [<Fact>]
    member this.TestIsNumeric_DoubleExpectTrue() =
        let item = "104.3456715554"
        Assert.Equal(true,item.IsNumeric)

    [<Fact>]
    member this.TestIsNumeric_IntExpectTrue() =
        let item = "104"
        Assert.Equal(true,item.IsNumeric)

    [<Fact>]
    member this.TestIsNumeric_MixedExpectFalse() =
        let item = "0CQ"
        Assert.Equal(false,item.IsNumeric)

    [<Fact>]
    member this.TestToBytes() =
        let hw = "Hello world!"
        let hwbytes = hw.ToBytes
        let hw' = BytesToString(hwbytes)
        Assert.Equal(hw,hw')

    [<Fact>]
    member this.TestIsDecimal_DecExpectTrue() =
        let item = "15.0"
        Assert.Equal(true,item.IsDecimal)

    [<Fact>]
    member this.TestLastCharacter() =
        let item = "0Q"
        let result = item.LastCharacter
        Assert.Equal("Q", result)

    [<Fact>]
    member this.TestLastTwoCharacters() =
        let item = "0CQ"
        let result = item.LastTwoCharacters
        Assert.Equal("CQ", result)