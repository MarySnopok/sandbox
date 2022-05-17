module ButtonF

open Fulma
open Fable.React
open Fable.React.Props


let btn txt href options =
    Button.a
        [ Button.Color IsPrimary
          Button.Props [ Href href ]
          yield! options ]
        [ str txt ]