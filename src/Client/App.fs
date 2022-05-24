module App

open Elmish
open Elmish.React
open Fable.Core.JsInterop

importSideEffects "./styles/global.sass"

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram IndexF.init IndexF.update IndexF.view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run