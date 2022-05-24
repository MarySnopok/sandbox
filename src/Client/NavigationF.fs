namespace Client


open Client.Model
open Elmish
open Elmish.React
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser
open Product
open Client.State
open Index

module NavigationF =
    let x = 0
//    let pageParser : Parser<_, Model> =
//        oneOf [
//            map (Model.Page.Product ) (s "product")
//            //map Model.Page.IndexF (s "indexF")
//        ]
//
//    let urlUpdate () model =
//        //let page = page |> Option.defaultValue (Model.Page.IndexF (Model.BannerModel.Empty))
//
//        //let model, _ = State.init ()
//
//        //{ model with CurrentPage = page }, Cmd.none
//        model, Cmd.none