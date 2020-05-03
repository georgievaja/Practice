namespace Tests

open Lessons
open System
open Xunit
open Monads
open Constants
open Practice.Sharp.Csharp.Sorts.Comparision
open Practice.Sharp.Csharp.Data_Structures
open Practice.Sharp.Csharp
open System.Linq

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

module PrimeNumbers =
    [<Fact>]
    let ``PeaksSlice upper extreme returns correct result`` () =
        let arr = (Array.create 100000 0)
        let result = PrimeNumbers.CountPeaksSlices(arr)

        Assert.Equal(0, result)

        let arr2 = (Array.create 100000 1000000000)
        let result2 = PrimeNumbers.CountPeaksSlices(arr2)
        Assert.Equal(0, result2)

    [<Theory>]
    [<InlineData(1, 1, 4, 3)>]
    [<InlineData(3, 1, 1, 4, 3, 1,45,1,3,1)>]
    [<InlineData(1, 1, 1, 4, 3, 1,45,1,1,1,1,1,1)>]
    [<InlineData(1, 10, 1, 4, 3, 1,45,1,1,1,1,1,10)>]
    [<InlineData(0, 1, 2, 3, 3, 3, 3, 1, 2, 3, 4, 4, 2)>]
    [<InlineData(1, 1, 2, 3, 4, 3, 3, 1, 2, 3, 4, 4, 2)>]
    [<InlineData(3, 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2)>]
    let ``PeaksSlice returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = PrimeNumbers.CountPeaksSlices(data)

        Assert.Equal(expected, result)

    [<Fact>]
    let ``Flags upper extreme returns correct result`` () =
        let arr = (Array.create 400000 10000)
        let result = PrimeNumbers.CountFlags(arr)

        Assert.Equal(0, result)

        let arr2 = [|0..100000|]
        let result2 = PrimeNumbers.CountFlags(arr2)
        Assert.Equal(0, result2)

    [<Theory>]
    [<InlineData(3, 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2)>]
    [<InlineData(0,1,1,1,1,1,1,1,1,1,1,1,1)>]
    [<InlineData(0,1)>]
    let ``Flags returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = PrimeNumbers.CountFlags(data)

        Assert.Equal(expected, result)

    [<Theory>]
    [<InlineData(3, 9)>]
    [<InlineData(8, 24)>]
    [<InlineData(1, 1)>]
    [<InlineData(2, 2147483647)>]
    let ``Divisors returns correct result`` (expected: int, n: int) =
        let result = PrimeNumbers.CountNumberOfDivisors(n)

        Assert.Equal(expected, result)

    [<Theory>]
    [<InlineData(false, 9)>]
    [<InlineData(true, 3)>]
    let ``PrimeNumbers returns correct result`` (expected: bool, n: int) =
        let result = PrimeNumbers.IsPrimeNumber(n)

        Assert.Equal(expected, result)

module MaxSlice =
    [<Theory>]
    [<InlineData(17, 3, 2, 6, -1, 4, 5, -1, 2)>]
    [<InlineData(0, 3, 3, 3)>]
    [<InlineData(3, 3, 3, 3, 3)>]
    [<InlineData(2, 3, 2, 1, 3)>]
    let ``DoubleMaxSlice returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = MaxSlice.CountDoubleMaxSlice(data)

        Assert.Equal(expected, result)

    [<Theory>]
    [<InlineData(5, 3, 2, -6, 4, 0)>]
    [<InlineData(-1)>]
    [<InlineData(5,5)>]
    [<InlineData(10,5,5)>]
    [<InlineData(2,1,-5,2)>]
    [<InlineData(20,5,5, -10, 20)>]
    [<InlineData(-1000000, -1000000, -1000000)>]
    [<InlineData(2000000, 1000000, 1000000)>]
    let ``MaxSliceSum returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = MaxSlice.CountMaxSliceSum(data)

        Assert.Equal(expected, result)

    [<Theory>]
    [<InlineData(0)>]
    [<InlineData(0, 23171)>]
    [<InlineData(0, 23171, 23171)>]
    [<InlineData(356, 23171, 21011, 21123, 21366, 21013, 21367)>]
    let ``CountMaxProfit returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = MaxSlice.CountMaxProfit(data)

        Assert.Equal(expected, result)

    [<Theory>]
    [<InlineData(10, 5, -7, 3, 5, -2, 4, -1)>]
    [<InlineData(20, 3, 2, 6, -1, 4, 5, -1, 2)>]
    let ``MaxSlice returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = MaxSlice.CountMaxSlice(data)

        Assert.Equal(expected, result)

