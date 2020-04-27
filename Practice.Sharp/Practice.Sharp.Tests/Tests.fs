namespace Tests

open Lessons
open System
open Xunit
open Monads
open Constants
open Practice.Sharp.Csharp.Sorts.Comparision
open Practice.Sharp.Csharp.Data_Structures
open Practice.Sharp.Csharp

module DataStructures =
    [<Fact>]
    let ``Queue head, tail are right`` () =
        let col = [|15;6;2;9;17;3;|] |> Array.map (fun v -> v :> obj)
        let queue = new Queue(col)
        Assert.Equal<int>(0, queue.Head)
        Assert.Equal<int>(0, queue.Tail)

        queue.Dequeue()
        queue.Dequeue()
        queue.Enqueue(10)
        Assert.Equal<int>(2, queue.Head)
        Assert.Equal<int>(1, queue.Tail)       

    [<Fact>]
    let ``Stack LIFO works`` () =
        let expected = [|15;6;2;9;17;3;|]
        let stack = new Stack<int>(10)
        stack.Push(15)
        stack.Push(12)
        stack.Pop() |> ignore
        stack.Push(6)
        stack.Push(2)
        stack.Push(9)
        stack.Push(17)
        stack.Push(3)

        Assert.Equal<int[]>(expected, stack.ToArray()) 

    [<Fact>]
    let ``Stack POP throws underflow exception`` () =
        let stack = new Stack<int>(10)
        stack.Push(15)
        stack.Push(12)
        stack.Pop() |> ignore
        stack.Pop() |> ignore

        let underflowPop = new Func<obj>(fun () -> stack.Pop() :> obj)
        Assert.Throws<InvalidOperationException>(underflowPop)

    [<Fact>]
    let ``Double linked list ``() =
        let exp = LinkedList()

        exp.Insert(1, "Jana")
        exp.Insert(2, "Theresa")
        exp.Insert(3, "Denise")

        let searchHead1 = exp.Search(3)
        Assert.Equal(searchHead1, exp.Head)

        exp.Delete(1)
        let searchHead2 = exp.Search(3)
        Assert.Equal(searchHead2, exp.Head)

        exp.Delete(3)
        let searchHead3 = exp.Search(2)
        Assert.Equal(searchHead3, exp.Head)

module Sorts =
    [<Theory>]
    [<InlineData(5,2,4,6,1,3)>]
    [<InlineData(1)>]
    [<InlineData(2,2,2,34,34,2,1,1)>]
    [<InlineData(10,9,8,7,6,5,4,3,2,1)>]
    let ``Insert sort succeeds`` ([<ParamArray>] data: int[]) =
        let expected = Array.sort(data)
        data.InsertionSort()

        Assert.Equal<int[]>(expected, data) 

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
        data.MergeSort(0, data.Length - 1)

        Assert.Equal<int[]>(expected, data) 

    [<Theory>]
    [<InlineData(5,2,4,6,1,3)>]
    [<InlineData(1)>]
    [<InlineData(2,1)>]
    [<InlineData(5,2,1)>]
    [<InlineData(2,2,2,34,34,2,1,1)>]
    [<InlineData(10,9,8,7,6,5,4,3,2,1)>]
    [<InlineData(5,2,4,7,1,3,2,6)>]
    [<InlineData(0,-2,2,2,0,0,0,0)>]
    let ``Heap sort succeeds`` ([<ParamArray>] data: int[]) =
        let expected = Array.sort(data)
        data.HeapSort()

        Assert.Equal<int[]>(expected, data) 

    [<Theory>]
    [<InlineData(5,2,4,6,1,3)>]
    [<InlineData(1)>]
    [<InlineData(2,2,2,34,34,2,1,1)>]
    [<InlineData(10,9,8,7,6,5,4,3,2,1)>]
    let ``Quick sort succeeds`` ([<ParamArray>] data: int[]) =
        let expected = Array.sort(data)
        data.QuickSort(0, data.Length-1)

        Assert.Equal<int[]>(expected, data) 

module BinaryGapsCsharpRecursionTests =
    [<Theory>]
    [<InlineData(529, 4)>]
    [<InlineData(51272, 4)>]
    [<InlineData(9, 2)>]
    [<InlineData(20, 1)>]
    [<InlineData(15, 0)>]
    [<InlineData(32, 0)>]
    [<InlineData(1041, 5)>]
    let ``Binary gap returns correct result`` (data: int, expected: int) =
        let result = BinaryGapRecursion.CountBinaryGap(data)

        Assert.Equal(result, expected)

    [<Theory>]
    [<InlineData(-1)>]
    [<InlineData(0)>]
    [<InlineData(null)>]
    let ``Binary gap returns -1 for invalid range`` (data: int) =
        let result = BinaryGapRecursion.CountBinaryGap(data)

        Assert.Equal(result, -1)

module BinaryGapsCsharpIterationTests =
    [<Theory>]
    [<InlineData(529, 4)>]
    [<InlineData(51272, 4)>]
    [<InlineData(9, 2)>]
    [<InlineData(20, 1)>]
    [<InlineData(15, 0)>]
    [<InlineData(32, 0)>]
    [<InlineData(1041, 5)>]
    let ``Binary gap returns correct result`` (data: int, expected: int) =
        let result = BinaryGapIteration.CountBinaryGap(data)

        Assert.Equal(result, expected)

    [<Theory>]
    [<InlineData(-1)>]
    [<InlineData(0)>]
    [<InlineData(null)>]
    let ``Binary gap returns -1 for invalid range`` (data: int) =
        let result = BinaryGapIteration.CountBinaryGap(data)

        Assert.Equal(result, -1)

module BinaryGapFsharpTests =
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

module CyclicRotationCsharp =
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
        let result = CyclicRotation.RotateArray(data, k)
        let expected: int[] = [|9; 7; 6; 3; 8|]
        Assert.Equal<int[]>(expected, result)

    [<Fact>]
    let ``Extreme - empty array`` () =
      let result = CyclicRotation.RotateArray([||], 1)

      Assert.Equal<int[]>([||], result)

    [<Fact>]
    let ``Rotation by 1 returns correct result`` () =
      let data = [|0;0;0|]
      let expected = [|0;0;0|]
      let result = CyclicRotation.RotateArray(data, 0)

      Assert.Equal<int[]>(expected, result)

    [<Fact>]
    let ``Rotation by 0 returns correct result`` () =
        let data = [|0;1;2;3;4;5|]
        let expected = [|0;1;2;3;4;5|]
        let result = CyclicRotation.RotateArray(data, 0)

        Assert.Equal<int[]>(expected, result)
          
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
