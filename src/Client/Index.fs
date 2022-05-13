module Index

open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser

//https://thomasbandt.com/model-view-update?
//https://zaid-ajaj.github.io/the-elmish-book/#/chapters/fable/
// type of single item
type Item =
    { Title: string
      ImageUrl: string
      Price: string
      Dimentions: string
      Availability: string
      Cart: int
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
    | Log of Item []
    | TogglePopup
   // | HidePopup

//initiate default state
let init () : Model * Cmd<Msg> = Model.Empty, Cmd.none
let log (banana: string ) =
    console.log(banana)
log "Hello it is a string"

//imulate api call
let loadItems _ =
    [| { Title = "Special screws for wood and concrete."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "300 kr"
         Dimentions = "20 cm  15 cm  15 cm"
         Availability = "4-7 items"
         Cart = 10
         }
       { Title = "Drill and line tool on offer."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "1400 kr"
         Dimentions = $"30 cm  35 cm  45 cm"
         Availability = "3-6 items"
         Cart = 10
        }
       { Title = "Dewalt tools on a limited time offer."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "2000 kr"
         Dimentions = "50 cm  35 cm  45 cm"
         Availability = "2-9 items"
         Cart = 10
        }
       { Title = "Variety of tools of offer. Special price."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "800 kr"
         Dimentions = "30 cm  35 cm  45 cm"
         Availability = "7-9 items"
         Cart = 10
         }
         |]

//update state based on Msg
let update (msg: Msg) model =
    match msg with
    | TogglePopup -> {model with Popup = not model.Popup}, Cmd.none
    | LoadItems -> model, Cmd.OfFunc.perform loadItems () ItemsLoaded 
    | ItemsLoaded items -> { model with Items = items }, Cmd.ofMsg ( Log items )
    | Log items ->
        for i in 0 .. items.Length - 1 do
            log $"We have {items.[i].Title}"
        { model with Items = items }, Cmd.none
    
    //    | HidePopup -> {model with Popup = false}, Cmd.none

let itemDetails (item: Item) =
    div [ Class "details-container" ] [
         span [ Class "product-details" ] [ str item.Price ]
         span [ Class "product-details" ] [ str item.Dimentions ]
         span [ Class "product-details" ] [ str item.Availability ]
         span [ Class "product-details" ] [ str (string item.Cart) ]
    ]

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
        button [ OnClick(fun _ -> dispatch LoadItems) ] [ str "Lololo" ]
        match model.Items with
        | [||] ->
            div [ Class "placeholder-message" ] [str "Press button to load more"]
        | items ->
            div [ Class "product-items-wrapper" ] (items |> Array.map itemView)
            button [ OnClick(fun _ -> dispatch TogglePopup) ] [ str "view details" ]
            if model.Popup
            then
                div [ Class "details-wrapper" ] [
                div [ Class "details-container" ] [
                    span [ Class "product-description" ] [ str "Price"]
                    span [ Class "product-description" ] [ str "Dimentions"]
                    span [ Class "product-description" ] [ str "Items left"]
                    span [ Class "product-description" ] [ str "Product code"]
                    ]
                ]
                div [ Class "details-wrapper" ] (items |> Array.map itemDetails)

    ]


            //if model.Items = [||]
        //then
        //    div [ Class "placeholder-message" ]  [str "Press button to load more"]
        //else
        //    div [ Class "grid" ] (model.Items |> Array.map itemView)