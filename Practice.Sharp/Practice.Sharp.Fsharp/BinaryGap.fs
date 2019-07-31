module BinaryGap

open System
open Monads.Operators
open Validators
open Extensions

let getMaxBinaryGap =
    evaluateType
    >=> evaluateRange
    =>> (Int64.convertToBinary
            >> String.trimStartOf '0'
            >> String.trimEndOf '0'
            >> String.splitBy '1'
            >> Array.tryMaxBy String.stringLength
            >> Option.map String.stringLength)

