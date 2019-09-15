 module Tests

    open NUnit.Framework
    open FsUnit
    open Logic
    open FsCheck.NUnit

    [<Test>]
    let ``Usual test`` () =
        func3 () 2 [0; 2; 4; 8; 16] |> should equal [0; 4; 8; 16; 32]

    [<Property>]
    let ``FsCheck``(x:int, l:list<int>) =        
        func3 () x l = (List.map (fun y -> y * x) l)