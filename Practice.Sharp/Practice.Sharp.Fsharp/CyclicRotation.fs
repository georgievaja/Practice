module CyclicRotation
open Validators
open Monads.Operators

let rotate  (arr: int [], k: int) =
        let realK = k % arr.Length
        
        match realK = 0 with
        |true -> arr
        |false ->   let splitPoint = realK - 1
                    let arr1 = Array.sub arr 0 splitPoint |> Array.rev
                    let arr2 = Array.sub arr splitPoint (arr.Length - splitPoint) |> Array.rev
                    (arr1,arr2) ||> Array.append |> Array.rev

let doCyclicRotation minA maxA minN maxN arr k =
    (evaluateArrayLength minA maxA arr
                    >>= evaluateArrayMax maxN
                    >>= evaluateArrayMin minN)
    ++ evaluateRange minA maxA k
    <!> rotate
