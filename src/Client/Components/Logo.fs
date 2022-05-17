module Logo

open Feliz
open Feliz.Bulma

let logo =
    Bulma.navbarBrand.div [
        Bulma.navbarItem.a [
            prop.href "https://safe-stack.github.io/"
            navbarItem.isActive
            prop.style [
                style.backgroundColor "red"
            ]
            prop.children [
                Html.img [
                    prop.src "/heart.png"
                    prop.alt "logo"
                ]
            ]
        ]
    ]