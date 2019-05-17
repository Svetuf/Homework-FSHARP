module Tests

    open NUnit.Framework
    open FsUnit
    open Logic 
    open System

    let stack = Empty


    [<Test>]
    let ``It's not empty`` () = 
        (stack.Push 1).isEmpty |> should equal false

    [<Test>]
    let ``It's empty`` () = 
        stack.isEmpty |> should equal true

    [<Test>]
    let ``Top element`` () = 
        ((stack.Push 1).Push 2).Top |> should equal 2

    [<Test>]
    let ``Push and Pop`` () = 
        ((stack.Push 1).Push 2).Pop |> should equal (Stack(1, Empty))