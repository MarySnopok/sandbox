module Logo

open Feliz
open Feliz.Bulma

let logo =
    Bulma.navbarBrand.div [
        Bulma.navbarItem.a [
            prop.href "https://safe-stack.github.io/"
            navbarItem.isActive
            prop.style [
                style.backgroundColor "teal"
                style.borderRadius 100
                style.marginLeft 20
            ]
            prop.children [
                Html.img [
                    prop.src "/heart.png"
                    prop.alt "logo"
                ]
            ]
        ]
    ]