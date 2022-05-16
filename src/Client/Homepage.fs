module HomePage

open Fulma
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Elmish.Navigation

type HomeModel = { Title : string }

let init () = { Title = "Welcome! You're in the Home Page." }

let view (model: HomeModel) dispatch =
        div [] [
            Content.content [
                Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ]
            ] [
                Heading.h1 [] [ str model.Title ]
            ]
        ]