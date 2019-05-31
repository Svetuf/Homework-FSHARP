module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 
    open System.Threading

    [<Test>]
    let ``Try take an element from empty queue`` () = 
        
        let mutable a = Blocking_Queue()
        let mutable b = 0
        let mutable d = a.add 1

        let someFirstEntry = 
           async{
             b <- LanguagePrimitives.ParseInt32( a.getFirstElement.ToString() )
           }

        let someSecondEntry = 
           async{
            Thread.Sleep(100)
            d <- a.add 1
           }
        
        [someFirstEntry; someSecondEntry]  |> Async.Parallel |> Async.RunSynchronously |> ignore

        b |> should equal 1

    [<Test>]
    let ``Too many threads`` () = 
        let mutable a = Blocking_Queue()
        let mutable one = 0
        let mutable two = 0

        let firstIn = 
           async{
             a.add 1
           }
        
        let secIn = 
           async{
             Thread.Sleep(200)
             a.add 2
           }

        let firstout = 
            async{
                one <- LanguagePrimitives.ParseInt32( a.getFirstElement.ToString() )
            }

        let secout =
            async{
                Thread.Sleep(200)
                two <- LanguagePrimitives.ParseInt32( a.getFirstElement.ToString() )
            }
        
        [firstIn;firstout; secIn;secout]  |> Async.Parallel |> Async.RunSynchronously |> ignore

        one |> should equal 1
        two |> should equal 2