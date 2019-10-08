module Tests

    open NUnit.Framework
    open FsUnit
    open Logic
    
    [<Test>]
    let ``Testing parallel push and pop`` () =
        let stack = ThreadSaveStack<int>()
        seq { for i in 0 .. 10 -> stack }
        |> Seq.mapi (fun step stack -> 
            if step % 2 = 0 then 
                async {
                    stack.Push step
                }
            else 
                async {
                    stack.TryPop() |> ignore
                })
        |> Async.Parallel            
        |> Async.RunSynchronously
        |> ignore
        
        stack.TryPop() |> should not' (equal None)        

    [<Test>]
    let ``Test pop func`` () =
        let stack = ThreadSaveStack<int>()
        seq { for i in 1 .. 5 -> stack.Push }
        |> Seq.mapi (fun step push -> 
            async {
                push step
            })
        |> Async.Parallel            
        |> Async.RunSynchronously
        |> ignore

        let rec assertStack step =
            if step = 6 then ()
            else
                stack.TryPop() |> should not' (equal None)

        assertStack 1
    
    [<Test>]
    let ``Simple test`` () =
        let stack = ThreadSaveStack<int>()
        stack.Push 5
        stack.TryPop () |> should equal (Some(5))

    [<Test>]
    let ``Empty stack`` () =
        let stack = ThreadSaveStack<int>()
        stack.TryPop () |> should equal None
