namespace KingmakerFox.ExtensionMethods

[<AutoOpen>]
module XmlLinqExtensions =

    open System.Diagnostics.CodeAnalysis
    open System.Xml.Linq

    // As most of these extnesions are just to simplify already existing methods, methods
    // will be excluded from tests and code coverage.

    type XNode with
        [<ExcludeFromCodeCoverage>]
        member this.Ancestors(name) = this.Ancestors(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.ElementsAfterSelf(name) = this.ElementsAfterSelf(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.ElementsBeforeSelf(name) = this.ElementsBeforeSelf(XName.Get name)    

    type XContainer with
        [<ExcludeFromCodeCoverage>]
        member this.Descendants(name) = this.Descendants(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.Element(name) = this.Element(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.Elements(name) = this.Elements(XName.Get name)

    type XElement with
        [<ExcludeFromCodeCoverage>]
        member this.AncestorsAndSelf(name) = this.AncestorsAndSelf(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.Attribute(name) = this.Attribute(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.Attributes(name) = this.Attributes(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.DescendantsAndSelf(name) = this.DescendantsAndSelf(XName.Get name)
        [<ExcludeFromCodeCoverage>]
        member this.SetAttributeValue(name, value) = this.SetAttributeValue(XName.Get name, value)
        [<ExcludeFromCodeCoverage>]
        member this.SetElementValue(name, value) = this.SetElementValue(XName.Get name, value)

    let XName s = XName.Get(s)