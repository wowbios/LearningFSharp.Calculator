module Calc

open System

let private operations =
  [|
    "+", (+)
    "-", (-)
    "*", (*)
    "/", (/)
  |] |> Map.ofArray
  
let private parseFloat (x: string) =
  match Decimal.TryParse x with
  | true, value -> value |> Ok
  | _ -> Error $"Invalid value {x}"

let private parseFunction op =
  match operations.TryFind op with
  | Some operation -> operation |> Ok
  | _ -> Error $"Invalid operation {op}"
  
let parseExpression x op y =
   match (parseFloat x, parseFunction op, parseFloat y) with
   | (Ok v1, Ok func, Ok v2) -> func v1 v2 |> Ok
   | _ -> Error $"Invalid expression parts {x} {op} {y}" 

let CalculateExpression(expr: string) =
  match expr.Split(' ') with
  | [| x; op; y |] -> parseExpression x op y
  | _ -> Error $"Invalid expression {expr}"