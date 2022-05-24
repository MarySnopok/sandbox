namespace Client

open Client.Model
open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser
//open State


module Index =

    //initiate default state
    let init () : BannerModel * Cmd<Msg> = BannerModel.Empty, Cmd.none

    //imulate api call
    let loadItems _ =
        [| { Title = "Special screws for wood and concrete."
             ImageUrl =
               "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
             }
           { Title = "Drill and line tool on offer."
             ImageUrl =
               "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
            }
           { Title = "Dewalt tools on a limited time offer."
             ImageUrl =
               "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
            }
           { Title = "Variety of tools of offer. Special price."
             ImageUrl =
               "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
             }
             |]

    //update state based on Msg
    let update (msg: IndexMsg) model =
        match msg with
        | TogglePopup -> {model with Popup = not model.Popup}, Cmd.none
        | LoadItems -> model, Cmd.OfFunc.perform loadItems () ItemsLoaded
        | ItemsLoaded items -> { model with Items = items }, Cmd.none
        //| Change -> model, Cmd.ofMsg Mainmodel.PageChange

    let itemView (item: BannerItem) dispatch =
        div [ Class "picture-container" ] [
            div [ (* OnClick(fun _ -> dispatch (Msg.PageChange true) ) *)  ] [
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
                div [ Class "product-items-wrapper" ] (items |> Array.map (fun item -> itemView item dispatch) )
                button [ OnClick(fun _ -> dispatch TogglePopup) ] [ str "info" ]
                if model.Popup
                then
                    div [ Class "details-wrapper" ] [
                        str "click the product banner for extra details"
        ]
        ]