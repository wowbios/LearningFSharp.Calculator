module Calc

open System

let operations =
  [
    "+", (+)
    "-", (-)
    "*", (*)
    "/", (/)
  ] |> Map.ofList

let calc x op y : Result<float, string> =
  match operations.TryFind op with
  | Some func -> func (float x) (float y) |> Ok
  | _ -> sprintf "Invalid operation %s" op |> Error
  
let public CalculateExpression(expr: string) : Result<float, string> =
  match expr.Split(' ') with
  | x when x.Length = 3 -> calc x.[0] x.[1] x.[2] 
  | _ -> sprintf "Invalid expression %s" expr |> Error