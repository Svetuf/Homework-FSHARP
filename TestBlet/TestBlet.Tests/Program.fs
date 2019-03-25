module tests 

    open NUnit.Framework
    open FsUnit
    open logic 

    [<Test>]
    let ``sum with 1 1 should give out 2`` () =
        sum 1 1 |> should equal 2