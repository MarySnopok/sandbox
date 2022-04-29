module Index

type Model = int

type Msg =
    | Increment
    | Decrement

open Elmish

let init () : Model * Cmd<Msg> = 0, Cmd.none

let update (msg: Msg) count =
    match msg with
    | Increment -> count + 1, Cmd.none
    | Decrement -> count - 1, Cmd.none


open Fable.React
open Fable.React.Props

let view model dispatch =

    div [ Class "grid" ] [
        button [ OnClick(fun _ -> dispatch Decrement) ] [
            span [ Class "mini-container" ] [
                str "-"
            ]
        ]
        div [ Class "grid-item" ] [
            span [ Class "number-container" ] [
                str (sprintf "%A" model)
            ]

        ]
        button [ OnClick(fun _ -> dispatch Increment) ] [
            span [ Class "mini-container" ] [
                str "+"
            ]
        ]
    ]