module Grid

open Fable.React
open Fable.React.Props

let grid =
    div [ Class "grid" ] [

        div [ Class "grid-item" ] [
            span [ "hihi" ]
            span [ "wowowwww" ]
        ]
        div [ Class "grid-item" ] [
            span [ "hihi" ]
            span [ "wowowwww" ]
        ]
        div [ Class "grid-item" ] [
            span [ "hihi" ]
            span [ "wowowwww" ]
        ]
        div [ Class "grid-item" ] [
            span [ "hihi" ]
            span [ "wowowwww" ]
        ]
    ]