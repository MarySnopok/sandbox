module IndexF

open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core
open Browser

(*open Product
*)
//https://thomasbandt.com/model-view-update?
//https://zaid-ajaj.github.io/the-elmish-book/#/chapters/fable/
// type of single item
type Item =
    { Title: string
      ImageUrl: string
    }

//type of state
type BannerModel =
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
let update (msg: Msg) model =
    match msg with
    | TogglePopup -> {model with Popup = not model.Popup}, Cmd.none
    | LoadItems -> model, Cmd.OfFunc.perform loadItems () ItemsLoaded 
    | ItemsLoaded items -> { model with Items = items }, Cmd.none