module EquiLeader =
    [<Theory>]
    [<InlineData(2, 4, 3, 4, 4, 4, 2)>]
    let ``EquiLeader returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = EquiLeader.GetEquiLeadersCount(data)

        Assert.Equal(expected, result)

module Dominator =
    [<Fact>]
    let ``Dominator extremes returns correct result`` () =
        let data = Array.create 100000 -2147483648
        let result = Dominator.FindDominator(data)

        Assert.Equal(99999, result)

        let data2 = Array.create 100000 2147483647
        let result2 = Dominator.FindDominator(data2)

        Assert.Equal(99999, result2)
    
    [<Theory>]
    [<InlineData(7, 3, 4, 3, 2, 3, -1, 3, 3)>]
    [<InlineData(0,1)>]
    [<InlineData(-1)>]
    let ``Dominator returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = Dominator.FindDominator(data)

        Assert.Equal(expected, result)

module StoneWall =
    [<Theory>]
    [<InlineData(7, 8, 8, 5, 7, 9, 8, 7, 4, 8)>]
    [<InlineData(1,1)>]
    [<InlineData(1,1,1)>]
    [<InlineData(2,1,8)>]
    let ``StoneWall returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = StoneWall.CountBlock(data)

        Assert.Equal(expected, result)

module Fish =
    [<Fact>]
    let ``Fish example returns correct result`` () =
        let a = [|4;3;2;1;5|]
        let b = [|0;1;0;0;0|]
        let result = Fish.GetNumberOfSurviving(a,b)

        Assert.Equal(2, result)
    
    [<Fact>]
    let ``Fish returns correct result`` () =
        let a = [|1..100000|]
        let b = Array.create 100000 1
        let result = Fish.GetNumberOfSurviving(a,b)

        Assert.Equal(100000, result)

        let a2 = [|1..100000|]
        let b2 = Array.create 99999 1
        let br = b2.Append(0) |> Seq.toArray

        let result2 = Fish.GetNumberOfSurviving(a2,br)
        Assert.Equal(1, result2)

        let a2 = [|1..100000|]
        let b2 = Array.create 99999 0
        let br = b2.Append(1) |> Seq.toArray

        let result2 = Fish.GetNumberOfSurviving(a2,br)
        Assert.Equal(100000, result2)

module Nesting =
    [<Theory>]
    [<InlineData(0, "ahoj")>]
    [<InlineData(0, "[ahoj]")>]
    [<InlineData(1, "")>]
    [<InlineData(0, "{[()()]}")>]
    [<InlineData(0, "[()()]}")>]
    [<InlineData(0, "())")>]
    [<InlineData(1, "(()(())())")>]
    let ``Single nesting returns correct result`` (expected: int, str: string) =
        let result = Nesting.CheckSingleNesting(str)

        Assert.Equal(expected, result) 

    [<Theory>]
    [<InlineData(1, "ahoj")>]
    [<InlineData(1, "[ahoj]")>]
    [<InlineData(1, "")>]
    [<InlineData(1, "{[()()]}")>]
    [<InlineData(0, "[()()]}")>]
    [<InlineData(0, "([)()]")>]
    let ``Multiple nesting returns correct result`` (expected: int, str: string) =
        let result = Nesting.CheckMultipleNesting(str)

        Assert.Equal(expected, result) 

module Triangle =
   [<Fact>]
   let ``Triangle upper extreme returns correct result`` () =
       let arr = (Array.create 100000 2147483647)
       let result = Triangle.TriangleExists(arr)

       Assert.Equal(1, result)

       let arr2 = (Array.create 100000 -2147483647)
       let result2 = Triangle.TriangleExists(arr2)

       Assert.Equal(0, result2)
   
   [<Theory>]
   [<InlineData(1, 10, 2, 5, 1, 8, 20)>]
   [<InlineData(0)>]
   [<InlineData(0, 10, 50, 5, 1)>]
   let ``Triangle returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
       let result = Triangle.TriangleExists(data)

       Assert.Equal(expected, result) 

