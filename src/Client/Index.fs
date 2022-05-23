module Index

open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser

open Product

//https://thomasbandt.com/model-view-update?
//https://zaid-ajaj.github.io/the-elmish-book/#/chapters/fable/
// type of single item
type Item =
    { Title: string
      ImageUrl: string
    }

//type of state
type Model =
    {
      Items: Item []
      Popup: bool
    }
    static member Empty =
        {
            Items = [||]
            Popup = false
        }

//list of possible actions
type Msg =
    | LoadItems
    | ItemsLoaded of Item []
    | TogglePopup



//initiate default state
let init () : Model * Cmd<Msg> = Model.Empty, Cmd.none

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
let update (msg: Msg) model =
    match msg with
    | TogglePopup -> {model with Popup = not model.Popup}, Cmd.none
    | LoadItems -> model, Cmd.OfFunc.perform loadItems () ItemsLoaded 
    | ItemsLoaded items -> { model with Items = items }, Cmd.none
 (*   | Log items ->
        for i in 0 .. items.Length - 1 do
            log $"We have {items.[i].Title}"
        { model with Items = items }, Cmd.none*)
    
  (*  | HideNotification -> {model with Notification = false}, Cmd.none*)

(*let itemDetails (item: Item) =
    div [ Class "details-container" ] [
         span [ Class "product-details" ] [ str item.Price ]
         span [ Class "product-details" ] [ str item.Dimentions ]
         span [ Class "product-details" ] [ str item.Availability ]
         span [ Class "product-details" ] [ str (string item.Cart) ]
    ]*)

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

let view (model: Model) dispatch =
    div [] [
        button [ OnClick(fun _ -> dispatch LoadItems) ] [ str "Load items" ]
        match model.Items with
        | [||] ->
            div [ Class "placeholder-message" ] [str "Press button to load more"]
        | items ->
            div [ Class "product-items-wrapper" ] (items |> Array.map itemView)
            button [ OnClick(fun _ -> dispatch TogglePopup) ] [ str "view details" ]
            if model.Popup
            then
                div [ Class "details-wrapper" ] [
                    str "forward to product page on click"
                (*div [ Class "details-container" ] [
                    span [ Class "product-description" ] [ str "Price"]
                    span [ Class "product-description" ] [ str "Dimentions"]
                    span [ Class "product-description" ] [ str "Items left"]
                    span [ Class "product-description" ] [ str "Product code"]
                    ]
                ]*)
          (*      div [ Class "details-wrapper" ] (items |> Array.map itemDetails)*)

    ]
    ]
