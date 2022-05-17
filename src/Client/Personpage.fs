module PersonPage

open Fulma
open Fable.React
open Fable.React.Props

type PersonModel = { Name : string }

let init fullName = { Name = fullName }

let view model dispatch =
        Content.content [
            Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ]
        ] [
            Heading.h1 [ Heading.Option.Props [ Style [ Margin "2rem" ] ] ] [ str "Person Details" ]
            Heading.h3 [ Heading.IsSubtitle ] [ str (sprintf "Full Name: %s" model.Name) ]
        ]