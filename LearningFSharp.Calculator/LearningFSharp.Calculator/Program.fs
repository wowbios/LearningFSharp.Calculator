open System

[<EntryPoint>]
let main argv =
    printf "Expression: "

    match Console.ReadLine() |> Calc.CalculateExpression with
    | Ok value -> sprintf "Result %f" value
    | Error e -> e
    |> printfn "%s"

    0 // return an integer exit code
