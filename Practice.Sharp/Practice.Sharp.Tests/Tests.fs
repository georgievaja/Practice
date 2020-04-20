namespace Tests

open Lessons
open System
open Xunit
open Monads
open Constants
open Practice.Sharp.Csharp

module Sorts =
    [<Theory>]
    [<InlineData(5,2,4,6,1,3)>]
    [<InlineData(1)>]
    [<InlineData(2,2,2,34,34,2,1,1)>]
    [<InlineData(10,9,8,7,6,5,4,3,2,1)>]
    let ``Insert sort succeeds`` ([<ParamArray>] data: int[]) =
        let expected = Array.sort(data)
        let result = data.InsertionSort()

        Assert.Equal<int[]>(expected, result) 

    [<Theory>]
    [<InlineData(5,2,4,6,1,3)>]
    [<InlineData(1)>]
    [<InlineData(2,1)>]
    [<InlineData(5,2,1)>]
    [<InlineData(2,2,2,34,34,2,1,1)>]
    [<InlineData(10,9,8,7,6,5,4,3,2,1)>]
    [<InlineData(5,2,4,7,1,3,2,6)>]
    [<InlineData(0,-2,2,2,0,0,0,0)>]
    let ``Merge sort succeeds`` ([<ParamArray>] data: int[]) =
        let expected = Array.sort(data)
        let result = data.MergeSort(0, data.Length - 1)

        Assert.Equal<int[]>(expected, result) 

    [<Theory>]
    [<InlineData(5,2,4,6,1,3)>]
    [<InlineData(1)>]
    [<InlineData(2,2,2,34,34,2,1,1)>]
    [<InlineData(10,9,8,7,6,5,4,3,2,1)>]
    let ``Quick sort succeeds`` ([<ParamArray>] data: int[]) =
        data.QuickSort(0, data.Length-1)
        let expected = Array.sort(data)

        Assert.Equal<int[]>(expected, data) 

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

module CyclicRotation =

    [<Theory>]
    [<InlineData(3)>]
    [<InlineData(8)>]
    [<InlineData(13)>]
    [<InlineData(18)>]
    [<InlineData(98)>]
    [<InlineData(93)>]
    [<InlineData(53)>]
    let ``Rotation returns correct result`` (k: int) =
        let data = [|3; 8; 9; 7; 6|]
        let result = onIntArrayRotate data k
        let expected: int[] = [|9; 7; 6; 3; 8|]

        Assert.Equal(result, Success expected)

    [<Theory>]
    [<InlineData(-1)>]
    [<InlineData(101)>]
    let ``Rotation returns k out of range result`` (k: int) =
        let data = [|0..99|]
        let result = onIntArrayRotate data k

        Assert.Equal(result, Failure InvalidRange)

    [<Fact>]
    let ``Rotation returns array out of range result`` () =
        let data = [|0..100|]
        let result = onIntArrayRotate data 3

        Assert.Equal(result, Failure InvalidArrayRange)

    [<Fact>]
      let ``Rotation by 0 returns correct result`` () =
          let data = [|0;1;2;3;4;5|]
          let result = onIntArrayRotate data 0

          Assert.Equal(result, Success data)
