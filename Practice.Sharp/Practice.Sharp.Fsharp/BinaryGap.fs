module BinaryGap

open System

let evaluateRange (number: int) =   match number >= 1 && number <= 2147483647 with
                                    |true -> "valid"
                                    |false -> "invalid"

let intToBin (number: int) = Convert.ToString (number, 2)

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

let result (number: int) =
    intToBin number
            |> trimStart
            |> trimEnd
            |> split
            |> Array.maxBy (fun y -> y.Length)
            |> fun y -> y.Length