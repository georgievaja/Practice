module Tests

open BinaryGap
open System
open Xunit
open Monads

[<Theory>]
[<InlineData("1")>]
[<InlineData("15")>]
[<InlineData("102")>]
[<InlineData("2147483647")>]
[<InlineData("9")>]
[<InlineData("529")>]
[<InlineData("51272")>]
let ``Binary gap suceeds`` (data: string) =
    let succeeds = 
        match getBinaryGap data with
            | Success _ -> true
            | Failure _ -> false

    Assert.True(succeeds)

[<Theory>]
[<InlineData("-1")>]
[<InlineData("0")>]
[<InlineData("ahoj")>]
[<InlineData(null)>]
[<InlineData("2147483648")>]
let ``Binary gap fails`` (data: string) =
    let succeeds = 
        match getBinaryGap data with
            | Success _ -> true
            | Failure _ -> false

    Assert.False(succeeds)
