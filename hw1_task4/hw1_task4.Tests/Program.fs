module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``createList n = 1 m = 3 equal [2; 4; 8; 16]`` () =
        createList 1 3 |> should equal [2; 4; 8; 16]

    [<Test>]
    let ``createList n = 1 m = 5 equal [2; 4; 8; 16; 32; 64]`` () =
        createList 1 5 |> should equal [2; 4; 8; 16; 32; 64]

    [<Test>]
    let ``createList n = 3 m = 3 equal [8; 16; 32; 64]`` () =
        createList 3 3 |> should equal [8; 16; 32; 64]

    [<Test>]
    let ``createList n = 0 m = 3 equal [1; 2; 4; 8]`` () =
        createList 0 3 |> should equal [1; 2; 4; 8]

    [<Test>]
    let ``createList n = 0 m = 0 equal []`` () =
        createList 0 0 |> should equal []