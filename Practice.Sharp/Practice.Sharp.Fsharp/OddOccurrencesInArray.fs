module OddOccurrencesInArray

open Validators
open Monads.Operators
open Monads
open Constants

let findJustOneOddOccurrence =
    Array.reduce(fun x y -> x ^^^ y)
    >> function
        |(num) when num = 0 -> Failure OddOccurenceNotFound
        |(num) -> Success num
        
/// <summary>Get one value from array A (consisting of N integers) which does not occur in an even number of times
/// where N is an odd integer within the range [1..1,000,000],
/// each element of array A is an integer within the range [1..1,000,000,000].</summary>
let findOddOccurrence =
    evaluateArrayLength 1 1000000
        >=> evaluateArrayMax 1000000000
        >=> evaluateArrayMin 1
        >=> findJustOneOddOccurrence
        