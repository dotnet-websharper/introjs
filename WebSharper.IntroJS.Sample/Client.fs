namespace WebSharper.IntroJS.Sample

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html
open WebSharper.UI.Templating
open WebSharper.IntroJS

[<JavaScript>]
module Client =
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.
    type IndexTemplate = Template<"index.html", ClientLoad.FromDocument>

    let People =
        ListModel.FromSeq [
            "John"
            "Paul"
        ]
       
    [<Require(typeof<WebSharper.IntroJS.Resources.MainTheme>)>]
    [<SPAEntryPoint>]
    let Main () =
        let intro = IntroJS.IntroJs()
        
        let title =
            h1 [] [text "I am the title."]
            
        let content =
            div []
                [
                    p [] [text "I am a paragraph inside"]
                    p [] [text "I am another paragraph"]
                ]
                
        let introButton =
            Doc.Button "Intro" [] (fun _ -> intro.Start() |> ignore)
                
        let container =
            div []
                [
                    title
                    content
                    introButton
                ]
            
        intro.AddSteps(
            [|
                IntroJS.StepConfig(
                    Element = title.Dom,
                    Intro = "This is the title"
                )
                IntroJS.StepConfig(
                    Element = introButton.Dom,
                    Intro = "This is the button you pressed"
                )
                IntroJS.StepConfig(
                    Element = content.Dom,
                    Intro = "This is the content on the page"
                )
                IntroJS.StepConfig(
                    Element = container.Dom,
                    Intro = "This is the whole page"
                )
            |]    
        )
        
        container
        |> Doc.RunById "main"
