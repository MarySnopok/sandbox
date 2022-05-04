module Index

open Elmish

//https://thomasbandt.com/model-view-update?
//https://zaid-ajaj.github.io/the-elmish-book/#/chapters/fable/
// type of single item
type Item =
    { Title: string
      ImageUrl: string
      Link: string
      Price: string
      Dimentions: string
      Availability: string
      Cart: string
    }

//type of state
type Model =
    { Items: Item [] }
    static member Empty = { Items = [||] }

//list of possible actions
type Msg =
    | LoadItems
    | ItemsLoaded of Item []

//initiate default state
let init () : Model * Cmd<Msg> = Model.Empty, Cmd.none

//imulate api call
let loadItems _ =
    [| { Title = "Special offer on all Dewalt tools."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Link = "http://www.google.com/search?q=lemon"
         Price = "1200kr"
         Dimentions = "30 cm ; 35 cm ; 45 cm"
         Availability = "10 items"
         Cart = ""
         }
       { Title = "Special offer on all Dewalt tools."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Link = "http://www.google.com/search?q=orange"
         Price = "1200kr"
         Dimentions = $"30 cm ; 35 cm ; 45 cm"
         Availability = "10 items"
         Cart = ""
        }
       { Title = "Special offer on all Dewalt tools."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Link = "http://www.google.com/search?q=lime"
         Price = "1200kr"
         Dimentions = "30 cm ; 35 cm ; 45 cm"
         Availability = "10 items"
         Cart = ""
        }
       { Title = "Special offer on all Dewalt tools."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Link = "http://www.google.com/search?q=love"
         Price = "1200kr"
         Dimentions = "30 cm ; 35 cm ; 45 cm"
         Availability = "10 items"
         Cart = ""
         }
         |]

//update state based on Msg
let update (msg: Msg) model =
    match msg with
    | LoadItems -> model, Cmd.OfFunc.perform loadItems () ItemsLoaded
    | ItemsLoaded items -> { model with Items = items }, Cmd.none

open Fable.React
open Fable.React.Props

let itemDetails (item: Item) =
    div [ Class "details-container" ] [
         span [ Class "product-details" ] [
                str item.Price
            ]
         span [ Class "product-details" ] [
                str item.Dimentions
            ]
         span [ Class "product-details" ] [
                str item.Availability
            ]
         span [ Class "product-cart" ] [
                str item.Cart
            ]
    ]

let itemView (item: Item) =
    div [ Class "picture-container" ] [
        a [ Href item.Link ] [
            img [
                Class "picture"
                Src item.ImageUrl
            ]
            span [ Class "title" ] [
                str item.Title
            ]
        ]
    ]

let view (model: Model) dispatch =
    div [] [
        button [ OnClick(fun _ -> dispatch LoadItems) ] [
            str "Load Items"
        ]
        match model.Items with
        | [||] ->
            div [ Class "placeholder-message" ] [str "Press button to load more"]
        | items ->
            div [ Class "grid" ] (items |> Array.map itemView)
            div [ Class "extra-details-wrapper" ] (items |> Array.map itemDetails)
        //if model.Items = [||]
        //then
        //    div [ Class "placeholder-message" ]  [str "Press button to load more"]
        //else
        //    div [ Class "grid" ] (model.Items |> Array.map itemView)

    ]
    

// let view model dispatch =

//     div [ Class "grid" ] [
//         button [ OnClick(fun _ -> dispatch Decrement) ] [
//             span [ Class "mini-container" ] [
//                 str "-"
//             ]
//         ]
//         div [ Class "grid-item" ] [
//             span [ Class "number-container" ] [
//                 str (sprintf "%A" model)
//             ]

//         ]
//         button [ OnClick(fun _ -> dispatch Increment) ] [
//             span [ Class "mini-container" ] [
//                 str "+"
//             ]
//         ]
//     ]
