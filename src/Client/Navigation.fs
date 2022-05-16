module Navigation

    
open Fulma
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser
open Elmish.pageParser
open HomePage
open AddressPage
open PersonPage
open Index

[<RequireQualifiedAccess>]

let pageParser : Parser<_,_> =
    oneOf [
            map HomePage (s "home")
            map AddressPage (s "address")
            map PersonPage (s "person" </> str)
    ]

let urlUpdate (page: Index.Page option) _ =
    let page = page |> Option.defaultValue HomePage

    let model, _ = Some page |> init

    { model with
            Index.Model.CurrentPage = page;
            Index.SubModel = model.Index.SubModel }, Cmd.none