module NumberOfDiscIntersections =
    [<Fact>]
    let ``MaxProductOfThree upper extreme returns correct result`` () =
        let arr = (Array.create 100000 2147483647)
        let result = MaxProductOfThree.CountMaxProductOfThree(arr)

        Assert.Equal(2147483647, result)
    
    [<Theory>]
    [<InlineData(11, 1, 5, 2, 1, 4, 0)>]
    [<InlineData(0)>]
    [<InlineData(3, 2147483647, 0, 0, 0)>]
    let ``NumberOfDiscIntersections returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = NumberOfDiscIntersections.Count(data)

        Assert.Equal(expected, result)

module MaxProductOfThree =
    [<Fact>]
    let ``MaxProductOfThree upper extreme returns correct result`` () =
        let arr = (Array.create 100000 1000)
        let result = MaxProductOfThree.CountMaxProductOfThree(arr)

        Assert.Equal(1000000000, result)

    [<Theory>]
    [<InlineData(60, -3, 1, 2, -2, 5, 6)>]
    [<InlineData(150, -10, -3, 4, 5, 5)>]
    [<InlineData(-24, -10, -3, -2, -4, -5)>]
    [<InlineData(20000, -1000, 3, 4, 5, 1000)>]
    let ``MaxProductOfThree returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = MaxProductOfThree.CountMaxProductOfThree(data)

        Assert.Equal(expected, result)

module Distinct =
    [<Fact>]
    let ``Distinct upper extreme returns correct result`` () =
        let arr = [|1..100000|]
        let result = Distinct.CountDistinctInt(arr)

        Assert.Equal(100000, result)

    [<Theory>]
    [<InlineData(2, 1, 0, 0, 0, 1)>]
    [<InlineData(3, 3, 1, 4, 1, 1)>]
    [<InlineData(3, 2, 1, 1, 2, 3, 1)>]
    [<InlineData(2, -1000000, 1000000)>]
    [<InlineData(0)>]
    let ``Distinct returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = Distinct.CountDistinctInt(data)

        Assert.Equal(expected, result)

module PassingCars =
    
    [<Fact>]
    let ``PassingCars upper extremes returns correct result`` () =
        let arr = (Array.create 100000 0)
        let result = PassingCars.CountCars(arr)

        Assert.Equal(0, result)

        let arr2 = (Array.create 99999 0)
        let arr3 = arr2.Append(1) |> Seq.toArray
        let result2 = PassingCars.CountCars(arr3)

        Assert.Equal(99999, result2)

    [<Theory>]
    [<InlineData(3, 1, 0, 0, 0, 1)>]
    [<InlineData(5, 0, 1, 0, 1, 1)>]
    [<InlineData(0, 0, 0, 0, 0, 0)>]
    [<InlineData(0, 1)>]
    let ``PassingCars returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = PassingCars.CountCars(data)

        Assert.Equal(expected, result)

module MinAvgTwoSlice =
    [<Theory>]
    [<InlineData(1, 4, 2, 2, 5, 1, 5, 8)>]
    [<InlineData(0, 2, 2, 2, 2, 2, 2, 2)>]
    [<InlineData(0, 1)>]
    let ``MinAvgTwoSlice returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = MinAvgTwoSlice.FindStartingPoint(data)

        Assert.Equal(expected, result)

    [<Fact>]
    let ``MinAvgTwoSlice returns correct result efficiently`` () =
        let arr = [|-10000..10000|]

        let result = MinAvgTwoSlice.FindStartingPoint(arr)
        
        Assert.Equal(0, result)

