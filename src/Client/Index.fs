module Index

open System
// importing these smth to get the Random()
open System.IO
open Elmish
open Fable.Remoting.Client
open Shared

//adding Animal , Name (User Name) and NameInput state for input to the model
// type Model =
//     { Todos: Todo list
//       Input: string
//       Animal: string
//       Name: string
//       NameInput: string }

type Model = { Value: string }

//adding changeAnimal , SetInput Name and SetUserName as option
// type Msg =
//     | GotTodos of Todo list
//     | SetInput of string
//     | AddTodo
//     | AddedTodo of Todo
//     | ChangeAnimal
//     | SetInputName of string
//     | SetUserName


// let todosApi =
//     Remoting.createApi ()
//     |> Remoting.withRouteBuilder Route.builder
//     |> Remoting.buildProxy<ITodosApi>

// population of the model with Animal, Name and NameInput default value
// let init () : Model * Cmd<Msg> =
//     let model =
//         { Todos = []
//           Input = ""
//           Animal = "Animals"
//           Name = "stranger"
//           NameInput = "" }

//     let cmd = Cmd.OfAsync.perform todosApi.getTodos () GotTodos

//     model, cmd

// possible animals
// let animals =
//     [ "Dogs"
//       "Cats"
//       "Sheep"
//       "Horses"
//       "Cows" ]

//https://stackoverflow.com/questions/33312260/how-can-i-select-a-random-value-from-a-list-using-f
// let shuffleR (r: Random) xs = xs |> Seq.sortBy (fun _ -> r.Next())


// let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
//     match msg with
//     | GotTodos todos -> { model with Todos = todos }, Cmd.none
//     | SetInput value -> { model with Input = value }, Cmd.none
//     | AddTodo ->
//         let todo = Todo.create model.Input

//         let cmd = Cmd.OfAsync.perform todosApi.addTodo todo AddedTodo

//         { model with Input = "" }, cmd
//     | AddedTodo todo -> { model with Todos = model.Todos @ [ todo ] }, Cmd.none
//     // updating model with some black magic syntacs to pick random animal from array, control input state, assign user name
//     | ChangeAnimal -> { model with Animal = (animals |> shuffleR (Random()) |> Seq.head) }, Cmd.none
//     | SetInputName value -> { model with NameInput = value }, Cmd.none
//     | SetUserName ->
//         { model with
//             Name = model.NameInput
//             NameInput = "" },
//         Cmd.none

// open Feliz
// open Feliz.Bulma
open Fable.React
open Fable.React.Props

// open Title
open Grid

// let navBrand = Title.brand
let gridComponent = Grid.grid

let view model dispatch =
    div [ Class "grid" ] [
        span [] [
            str "Hello, "
            str model.Value
            str "! "
        ]
        span [] [
            str "How's life, "
            str model.Value
            str "?"
        ]
    ]
//container with h3 input field for name , buttons to add name and pick animal
// let containerTwoBox (model: Model) (dispatch: Msg -> unit) =
//     Bulma.box [
//         Bulma.content [
//             Html.h3 [
//                 prop.text $"Hi {model.Name}. Do you like {model.Animal}?"
//                 prop.style [ style.color "goldenrod" ]
//             ]
//             Bulma.field.div [
//                 field.isGrouped
//                 prop.children [
//                     Bulma.control.p [
//                         control.isExpanded
//                         prop.children [
//                             Bulma.input.text [
//                                 prop.value model.NameInput
//                                 prop.placeholder "type your name"
//                                 prop.onChange (fun x -> SetInputName x |> dispatch)
//                                 // dispatch where? what actuallt happening?
//                                 ]
//                         ]
//                     ]
//                     Bulma.control.p [
//                         Bulma.button.a [
//                             color.isPrimary
//                             //disabling button containerTwoValue.isValid -added to Shared
//                             prop.disabled (containerTwoValue.isValid model.NameInput |> not)
//                             prop.onClick (fun _ -> dispatch SetUserName)
//                             prop.text "add name"
//                         ]
//                     ]
//                     Bulma.control.p [
//                         Bulma.button.a [
//                             color.isPrimary
//                             //calling up the change animal on click
//                             prop.onClick (fun _ -> dispatch ChangeAnimal)
//                             prop.text "Pick random animal"
//                         ]
//                     ]
//                 ]

//                 ]
//         ]

//         ]



// let containerBox (model: Model) (dispatch: Msg -> unit) =
//     Bulma.box [
//         Bulma.content [
//             Html.ol [
//                 for todo in model.Todos do
//                     Html.li [ prop.text todo.Description ]
//             ]
//         ]
//         Bulma.field.div [
//             field.isGrouped
//             prop.children [
//                 Bulma.control.p [
//                     control.isExpanded
//                     prop.children [
//                         Bulma.input.text [
//                             prop.value model.Input
//                             prop.placeholder "add task"
//                             prop.onChange (fun x -> SetInput x |> dispatch)
//                             // dispatch where?
//                             ]
//                     ]
//                 ]
//                 Bulma.control.p [
//                     Bulma.button.a [
//                         color.isPrimary
//                         prop.disabled (Todo.isValid model.Input |> not)
//                         prop.onClick (fun _ -> dispatch AddTodo)
//                         prop.text "add"
//                     ]
//                 ]
//             ]
//         ]
//     ]


// let view (model: Model) (dispatch: Msg -> unit) =
//     Bulma.hero [
//         hero.isFullHeight
//         color.isPrimary
//         prop.style [
//             style.backgroundSize "cover"
//             style.backgroundImageUrl "https://unsplash.it/1200/900?random"
//             style.backgroundPosition "no-repeat center center fixed"
//         ]
//         prop.children [
//             Bulma.heroHead [
//                 Bulma.navbar [
//                     Bulma.container [ navBrand ]
//                 ]
//             ]
//             Bulma.heroBody [
//                 Bulma.container [
//                     Bulma.column [
//                         column.is6
//                         column.isOffset3
//                         prop.children [
//                             //changing title text and color style
//                             Bulma.title [
//                                 text.hasTextCentered
//                                 prop.text "Some heading text"
//                                 prop.style [ style.color "lightpink" ]
//                             ]
//                             //change the name by calling with abother argument
//                             containerTwoBox model dispatch
//                             containerBox model dispatch
//                             gridComponent model dispatch


//                             //look it up where actions are dispatching, coming from and when actually update happens (todos are living beyond the refrest while my conponents dont)? and whats about analogues of session or local storage. Check the Server.fs to get
// // whats going on there - it somehow creates models, and dispatch it to Saturn ?
//                             ]
//                     ]
//                 ]
//             ]
//         ]

//         ]