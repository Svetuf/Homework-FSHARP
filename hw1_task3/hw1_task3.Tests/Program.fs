module tests 

    open NUnit.Framework
    open FsUnit
    open logic 

    [<Test>]
    let ``reverse list with [1;2;3]`` () =
        rev [1; 2; 3] |> should equal [3; 2; 1]

    [<Test>]
    let ``reverse list with []`` () =
        rev [] |> should equal []

    [<Test>]
    let ``reverse list with [0; 0; 0; 1]`` () =
        rev [0; 0; 0; 1] |> should equal [1; 0; 0; 0]
     