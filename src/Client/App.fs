module App

open Fable.Core.JsInterop
open Index
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Elmish.Navigation
open Elmish.UrlParser

importSideEffects "./styles/global.sass"



#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif



Program.mkProgram Index.init Index.update Index.view
|> Program.toNavigable (UrlParser.parseHash Index.Navigation.pageParser) Index.Navigation.urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run