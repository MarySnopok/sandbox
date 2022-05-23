module Product

open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser

type Item =
    { 
      Price: string
      Dimentions: string
      Availability: bool
      Cart: int
    }

//type of state
type Model =
    {
      Items: Item []
    }
    static member Empty =
        {
            Items = [||]
        }

//list of possible actions
type Msg =
    | LoadItems

//initiate default state
let init () : Model * Cmd<Msg> = Model.Empty, Cmd.none

//imulate api call
let loadItems _ =
    [| { Price = "300 kr"
         Dimentions = "20 cm  15 cm  15 cm"
         Availability = true
         Cart = 10
         }
       { Price = "1400 kr"
         Dimentions = $"30 cm  35 cm  45 cm"
         Availability = false
         Cart = 0
        }
       { Price = "2000 kr"
         Dimentions = "50 cm  35 cm  45 cm"
         Availability = false
         Cart = 0
        }
        { Price = "800 kr"
         Dimentions = "30 cm  35 cm  45 cm"
         Availability = true
         Cart = 20
        }
     |]

//update state based on Msg
let update (msg: Msg) model =
    match msg with
    | LoadItems -> model, Cmd.OfFunc.perform loadItems ()


let itemDetails (item: Item) =
        if item.Availability
        then
            div [ Class "details-container" ] [
                 span [ Class "product-details" ] [ str item.Price ]
                 span [ Class "product-details" ] [ str item.Dimentions ]
                 span [ Class "product-details" ] [ str (string item.Cart) ]
            ]
        else
            div [ Class "details-container" ] [
               str "missed data"
            ]

//whats up with items -> array map
let view (model: Model, items: Item) dispatch =
    div [OnLoad(fun _ -> dispatch LoadItems)] [
            div [ Class "product-items-wrapper" ] [
                div [ Class "details-wrapper" ] [
                div [ Class "details-container" ] [
                    span [ Class "product-description" ] [ str "Price"]
                    span [ Class "product-description" ] [ str "Dimentions"]
                    span [ Class "product-description" ] [ str "Products left"]
                    ]
                ]
                div [ Class "details-wrapper" ] (items |> Array.map itemDetails)

            ]
    ]

