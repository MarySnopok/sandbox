module ButtonF

open Fulma
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop


let btn txt href options =
    Button.a
        [ Button.Color IsPrimary
          Button.Props [ Href href ]
          yield! options ]
        [ str txt ]