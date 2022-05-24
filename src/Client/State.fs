namespace Client

open Client.Model
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser
open Elmish
open Elmish.React
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser

module State =

    let init () : Model * Cmd<Msg> =
        let page = IndexF (BannerModel.Empty)
        { CurrentPage = page }, Cmd.none

    let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
        match msg with

        | PageChange page -> { model with CurrentPage = page }, Cmd.none
        | IndexMsg indexMsg ->
            //let indexModel = Index.update indexMsg (IndexMsg >> dispatch)
            model, Cmd.none
        | _ -> model, Cmd.none