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
        
let findOddOccurrence minA maxA minN maxN =
    evaluateArrayLength minA maxA
        >=> evaluateArrayMax maxN
        >=> evaluateArrayMin minN
        >=> findJustOneOddOccurrence
        