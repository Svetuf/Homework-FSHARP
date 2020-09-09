module Network.Tests

    open NUnit.Framework
    open Logic
    open FsUnit
    open MathNet.Numerics.LinearAlgebra


    let macOS = OS.Create "macos" 1.0
    let windows = OS.Create "windows" 0.0

    let mutable connections = array2D [
                                       [1; 1; 0; 0]; 
                                       [1; 1; 1; 0];
                                       [0; 1; 1; 1];
                                       [0; 0; 1; 1];
                                      ] 


    let mutable noConnection = array2D [
                                        [1; 0; 0; 0]; 
                                        [0; 1; 1; 0];
                                        [0; 1; 1; 1];
                                        [0; 0; 1; 1];
                                       ] 

    [<Test>]
    let AllInfect () =
        let mutable network = Network([Comp(macOS,true); Comp(macOS, false);
        Comp(macOS, false); Comp(macOS, false)],connections)
        for i in 0 .. 3 do
            network.Tick
        network.Status |> should equal [true; true; true; true]

    [<Test>]
    let NoOneInfect () =
        let mutable network = Network([Comp(windows, true); Comp(windows, false);
        Comp(windows, false); Comp(windows, false)], connections)
        for i in 0 .. 1024 do
            network.Tick
        network.Status |> should equal [true; false; false; false]

    [<Test>]
    let InfectButNotConnected () =
        let mutable network = Network([Comp(macOS, true); Comp(macOS, false);
        Comp(macOS, false); Comp(macOS, false)], noConnection)
        for _ in 0 .. 1024 do
            network.Tick
        network.Status |> should equal [true; false; false; false]
