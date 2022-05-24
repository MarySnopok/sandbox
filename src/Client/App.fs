module App

open Elmish
open Elmish.React
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser
open NavigationF
open Mainmodel

importSideEffects "./styles/global.sass"

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram Mainmodel.init Mainmodel.update Mainmodel.view
|> Program.toNavigable (UrlParser.parseHash NavigationF.pageParser) NavigationF.urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
