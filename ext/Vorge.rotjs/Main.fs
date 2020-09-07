namespace Vorge.rotjs

open WebSharper
open WebSharper.UI
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module Definition =
    let DisplayLayout =
        Pattern.EnumStrings "LayoutType" [
            "hex"
            "rect"
            "tile"
            "tile-gl"
            "term"
        ]

    let DisplayOptions =
        Pattern.Config "DisplayOptions" {
            Required = []
            Optional = [
                "width", T<int>
                "height", T<int>
                "transpose", T<bool>
                "layout", DisplayLayout.Type
                "fontSize", T<int>
                "spacing", T<int>
                "border", T<int>
                "forceSquareRatio", T<bool>
                "fontFamily", T<string>
                "fontStyle", T<string>
                "fg", T<string>
                "bg", T<string>
                "tileWidth", T<int>
                "tileHeight", T<int>
                "tileMap", T<Map<string, int array>>
                "tileSet", T<HTMLElement>
                "tileColorize", T<bool>
            ]
        }

    let Display = 
        Class "ROT.Display"
        |+> Static [
            Constructor(DisplayOptions? o)
        ]
        |+> Instance [
            "getContainer" => T<unit> ^-> T<HTMLElement>
            "draw" => (T<int> * T<int> * T<string>)  ^-> T<unit>
        ]

    let Assembly =
        Assembly [
            Namespace "rotjs.Resources" [
                Resource "Js" "rotjs/rot.min.js"
                |> AssemblyWide
            ]
            Namespace "rotjs" [
                 DisplayLayout
                 DisplayOptions
                 Display
            ]
        ]

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
