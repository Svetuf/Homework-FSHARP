module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``osme test`` () = 
        concat [1; 2] [3; 4] |> should equal [2; 1; 3; 4]