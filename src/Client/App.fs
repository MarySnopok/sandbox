namespace Client



open Elmish
open Elmish.React
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser
open NavigationF
open Model

module App =

    importSideEffects "./styles/global.sass"

    #if DEBUG
    open Elmish.Debug
    open Elmish.HMR
    #endif

    Program.mkProgram State.init State.update View.view
    //|> Program.toNavigable (UrlParser.parseHash NavigationF.pageParser) NavigationF.urlUpdate
    #if DEBUG
    |> Program.withConsoleTrace
    #endif
    |> Program.withReactSynchronous "elmish-app"
    #if DEBUG
    |> Program.withDebugger
    #endif
    |> Program.run