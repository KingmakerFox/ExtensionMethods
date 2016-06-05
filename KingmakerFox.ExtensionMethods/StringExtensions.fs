[<AutoOpen>]
module StringExtensions

    open System
    open System.Runtime.CompilerServices

    // You need to declare all Extension Attributes explicitly
    [<assembly:Extension>]

    do()

    type String with
        [<Extension>]
        member this.IsInteger =
            match Int32.TryParse(this) with
            | (true, _) -> true
            | _ -> false

        [<Extension>]
        member this.IsFloat =
            match Single.TryParse(this) with
            | (true, _) -> true
            | _ -> false

        [<Extension>]
        member this.IsDecimal =
            match Decimal.TryParse(this) with
            | (true, _) -> true
            | _ -> false

        [<Extension>]
        member this.IsNumeric =
            if this.IsInteger=true then
                true
            elif this.IsFloat=true then
                true
            elif this.IsDecimal=true then
                true
            else
                false

        [<Extension>]
        member this.LastTwoCharacters =
            let twoChars = this.Substring(this.Length-2)
            twoChars

        [<Extension>]
        member this.LastCharacter =
            let lastChar = this.Substring(this.Length-1)
            lastChar

        [<Extension>]
        member this.ToBytes =
            let result = System.Text.Encoding.ASCII.GetBytes(this)
            result