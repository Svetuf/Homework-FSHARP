module Tests

    open NUnit.Framework
    open FsUnit
    open Logic
    
    [<Test>]
    let ``5 Fibonacci number`` () =
        fibonacci 5 |> should equal 5

    [<Test>]
    let ``22 Fibonacci number`` () =
        fibonacci 22 |> should equal 17711
        
    [<Test>]
    let ``0 Fibonacci number`` () =
        fibonacci 0 |> should equal 0
        