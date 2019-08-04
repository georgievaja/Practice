module BinaryGap

open System
open Monads.Operators
open Validators
open Extensions
open System.Runtime.InteropServices

// lame string method
let getMaxBinaryGap =
    evaluateType
    >=> evaluateRange
    =>> (Int64.convertToBinary
            >> String.trimStartOf '0'
            >> String.trimEndOf '0'
            >> String.splitBy '1'
            >> Array.tryMaxBy String.stringLength
            >> Option.map String.stringLength)


let rec removeTrailing (num: int) =
    match num &&& 1 = 0 with
    | true      ->  removeTrailing (num >>> 1)
    | false     ->  num

let rec shift (steps: int) (num: int)= 
    // find another method to discover all are 1s
    let before = Convert.ToString (num, 2)     
    match before.Contains("0") with
        | false     ->  steps
        | true      ->  shift (steps + 1) (num ||| (num <<< 1))


let getBinaryGap2 =
    evaluateType
        >=> evaluateRange
        =>> (removeTrailing
             >> shift 0)
    

