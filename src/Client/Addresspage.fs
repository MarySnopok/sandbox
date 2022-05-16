module AddressPage

open Fulma
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Elmish.Navigation


type AddressModel =
        { BuildingNo : int
          Street : string
          City : string
          Postcode : string }

let init () =
      { BuildingNo = 41
        City = "London"
        Postcode = "P21 1XX"
        Street = "Liverpool St" }

let view model dispatch =
        Content.content [
            Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ]
        ] [
            Heading.h1 [ Heading.Props [ Style [ Margin "2rem" ] ] ] [ str "Address" ]
            Heading.h3 [ Heading.IsSubtitle ] [ str (sprintf "Building No: %d" model.BuildingNo) ]
            Heading.h3 [ Heading.IsSubtitle ] [ str (sprintf "Street: %s" model.Street) ]
            Heading.h3 [ Heading.IsSubtitle ] [ str (sprintf "City: %s" model.City) ]
            Heading.h3 [ Heading.IsSubtitle ] [ str (sprintf "Postcode: %s" model.Postcode) ]
        ]