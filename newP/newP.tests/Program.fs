module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Calculate one num.`` () = 
        concat [1] [2] |> should equal [1; 2]
