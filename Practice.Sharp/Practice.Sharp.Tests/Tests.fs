namespace Practice.Sharp.Tests

open Lessons
open System
open Xunit
open Monads
open Constants

module BinaryGapTests =


    [<Theory>]
    [<InlineData(1)>]
    [<InlineData(15)>]
    [<InlineData(102)>]
    [<InlineData(2147483647)>]
    [<InlineData(9)>]
    [<InlineData(529)>]
    [<InlineData(51272)>]
    let ``Binary gap suceeds`` (data: int) =
        let succeeds = 
            match onGetBinaryGap data with
                | Success _ -> true
                | Failure _ -> false

        Assert.True(succeeds)


    [<Theory>]
    [<InlineData(9)>]
    let ``Binary gap returns 2`` (data: int) =
        let result = 
            match onGetBinaryGap data with
                | Success result -> Some result
                | Failure _ -> None

        Assert.Equal(result, Some 2)

    [<Theory>]
    [<InlineData(529)>]
    [<InlineData(51272)>]
    let ``Binary gap returns 4`` (data: int) =
        let result = onGetBinaryGap data

        Assert.Equal(result, Success 4)

    [<Theory>]
    [<InlineData(-1)>]
    [<InlineData(0)>]
    [<InlineData(null)>]
    let ``Binary gap fails`` (data: int) =
        let succeeds = 
            match onGetBinaryGap data with
                | Success _ -> true
                | Failure _ -> false

        Assert.False(succeeds)

module OddOccurencesTests = 
    [<Fact>]
    let ``Odd occurrences finds nothing`` () =
       let data = [|9;3;9;3;9;9|]
       let result = onGetOddOccurence data 
       
       Assert.Equal(result, Failure OddOccurenceNotFound)

    [<Fact>]
    let ``Odd occurrences finds 7`` () =
        let data = [|9;3;9;3;9;7;9|]
        let result = onGetOddOccurence data 

        Assert.Equal(result, Success 7)

    [<Fact>]
    let ``Odd occurrences finds 2`` () =
            let data =  2 :: [1..40000] @ [1..40000]
                        |> List.toArray
            let result = onGetOddOccurence data 

            Assert.Equal(result, Success 2)

    [<Fact>]
    let ``Odd occurrences array range fails (too large)`` () =
        let data = [|1..1000001|]
        let result = onGetOddOccurence data 

        Assert.Equal(result, Failure InvalidArrayRange)

    [<Fact>]
    let ``Odd occurrences array range fails (too small)`` () =
        let data = [||]
        let result = onGetOddOccurence data 

        Assert.Equal(result, Failure InvalidArrayRange)

    [<Fact>]
    let ``Odd occurrences array fails - element in invalid range (min)`` () =
        let data = [|0;3;3|]
        let result = onGetOddOccurence data 

        Assert.Equal(result, Failure InvalidArrayMin)

    [<Fact>]
    let ``Odd occurrences array fails - element in invalid range (max)`` () =
        let data = [|1000000001;3;3|]
        let result = onGetOddOccurence data 

        Assert.Equal(result, Failure InvalidArrayMax)
