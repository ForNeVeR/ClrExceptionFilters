open System

let filter (obj : Object) =
    let ex = obj :?> Exception
    printfn "Filtering"
    ex.Data.["foo"] :?> string = "bar"

let filterException() =
    try
        let ex = Exception()
        ex.Data.["foo"] <- "bar"
        printfn "Throwing"
        raise ex
    with
    | ex when filter(ex) -> printfn "Caught"

[<EntryPoint>]
let main argv = 
    filterException()
    0
