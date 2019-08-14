namespace Practice.Sharp.Tests

open BinaryGap
open System
open Xunit
open Monads
open OddOccurrencesInArray
open Constants

module BinaryGapTests =


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
    [<InlineData("9")>]
    let ``Binary gap returns 2`` (data: string) =
        let result = 
            match getBinaryGap data with
                | Success result -> Some result
                | Failure _ -> None

        Assert.Equal(result, Some 2)

    [<Theory>]
    [<InlineData("529")>]
    [<InlineData("51272")>]
    let ``Binary gap returns 4`` (data: string) =
        let result = getBinaryGap data

        Assert.Equal(result, Success 4)

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

module OddOccurencesTests = 
    [<Fact>]
    let ``Odd occurrences finds nothing`` () =
       let data = [|9;3;9;3;9;9|]
       let result = findOddOccurrence data 
       
       Assert.Equal(result, Failure OddOccurenceNotFound)

    [<Fact>]
    let ``Odd occurrences returns 7`` () =
        let data = [|9;3;9;3;9;7;9|]
        let result = findOddOccurrence data 

        Assert.Equal(result, Success 7)

    [<Fact>]
    let ``Odd occurrences array range fails (too large)`` () =
        let data = [|1..1000001|]
        let result = findOddOccurrence data 

        Assert.Equal(result, Failure InvalidArrayRange)

    [<Fact>]
    let ``Odd occurrences array range fails (too small)`` () =
        let data = [||]
        let result = findOddOccurrence data 

        Assert.Equal(result, Failure InvalidArrayRange)

    [<Fact>]
    let ``Odd occurrences array fails - element in invalid range (min)`` () =
        let data = [|0;3;3|]
        let result = findOddOccurrence data 

        Assert.Equal(result, Failure InvalidArrayMin)

    [<Fact>]
    let ``Odd occurrences array fails - element in invalid range (max)`` () =
        let data = [|1000000001;3;3|]
        let result = findOddOccurrence data 

        Assert.Equal(result, Failure InvalidArrayMax)
