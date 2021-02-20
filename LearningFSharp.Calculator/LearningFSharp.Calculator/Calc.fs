module Calc

open System

let (|Decimal|_|) (x:string) =
  match Decimal.TryParse x with
  | true, value -> Some value
  | _ -> None

type Operation =
  | Sum
  | Subtract
  | Multiply
  | Divide

type operand =
  | OpenBracket
  | CloseBracket
  | Value of decimal
  | Operation of Operation

let (|Operation|_|) (x:string) =
  match x with
  | "+" -> Sum |> Some
  | "-" -> Subtract |> Some
  | "*" -> Multiply |> Some
  | "/" -> Divide |> Some
  | _ -> None
  
let parseOperand operand =
  match operand with
    | "(" -> Ok OpenBracket
    | ")" -> Ok CloseBracket
    | Decimal value -> Value(value) |> Ok
    | Operation operation -> Operation(operation) |> Ok
    | _ -> Error $"Invalid operand {operand}"
            
let getOperands (expr:string) =
  expr.Split(' ')
  |> Array.map parseOperand

let CalculateExpression(expr: string) =
//  match expr.Split(' ') with
//  | [| x; op; y |] -> parseExpression x op y
//  | _ -> Error $"Invalid expression {expr}"