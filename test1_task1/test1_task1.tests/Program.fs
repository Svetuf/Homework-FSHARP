module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``answer 3 should equal [1; -2; 3]`` () =
        answer 3  |> should equal [1; -2; 3]

    [<Test>]
    let ``answer 4 should equal [1; -2; 3; -4]`` () =
        answer 4  |> should equal [1; -2; 3; -4]

    [<Test>]
    let ``answer 8 should equal [1; -2; 3; -4; 5; -6; 7; -8]`` () =
        answer 8  |> should equal [1; -2; 3; -4; 5; -6; 7; -8]