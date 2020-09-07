module Network.Tests

    open NUnit.Framework
    open Logic
    open FsUnit
    open MathNet.Numerics.LinearAlgebra


    let MacOS = OS.Create "macos" 1.0
    let Windows = OS.Create "windows" 0.0

    let mutable connections = matrix [[0.0]]
    connections <- matrix  [
                            [1.; 1.; -1.; -1.]; 
                            [1.; 1.; 1.; -1.];
                            [-1.; 1.; 1.; 1.];
                            [-1.; -1.; 1.; 1.];
                           ] 

    let mutable noConnection = matrix [[0.0]]
    noConnection <- matrix  [
                            [1.; -1.; -1.; -1.]; 
                            [1.; 1.; 1.; -1.];
                            [-1.; 1.; 1.; 1.];
                            [-1.; -1.; 1.; 1.];
                           ] 

    [<Test>]
    let AllInfect () =
        let mutable network = Network([Comp(MacOS,true); Comp(MacOS, false);
        Comp(MacOS, false); Comp(MacOS, false)],connections)
        for i in 0 .. 3 do
            network.Tick
        network.Status |> should equal [true; true; true; true]

    [<Test>]
    let NoOneInfect () =
        let mutable network = Network([Comp(Windows, true); Comp(Windows, false);
        Comp(Windows, false); Comp(Windows, false)], connections)
        for i in 0 .. 1024 do
            network.Tick
        network.Status |> should equal [true; false; false; false]

    [<Test>]
    let InfectButNotConnected () =
        let mutable network = Network([Comp(MacOS, true); Comp(MacOS, false);
        Comp(MacOS, false); Comp(MacOS, false)], noConnection)
        for _ in 0 .. 1024 do
            network.Tick
        network.Status |> should equal [true; false; false; false]
