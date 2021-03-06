﻿module Lessons
open BinaryGap
open OddOccurrencesInArray
open CyclicRotation

/// <summary>Counts A binary gap within a positive integer N is any maximal sequence of consecutive zeros 
/// that is surrounded by ones at both ends in the binary representation of N.
/// N is an integer within the range [1..2,147,483,647]. </summary>
let onGetBinaryGap =
    getBinaryGap 1 2147483647

/// <summary>Get one value from array A (consisting of N integers) which does not occur in an even number of times
/// where N is an odd integer within the range [1..1,000,000],
/// each element of array A is an integer within the range [1..1,000,000,000].</summary>
let onGetOddOccurence =
    findOddOccurrence 1 1000000 1 1000000000

/// <summary> Given an array A consisting of N integers and an integer K, return the array A rotated K times
/// where N and K are integers within the range [0..100],
/// each element of array A is an integer within the range [−1,000..1,000]. </summary>
let onIntArrayRotate =
    doCyclicRotation 0 100 -1000 1000