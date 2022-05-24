module Mainmodel

open Fable.React
open Fable.React.Props
open Fable.Core
open Browser
open Elmish
open Elmish.React
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser

open NavigationF
open IndexF
open Product




type Page =
    | IndexFModel of IndexF.BannerModel
    | ProductPageModel of Product.ProductModel

type Model =
    { CurrentPage: Page
      SubModel: SubModel
     }

type Msg =
     |PageChange of bool

let init page : Model * Cmd<Msg> =
    let page = page |> Option.defaultValue IndexF

    let subModel =
        match page with
        | IndexF -> IndexFModel (IndexF.init())
        | Product -> ProductPageModel (Product.init())

    { CurrentPage = page
      SubModel = subModel
    }, Cmd.none

let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    match msg with
    | PageChange -> {model with Change = not model.Change}, Cmd.none

let view (model : Model) (dispatch : Msg -> unit) =
    model.Change ? Product : IndexF