module NavigationF

open Elmish
open Elmish.UrlParser
open HomePage
open AddressPage
open PersonPage
open IndexF


let pageParser : Parser<_, IndexF.Page> =
     oneOf [
            map IndexF.Page.HomePage (s "home")
            map IndexF.Page.AddressPage (s "address")
            map IndexF.Page.PersonPage (s "product" </> str)
        ]
        
let urlUpdate (page: IndexF.Page option) _ =
    let page = page |> Option.defaultValue IndexF.Page.HomePage

    let model, _ = Some page |> IndexF.init

    { model with
            CurrentPage = page;
            SubModel = model.SubModel }, Cmd.none