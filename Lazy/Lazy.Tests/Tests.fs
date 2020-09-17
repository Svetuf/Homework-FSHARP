module Lazy.Tests

    open NUnit.Framework
    open FsUnit
    open LazyFactory
    open Logic
    open System.Threading.Tasks
    open System.Threading


    [<Test>]
    let SingleThreadLazy_ShouldCallSupplierOnce () =
        let mutable counter = 0
        let supplier = (fun () -> 
                            counter <- counter + 1 
                            1
                       )
        let llazy = LazyFactory.CreateSingleThread supplier
        let a = llazy :> ILazy<int> 
        for _ in 0 .. 1024 do
            (a.Get()) |> ignore
        counter |> should equal 1


    [<Test>]
    let MultiThreadLazy_ShouldReturn_SameObjects () =
        let supplier = (fun () -> new obj())
        let llazy = LazyFactory.CreateMultiThread supplier
        Seq.map(fun _ -> 
                    (llazy :> ILazy<obj>).Get() |> ((llazy :> ILazy<obj>).Get()).Equals |> should be True
               ) 
               [|1..10|] |> ignore

    [<Test>]
    let MultiThreadLazy_ShouldCallSupplierOnce() =
        let mutable counter = (int64) 0
        let supplier = (fun () -> 
                            Interlocked.Increment &counter |> ignore 
                            (Interlocked.Read &counter) |> should equal 1
                       )
        let llazy = LazyFactory.CreateMultiThread supplier         
        for _ in 1..1024 do
            Task.Run(fun () -> (llazy :> ILazy<unit>).Get()) |> ignore


    [<Test>]
    let MultiThreadLazyLockFree_ShouldReturnValue() =
        let llazy = LazyFactory.CreateMultiThreadNoLock (fun () -> 1)
        for _ in 1..1024 do
            Task.Run(fun () -> (llazy :> ILazy<int>).Get() |> should equal 1) |> ignore


    [<Test>]
    let MultiThreadLazyLockFree_ShouldReturnSameObjects() =
        let llazy = LazyFactory.CreateMultiThreadNoLock (fun () -> 1)       
    
        let first = (llazy :> ILazy<int>).Get()

        let testSeq = seq { for i in 1..1024 -> llazy }
        testSeq |> Seq.map (fun x ->
                            async {
                                let other = (x :> ILazy<int>).Get()
                                first.Equals(other) |> should equal true
                            }
                            ) |> Async.Parallel |> Async.RunSynchronously |> ignore