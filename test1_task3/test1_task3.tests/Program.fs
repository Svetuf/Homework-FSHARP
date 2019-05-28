module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 
    open System.Threading



    [<Test>]
    let ``Add two, minus two`` () =
        let mutable parking_var = parking()

        let mutable firstEntry = entry(parking_var)
        let mutable secondEntry = entry(parking_var)
        let mutable thirdEntry = entry(parking_var)

        let someFirstEntry = 
            async{
            firstEntry.car_in |> ignore
            firstEntry.car_in |> ignore
            }

        let someSecondEntry = 
            async{
            secondEntry.car_out |> ignore
            secondEntry.car_out |> ignore
            }

        someFirstEntry |> Async.Start
        someSecondEntry |> Async.Start

        parking_var.free_places_count |> should equal 50

    [<Test>]
    let ``Add 3 minus 2`` () =
        let mutable parking_var = parking()

        let mutable firstEntry = entry(parking_var)
        let mutable secondEntry = entry(parking_var)
        let someFirstEntry = 
           async{
           firstEntry.car_in |> ignore
           firstEntry.car_in |> ignore
           firstEntry.car_in |> ignore
           }

        let someSecondEntry = 
            async{
            secondEntry.car_out |> ignore
            secondEntry.car_out |> ignore
            }
        
        [someFirstEntry; someSecondEntry]  |> Async.Parallel |> Async.RunSynchronously |> ignore

        parking_var.free_places_count |> should equal 49