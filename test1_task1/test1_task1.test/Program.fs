module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``supermap [1; 2; 3] (fun x -> [2 * x; 3 * x]) should equal [2; 3; 4; 6; 6; 9]`` () =
        supermap [1; 2; 3] (fun x -> [2 * x; 3 * x]) |> 
            should equal [2; 3; 4; 6; 6; 9]
     
    [<Test>]
    let ``supermap ["a"; "b"; "c"] (fun x -> [x + "F#"]) should equal ["aF#"; "bF#"; "cF#"]`` () =
        supermap ["a"; "b"; "c"] (fun x -> [x + "F#"]) |> should equal ["aF#"; "bF#"; "cF#"]

    [<Test>]
    let ``supermap ["a"; "b"; "c"] (fun x -> [x + "F#"; x + "C#"]) should equal ["aF#"; "aC#"; "bF#"; "bC#"; "cF#"; "cC#"]`` () =
        supermap ["a"; "b"; "c"] (fun x -> [x + "F#"; x + "C#"]) |> should equal ["aF#"; "aC#"; "bF#"; "bC#"; "cF#"; "cC#"]

    [<Test>]
    let ``supermap [] (fun x -> [x; x] should equal []`` () =
        supermap [] (fun x -> [x; x]) |> should equal []