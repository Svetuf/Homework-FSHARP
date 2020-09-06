module Network.tests

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

    let mutable no_connection = matrix [[0.0]]
    no_connection <- matrix  [
                            [1.; -1.; -1.; -1.]; 
                            [1.; 1.; 1.; -1.];
                            [-1.; 1.; 1.; 1.];
                            [-1.; -1.; 1.; 1.];
                           ] 

    [<Test>]
    let AllInfect () =
        let mutable network = Network.Create [Comp.Create MacOS true; Comp.Create MacOS false;
        Comp.Create MacOS false; Comp.Create MacOS false] connections
        for i in 0 .. 3 do
            network.Tick
        network.status |> should equal [true; true; true; true]

    [<Test>]
    let NoOneInfect () =
        let mutable network = Network.Create [Comp.Create Windows true; Comp.Create Windows false;
        Comp.Create Windows false; Comp.Create Windows false] connections
        for i in 0 .. 1024 do
            network.Tick
        network.status |> should equal [true; false; false; false]

    [<Test>]
    let InfectButNotConnected () =
        let mutable network = Network.Create [Comp.Create MacOS true; Comp.Create MacOS false;
        Comp.Create MacOS false; Comp.Create MacOS false] no_connection
        for _ in 0 .. 1024 do
            network.Tick
        network.status |> should equal [true; false; false; false]
