module BannerModel

open Elmish

open Fable.React
open Fable.React.Props

type Item =
        { Title: string
          ImageUrl: string
          Price: string
          Dimentions: string
          Availability: string
          Cart: int
        }

type Model =
        {
          Items: Item []
          Popup: bool
          Notification: bool
        }
        static member Empty =
            {
                Items = [||]
                Popup = false
                Notification = true
            }

//list of possible actions
type Msg =
        | LoadItems
        | TogglePopup
        | HideNotification

//initiate default state
let init () : Model * Cmd<Msg> = Model.Empty, Cmd.none

