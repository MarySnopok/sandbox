module NavigationF

    
open Fulma
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser
open HomePage
open AddressPage
open PersonPage
open Browser.Types
open IndexF

//[<RequireQualifiedAccess>]
let pageParser : Parser<_, IndexF.Page> =
     oneOf [
            map IndexF.Page.HomePage (s "home")
            map IndexF.Page.AddressPage (s "address")
            map IndexF.Page.PersonPage (s "person" </> str)
        ]
        
let urlUpdate (page: IndexF.Page option) _ =
    let page = page |> Option.defaultValue IndexF.Page.HomePage

    let model, _ = Some page |> IndexF.init

    { model with
            CurrentPage = page;
            SubModel = model.SubModel }, Cmd.none