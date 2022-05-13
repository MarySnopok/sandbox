module LoadItems

//imulate api call
let LoadItems _ =
    [| { Title = "Special screws for wood and concrete."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "300 kr"
         Dimentions = "20 cm  15 cm  15 cm"
         Availability = "4-7 items"
         Cart = 10
         }
       { Title = "Drill and line tool on offer."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "1400 kr"
         Dimentions = $"30 cm  35 cm  45 cm"
         Availability = "3-6 items"
         Cart = 10
        }
       { Title = "Dewalt tools on a limited time offer."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "2000 kr"
         Dimentions = "50 cm  35 cm  45 cm"
         Availability = "2-9 items"
         Cart = 10
        }
       { Title = "Variety of tools of offer. Special price."
         ImageUrl =
           "https://images.prismic.io/proffsmagasinet-se/d288febc-500a-41b9-9e13-0a85e58a7f63_dewalt_se_960x960.png?auto=compress,format&rect=0,0,960,960&w=924&h=924"
         Price = "800 kr"
         Dimentions = "30 cm  35 cm  45 cm"
         Availability = "7-9 items"
         Cart = 10
         }
         |]