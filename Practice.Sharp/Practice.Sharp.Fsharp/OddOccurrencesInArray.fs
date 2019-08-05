module OddOccurrencesInArray
open Validators
open Monads.Operators
open Monads
open Constants

let findJustOneOddOccurrence =
    Array.groupBy id
        >> Array.choose (fun (key, v) -> match v.Length % 2 = 0 with
                                            | false  -> Some key
                                            | true -> None)
        >> function 
            | odds when odds.Length = 1 -> odds |> Array.head |> Success
            | _ -> Failure InvalidCountOfOddOcc

/// <summary>Get one value from array A (consisting of N integers) which does not occur in an even number of times
/// where N is an odd integer within the range [1..1,000,000],
/// each element of array A is an integer within the range [1..1,000,000,000].</summary>
let findOddOccurrence =
    evaluateArrayLength 1 1000000
        >=> evaluateArrayMax 1000000000
        >=> evaluateArrayMin 1
        >=> findJustOneOddOccurrence
        