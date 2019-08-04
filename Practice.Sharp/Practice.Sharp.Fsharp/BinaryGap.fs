module BinaryGap

open System
open Monads.Operators
open Validators
open Extensions
open System.Runtime.InteropServices

let allOnes (num: int) =
    ((num+1) &&& num = 0) && (num <> 0)

let rec removeTrailing (num: int) =
    match num &&& 1 = 0 with
    | true      ->  removeTrailing (num >>> 1)
    | false     ->  num

let rec shift (steps: int) (num: int)= 
    match allOnes(num) with
        | true    ->  steps
        | false   ->  shift (steps + 1) (num ||| (num <<< 1))


let getBinaryGap =
    evaluateType
        >=> evaluateRange
        =>> (removeTrailing
             >> shift 0)
    

