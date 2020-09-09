module Lazy.Tests

    open Logic
    open NUnit.Framework
    open FsUnit


    [<Test>]
    let Test1 () =
        let mutable counter = 0
        let supplier = (fun () -> 
                            counter <- counter + 1 
                            1
                       )
        let Llazy = SingleThread<int>(supplier)
        let a = Llazy :> ILazy<int> 
        for _ in 0 .. 1024 do
            (a.Get()) |> ignore
        counter |> should equal 1

