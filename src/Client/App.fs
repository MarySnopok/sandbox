module App

open Elmish
open Elmish.React
open Fable.Core.JsInterop
open IndexF
open View
open NavigationF

importSideEffects "./styles/global.sass"

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram IndexF.init IndexF.update View.view
|> Program.toNavigable (UrlParser.parseHash NavigationF.pageParser) NavigationF.urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
