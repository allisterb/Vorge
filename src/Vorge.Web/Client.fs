namespace Vorge.Web

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.DomUtility
open WebSharper.UI.Html
open WebSharper.UI.Templating

open rotjs
[<JavaScript>]
module Client =
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.
    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>

    [<SPAEntryPoint>]
    let Main () =
        let container = Vorge.Bootstrap.Controls.Container
        let o = 
            DisplayOptions (
                Width = 200,
                Height = 500     
            )
        let d = Display(o)
        d.Draw(0, 0, "A")
        JQuery("#main").Append(d.GetContainer()) |> ignore
        Doc.Empty
        
        