module GenomicRangeQuery =
    [<Fact>]
    let ``GenomicRangeQuery N, M high extremes returns correct result`` () =
        let p = [|1..50000|]
        let q = [|1..50000|] |> Array.rev
        let chars = "CAGCCTAACG"
        let res = Enumerable.Repeat(chars, 10000) |> String.Concat
        let result = GenomicRangeQuery.GetMinimalNucleotideFactors(p, q, res)
        Assert.Equal<int[]>(result, result)

    [<Fact>]
    let ``GenomicRangeQuery N high extremes returns correct result`` () =
        let p = [|2;5;0|]
        let q = [|4;5;6|]
        let chars = "CCCCCCCCCC"
        let res = Enumerable.Repeat(chars, 10000) |> String.Concat
        let result = GenomicRangeQuery.GetMinimalNucleotideFactors(p, q, res)
        Assert.Equal<int[]>([|2;2;2|], result)

    [<Fact>]
    let ``GenomicRangeQuery N low extremes returns correct result`` () =
        let p = [|0;0;0|]
        let q = [|0;0;0|]

        let result = GenomicRangeQuery.GetMinimalNucleotideFactors(p, q, "C")
        Assert.Equal<int[]>([|2;2;2|], result)

    [<Fact>]
    let ``GenomicRangeQuery returns correct result`` () =
        let p = [|2;5;0|]
        let q = [|4;5;6|]

        let result = GenomicRangeQuery.GetMinimalNucleotideFactors(p, q, "CAGCCTA")
        Assert.Equal<int[]>([|2;4;1|], result)

module CountDiv = 
    [<Theory>]
    [<InlineData(0, 1, 6, 11)>]
    [<InlineData(1, 1, 3, 2)>]
    [<InlineData(3, 6, 11, 2)>]
    [<InlineData(1, 1, 5, 5)>]
    [<InlineData(1, 1, 2000000000, 2000000000)>]
    [<InlineData(2000000000, 1, 2000000000, 1)>]
    let ``CountDiv returns correct result`` (expected: int, first: int, last: int, div: int) =
        let result = CountDiv.CountDivisibleNum(first, last, div)

        Assert.Equal(expected, result)

module PrefixSums =
    [<Fact>]
    let ``PrefixSums returns correct result`` () =
        let arr = [|1..100000|]

        let result = PrefixSums.CountPrefixSums(arr)

        let res = PrefixSums.MushroomPicker([|2;3;7;5;1;3;9|], 4, 6)
        Assert.Equal(25, res)

module PermCheck =
    [<Theory>]
    [<InlineData(0, 1, 60, 2, 3, 4)>]
    [<InlineData(1, 1, 5, 2, 3, 4)>]
    [<InlineData(0, 1, 1, 2, 3, 4)>]
    [<InlineData(0, 1, 40, 3)>]
    [<InlineData(1, 1, 2)>]
    [<InlineData(0, 6, 5, 4)>]
    [<InlineData(1, 1)>]
    let ``PermCheck returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = PermCheck.ArrayIsPermutation(data)

        Assert.Equal(expected, result)

    [<Fact>]
    let ``PermCheck extremes returns correct result`` () =
        let arr = [|1..100000|]

        let result = PermCheck.ArrayIsPermutation(arr)

        Assert.Equal(1, result)

    [<Fact>]
    let ``PermCheck elements extremes returns correct result`` () =
        let arr = [|1; 1000000000|]
        let result = PermCheck.ArrayIsPermutation(arr)

        Assert.Equal(0, result)


module MissingInteger =
    [<Theory>]
    [<InlineData(5, 1, 3, 6, 4, 1, 2)>]
    [<InlineData(4, 1, 2, 3)>]
    [<InlineData(1, -1, -3)>]
    [<InlineData(1, -1)>]
    let ``MissingInteger returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = MissingInteger.GetSmallestMissingInteger(data)

        Assert.Equal(expected, result)

    [<Fact>]
    let ``MissingInteger extremes returns correct result efficiently`` () =
        let arr = [|1..100000|]
        let result = MissingInteger.GetSmallestMissingInteger(arr)

        Assert.Equal(100001, result)

    [<Fact>]
    let ``MissingInteger elements extremes returns correct result efficiently`` () =
        let arr = [|-1000000; 1000000|]
        let result = MissingInteger.GetSmallestMissingInteger(arr)

        Assert.Equal(1, result)

    [<Fact>]
    let ``MissingInteger returns correct result efficiently`` () =
        let arr = [|1..99999|]
        let result = MissingInteger.GetSmallestMissingInteger(arr)

        Assert.Equal(100000, result)

module MaxCounters =
    [<Fact>]
    let ``MaxCounters returns correct result`` () =
        let result1 = MaxCounters.ReturnCounters(5, [|3;4;4;6;1;4;4|])
        Assert.Equal<int[]>([|3;2;2;4;2|], result1)

        let result2 = MaxCounters.ReturnCounters(1, [|2|])        
        Assert.Equal<int[]>([|0;|], result2)

        let result3 = MaxCounters.ReturnCounters(2, [|1;3|])        
        Assert.Equal<int[]>([|1;1|], result3)

