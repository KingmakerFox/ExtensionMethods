namespace KingmakerFox.ExtensionMethodsTest

module XmlLinqExtensionsTests =

    open KingmakerFox.ExtensionMethods.XmlLinqExtensions
    open System.Xml.Linq
    open System.Diagnostics
    open Xunit

    type XmlLinqExtensionsTests() =
        
        [<Fact>]
        member this.TestXName() =
            let expectedResult = XName.Get("TestNode")
            let calculatedResult = KingmakerFox.ExtensionMethods.XmlLinqExtensions.XName "TestNode"
            Assert.Equal(expectedResult,calculatedResult)