module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``First five primes are [2; 3; 5; 7; 11]`` () =
        infinitPrimes () |> Seq.take 5 |> Seq.toArray |> should equal [2; 3; 5; 7; 11]

    [<Test>]
    let ``267th prime is 1709`` () = 
        infinitPrimes () |> Seq.skip 266 |> Seq.take 1 |> Seq.toArray |> should equal [1709]

    [<Test>]
    let ``First prime is 2`` () =
        infinitPrimes () |> Seq.take 1 |> Seq.toArray |> should equal [2]