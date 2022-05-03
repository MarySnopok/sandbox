module Index

open Elmish

//https://thomasbandt.com/model-view-update?
//https://zaid-ajaj.github.io/the-elmish-book/#/chapters/fable/
// type of single item

// TODO JP project is growing, so let's separate into files (probably:
// - Model (with the data model, Item and Model and our Messages
// - State (with the update function)
// - View (with the view function and all the components)

type Item =
    { Title: string
      ImageUrl: string
      Link: string }

//type of state
// TODO JP for paging we'll have to add Current page in the model.
type Model =
    { Items: Item [] }
    static member Empty = { Items = [||] }

//list of possible actions
// TODO JP for paging we'll have to have messages that will trigger the page change, and messages that will load the data for each page
// will there be only numbers? Then we need something like ChangeToPage (pageNumber: int)
// will we have Previous and NextPage? Then we'll need these messages
type Msg =
    | LoadItems
    | ItemsLoaded of Item []

//initiate default state
let init () : Model * Cmd<Msg> = Model.Empty, Cmd.none

//imulate api call
// TODO JP let's still just fake it
// The fake API call needs to accept requested page number, and the response should include not only the loaded items, but also some indication of the total number of items/pages
let loadItems _ =
    [| { Title = "Special offer on all Dewalt tools."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Link = "http://www.google.com/search?q=lemon" }
       { Title = "Special offer on all Dewalt tools."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Link = "http://www.google.com/search?q=lime" }
       { Title = "Special offer on all Dewalt tools."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Link = "http://www.google.com/search?q=love" } |]

//update state based on Msg
let update (msg: Msg) model =
    match msg with
    | LoadItems -> model, Cmd.OfFunc.perform loadItems () ItemsLoaded // TODO JP here we'll have to replace the unit ( () ) with the page number
    | ItemsLoaded items -> { model with Items = items }, Cmd.none // TODO JP and here we'll have to handle the new payload, that will contain the max limit of items/pages



open Fable.React
open Fable.React.Props

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

        //if model.Items = [||]
        //then
        //    div [ Class "placeholder-message" ]  [str "Press button to load more"]
        //else
        //    div [ Class "grid" ] (model.Items |> Array.map itemView)


    // ul [ Class "grid" ] [
    //     li [ Class "list-item" ] [
    //         a [ Class "link-to-product" ] [
    //             div [ Class "picture-container" ] [
    //             // img [
    //             //     Class "picture"


    //             // ]
    //             ]
    //             h1 [ Class "list-item-heading" ] [
    //                 str "Special offer on all Dewalt tools."
    //             ]
    //         ]
    //     ]
    //     li [ Class "list-item" ] [
    //         a [ Class "link-to-product" ] [
    //             div [ Class "picture-container" ] [
    //             // img [
    //             //     Class "picture"


    //             // ]
    //             ]
    //             h1 [ Class "list-item-heading" ] [
    //                 str "Special offer on all Dewalt tools."
    //             ]
    //         ]
    //     ]
    // ]
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