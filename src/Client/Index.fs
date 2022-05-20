module IndexF

open Fulma
open Elmish
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop

open Logo
open HomePage
open AddressPage
open PersonPage
open ButtonF

type Page =
    | HomePage
    | AddressPage
    | PersonPage of string

type SubModel =
    | HomePageModel of HomePage.HomeModel
    | AddressPageModel of AddressPage.AddressModel
    | PersonPageModel of PersonPage.PersonModel

type Model =
    { NameEntry: string
      CurrentPage: Page
      SubModel: SubModel }

type Msg = PersonNameChanged of string

let init page : Model * Cmd<Msg> =
    let page = page |> Option.defaultValue HomePage

    let subModel =
        match page with
        | HomePage -> HomePageModel (HomePage.init())
        | AddressPage -> AddressPageModel (AddressPage.init())
        | PersonPage name -> PersonPageModel (name |> PersonPage.init)

    { CurrentPage = page
      SubModel = subModel
      NameEntry = "" }, Cmd.none

let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    match msg with
    | PersonNameChanged name -> { model with NameEntry = name }, Cmd.none

let view (model : Model) (dispatch : Msg -> unit) =
    let navigationButton text href page model =
        btn text href [
            Button.IsFullWidth
            if model.CurrentPage = page then Button.Color IsSuccess
        ]
 
    div [Class "nav"  ] [
        Navbar.navbar [ ] [
            Navbar.Item.div [ ] [
                Heading.h1 [ ] [ str "Lorem ipsum dolor sit amet " ]
                //logo
                
            ]
        ]

        Content.content [] [
            Columns.columns [ Columns.IsCentered ] [
                Column.column [ Column.Width (Screen.All, Column.Is3) ] [
                    Control.div [ Control.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [
                        br []

                        Input.text [
                            Input.Value model.NameEntry
                            Input.Placeholder "Enter Name Here..."
                            Input.Props [ OnChange (fun ev -> dispatch (PersonNameChanged !!ev.target?value)) ]
                        ]
                    ]
                    Control.div [ Control.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [
                        br []
                        let href = sprintf "#product/%s" model.NameEntry
                        btn (sprintf "Set URL to '%s'" href) href [ ]
                    ]
                ]
            ]
        ]

        Container.container [ ] [
            Columns.columns [ Columns.Option.Props [ Style  [ Margin "3em" ] ] ] [
                Column.column [] [ navigationButton "HOME PAGE" "#home" HomePage model ]
                Column.column [] [ navigationButton "ADDRESS PAGE" "#address" AddressPage model ]
            ]
            Columns.columns [] [
                Column.column [] [
                    match model.SubModel with
                    | HomePageModel m -> HomePage.view m dispatch
                    | AddressPageModel m -> AddressPage.view m dispatch
                    | PersonPageModel m -> PersonPage.view m dispatch
                ]
            ]
        ]
    ]

