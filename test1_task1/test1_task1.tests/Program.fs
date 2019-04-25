module tests

    open NUnit.Framework
    open FsUnit
    open logic

    [<Test>]
    let ``test summ of even Fibonacci numbers below 1000000`` () =
         summOfEvenFibonacciNums |> should equal 1089154