module FrogRiverOne =
    [<Theory>]
    [<InlineData(6, 5, 1, 3, 1, 4, 2, 3, 5, 4)>]
    [<InlineData(-1, 5, 1, 3, 1, 4, 2, 3, 4, 4)>]
    [<InlineData(0, 1, 1, 3, 1, 4, 2, 3, 5, 4)>]
    [<InlineData(0, 1, 1)>]
    [<InlineData(7, 5, 1, 3, 1, 4, 2, 3, 4, 5)>]
    let ``FrogRiverOne returns correct result`` (expected: int, position: int, [<ParamArray>] data: int[]) =
        let result = FrogRiverOne.GetTimeToJump(data, position)

        Assert.Equal(expected, result)

    [<Fact>]
    let ``FrogRiverOne returns correct result efficiently`` () =
        let arr = [|1..100000|]
        let result = FrogRiverOne.GetTimeToJump(arr, 99999)

        Assert.Equal(99998, result)

module TapeEquilibrium =
    [<Fact>]
    let ``TapeEquilibrium returns correct result efficiently`` () =
        let arr = [|1..100000|]
        let result = TapeEquilibrium.FindMinDiffIndex(arr)

        Assert.Equal(5658, result)

    [<Theory>]
    [<InlineData(1, 2, 3, 1, 5)>]
    [<InlineData(4, 2, 3, 4, 5)>]
    [<InlineData(0, 2, 2)>]
    [<InlineData(2000, -1000, 1000)>]
    [<InlineData(8, 2, 10, 20)>]
    let ``TapeEquilibrium returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = TapeEquilibrium.FindMinDiffIndex(data)

        Assert.Equal(expected, result)

module PerfMissingElem =
    [<Theory>]
    [<InlineData(4, 2, 3, 1, 5)>]
    [<InlineData(1, 2, 3, 4, 5)>]
    [<InlineData(1, 2)>]
    let ``PerfMissingElem returns correct result`` (expected: int, [<ParamArray>] data: int[]) =
        let result = PerfMissingElem.FoundMissingPermutation(data)

        Assert.Equal(expected, result)

module FrogJumpTests =
    [<Theory>]
    [<InlineData(10, 85, 30, 3)>]
    [<InlineData(10, 10, 30, 0)>]
    [<InlineData(10, 20, 10, 1)>]
    let ``Frog jump returns correct result`` (startP: int, endP: int, jump: int, expected: int) =
        let result = FrogJump.CountJumps(startP, endP, jump)

        Assert.Equal(expected, result)

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

module OddOccurencesCsharpTests = 
    [<Fact>]
    let ``Odd occurrences finds nothing`` () =
       let data = [|9;3;9;3;9;9|]
       let result = OddOccurrence.GetOccurence data 
       
       Assert.Equal(0, result)

    [<Fact>]
    let ``Odd occurrences finds 7`` () =
        let data = [|9;3;9;3;9;7;9|]
        let result = OddOccurrence.GetOccurence data 

        Assert.Equal(7, result)

    [<Fact>]
    let ``Odd occurrences finds 2`` () =
            let data =  2 :: [1..40000] @ [1..40000]
                        |> List.toArray
            let result = OddOccurrence.GetOccurence data 

            Assert.Equal(2, result)

    [<Fact>]
    let ``Odd occurrences array range fails (too large)`` () =
        let data = [|1..1000001|]
        let result = OddOccurrence.GetOccurence data 

        Assert.Equal(0, result)

    [<Fact>]
    let ``Odd occurrences array range fails (too small)`` () =
        let data = [||]
        let result = OddOccurrence.GetOccurence data 

        Assert.Equal(0, result)

    [<Fact>]
    let ``Odd occurrences array fails - element in invalid range (min)`` () =
        let data = [|0;3;3|]
        let result = OddOccurrence.GetOccurence data  

        Assert.Equal(0, result)

    [<Fact>]
    let ``Odd occurrences array fails - element in invalid range (max)`` () =
        let data = [|1000000001;3;3|]
        let result = OddOccurrence.GetOccurence data 

        Assert.Equal(0, result)

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
