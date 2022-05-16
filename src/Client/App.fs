module App

open Fable.Core.JsInterop
open IndexF
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser
open NavigationF

importSideEffects "./styles/global.sass"


#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram IndexF.init IndexF.update IndexF.view
|> Program.toNavigable (UrlParser.parseHash NavigationF.pageParser) NavigationF.urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
