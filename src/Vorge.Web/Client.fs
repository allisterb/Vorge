namespace Vorge.Web

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating

open rotjs
[<JavaScript>]
module Client =
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.
    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>

    [<SPAEntryPoint>]
    let Main () =
        let o = 
            DisplayOptions (
                Width = 4,
                Height = 5     
            )
        Display(o) |> ignore
        Doc.Empty
        
        //let d = new ROT.Display()
        //|> Doc.RunById "main"
