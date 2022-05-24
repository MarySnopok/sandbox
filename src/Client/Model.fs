namespace Client

module Model =

    //https://thomasbandt.com/model-view-update?
    //https://zaid-ajaj.github.io/the-elmish-book/#/chapters/fable/
    // type of single item
    type BannerItem =
        {
            Title: string
            ImageUrl: string
        }

    //type of state
    type BannerModel =
        {
            Items: BannerItem []
            Popup: bool
        }
        static member Empty =
            {
                Items = [||]
                Popup = false
            }


    type ProductItem =
        {
            Price: string
            Dimentions: string
            Availability: bool
            Cart: int
        }

    //type of state
    type ProductModel =
        {
            Items: ProductItem []
        }
        static member Empty =
            {
                Items = [||]
            }


    type Page =
        | IndexF of BannerModel
        | Product of ProductModel

    type Model =
        {
            CurrentPage: Page
        }

    //list of possible actions
    type IndexMsg =
        | LoadItems
        | ItemsLoaded of BannerItem[]
        | TogglePopup
        //| Change

        //list of possible actions
    type ProductMsg =
        | LoadDetails

    type Msg =
        | IndexMsg of IndexMsg
        | ProductMsg of ProductMsg
        | PageChange of Page