module View

open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser
open IndexF

let itemView (item: Item) =
    div [ Class "picture-container" ] [
        div [ OnClick(fun _ -> window.alert("Dont press on me!")) ] [
            img [
                Class "picture"
                Src item.ImageUrl
            ]
            span [ Class "title" ] [ str item.Title ]
        ]
    ]

let view (model: BannerModel) dispatch =
    div [] [
        match model.Items with
        | [||] ->
            button [ OnClick(fun _ -> dispatch LoadItems) ] [ str "Load items" ]
            div [ Class "placeholder-message" ] [str "Press button to load more"]
        | items ->
            div [ Class "product-items-wrapper" ] (items |> Array.map itemView)
            button [ OnClick(fun _ -> dispatch TogglePopup) ] [ str "info" ]
            if model.Popup
            then
                div [ Class "details-wrapper" ] [
                    str "click the product banner for extra details"
    ]
    ]



