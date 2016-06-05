namespace KingmakerFox.ExtensionMethodsTest

open KingmakerFox.ExtensionMethods.Helpers
open System
open Xunit

type HelpersTests() =
    
    [<Fact>]
    member this.TestBytestoString() =
        let bytes = [|75uy; 105uy; 110uy; 103uy; 109uy; 97uy; 107uy; 101uy; 114uy; 32uy; 70uy; 111uy; 120uy|]
        let result = KingmakerFox.ExtensionMethods.Helpers.BytesToString(bytes)
        Assert.Equal(result,"Kingmaker Fox")
