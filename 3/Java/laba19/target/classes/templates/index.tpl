yieldUnescaped '<!DOCTYPE html>'
html(lang:'en') {
    head {
        meta('http-equiv':'"Content-Type" content="text/html; charset=utf-8"')
        title('Person List')
    }
    body {
        h2 ('A Groovy View with Spring Boot')
        
        h3 ("Message: $message")
       
        table (border: "1")  {
            tr {
               th("First Name")
               th("Last Name")
            }
            persons.each { person ->
                tr {
                   td("$person.firstName")
                   td("$person.lastName")
                }
            }
        }
    }
}
