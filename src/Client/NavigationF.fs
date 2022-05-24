module NavigationF

open Elmish
open Elmish.React
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser
open Product
open Mainmodel
open IndexF



let pageParser : Parser<_, Mainmodel.Page> =
     oneOf [
            map Mainmodel.Page.Product (s "product")
            map Mainmodel.Page.IndexF (s "indexF")
        ]
        
let urlUpdate (page: Mainmodel.Page option) _ =
    let page = page |> Option.defaultValue Mainmodel.Page.index

    let model, _ = Some page |> Mainmodel.init

    { model with
            CurrentPage = page;
            SubModel = model.SubModel }, Cmd.none
