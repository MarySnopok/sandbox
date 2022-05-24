namespace Client


open Client.Model
open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser
open Index


module View =

    let view (model : Model) (dispatch : Msg -> unit) =
        div [ Id "main" ] [
            match model.CurrentPage with
            | IndexF model ->
                Index.view model (IndexMsg >> dispatch )
            | Product model ->
                nothing

        ]