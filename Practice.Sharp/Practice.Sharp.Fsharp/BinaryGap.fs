module BinaryGap

open System
open Monads
open Monads.Operators

let evaluateType (number: string) = match Int64.TryParse(number) with
                                    | true, num -> Success num
                                    | false, _ -> Failure "value is not an int64 type"

let evaluateRange (number: int64) = match (number |> int) >= 1 &&  (number |> int) <= 2147483647 with
                                        |true -> Success number
                                        |false -> Failure "invalid range"

let intToBin (number: int64) = Convert.ToString (number, 2)

let split (bin: string) = bin.Split('1', StringSplitOptions.RemoveEmptyEntries)

let rec trimStart (str: string) =
    match str.[0] = '0' with
        | true  -> str.Remove(0, 1)
                   |> trimStart 
        | false -> str

let rec trimEnd (str: string) =
    let lastLetter = str.Length - 1
    match str.[lastLetter] = '0' with
        | true -> str.Remove(lastLetter, 1)
                    |> trimEnd
        | false -> str

let result (number: string) =
    let func = evaluateType
                >=> evaluateRange
                =>> (intToBin
                        >> trimStart
                        >> trimEnd
                        >> split
                        >> Array.maxBy (fun y -> y.Length)
                        >> fun y -> y.Length)

    func number