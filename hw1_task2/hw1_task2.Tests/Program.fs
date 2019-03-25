module tests

    open NUnit.Framework
    open FsUnit
    open logic
    
    [<Test>]
    let ``5 Fibonacci number`` () =
        fibonacci 5 |> should equal 5

    [<Test>]
    let ``-1 Fibonacci number`` () =
        fibonacci 5 |> should equal "The given number is below zero."

    [<Test>]
    let ``22 Fibonacci number`` () =
        fibonacci 22 |> should equal 17711
        
    [<Test>]
    let ``0 Fibonacci number`` () =
        fibonacci 0 |> should equal 0
        
    