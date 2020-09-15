module Lazy.Tests

    open NUnit.Framework
    open FsUnit
    open LazyFactory
    open Logic
    open System.Threading.Tasks
    open System.Threading


    [<Test>]
    let Test1 () =
        let mutable counter = 0
        let supplier = (fun () -> 
                            counter <- counter + 1 
                            1
                       )
        let Llazy = LazyFactory.CreatesigngeThread supplier
        let a = Llazy :> ILazy<int> 
        for _ in 0 .. 1024 do
            (a.Get()) |> ignore
        counter |> should equal 1


    [<Test>]
    let Test2 () =
        let supplier = (fun () -> new obj())
        let Lazy = LazyFactory.CreateMultiThread supplier
        Seq.map(fun _ -> 
                    (Lazy :> ILazy<obj>).Get() |> ((Lazy :> ILazy<obj>).Get()).Equals |> should be True
               ) 
               [|1..10|] |> ignore

    [<Test>]
    let Test3() =
        let mutable counter = (int64) 0
        let supplier = (fun () -> 
                            Interlocked.Increment &counter |> ignore 
                            (Interlocked.Read &counter) |> should equal 1
                       )
        let Lazy = LazyFactory.CreateMultiThread supplier         
        for _ in 1..1024 do
            Task.Run(fun () -> (Lazy :> ILazy<unit>).Get()) |> ignore


    [<Test>]
    let Test4() =
        let Lazy = LazyFactory.CreateMultiThreadNoLock (fun () -> 1)
        for _ in 1..1024 do
            Task.Run(fun () -> (Lazy :> ILazy<int>).Get() |> should equal 1) |> ignore


    [<Test>]
    let Test5() =
        let Lazy = LazyFactory.CreateMultiThreadNoLock (fun () -> 1)       
    
        let first = (Lazy :> ILazy<int>).Get()

        let testSeq = seq { for i in 1..1024 -> Lazy }
        testSeq |> Seq.map (fun x ->
                            async {
                                let other = (x :> ILazy<int>).Get()
                                first.Equals(other) |> should equal true
                            }
                            ) |> Async.Parallel |> Async.RunSynchronously |> ignore